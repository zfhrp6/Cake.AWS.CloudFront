#region Using Statements
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Cake.Core;
using Cake.Core.Diagnostics;

using Amazon.CloudFront;
using Amazon.CloudFront.Model;
#endregion



namespace Cake.AWS.CloudFront
{
    /// <summary>
    /// Provides a high level utility for managing Amazon CloudFront distributions
    /// </summary>
    public class CloudFrontManager : ICloudFrontManager
    {
        #region Fields
        private readonly ICakeEnvironment _Environment;
        private readonly ICakeLog _Log;
        #endregion





        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="CloudFrontManager" /> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        /// <param name="log">The log.</param>
        public CloudFrontManager(ICakeEnvironment environment, ICakeLog log)
        {
            if (environment == null)
            {
                throw new ArgumentNullException("environment");
            }
            if (log == null)
            {
                throw new ArgumentNullException("log");
            }

            _Environment = environment;
            _Log = log;
        }
        #endregion





        #region Methods
        private AmazonCloudFrontClient GetClient(CloudFrontSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }
                
            if (settings.Region == null)
            {
                throw new ArgumentNullException("settings.Region");
            }

            if (settings.Credentials == null)
            {
                if (String.IsNullOrEmpty(settings.AccessKey))
                {
                    throw new ArgumentNullException("settings.AccessKey");
                }
                if (String.IsNullOrEmpty(settings.SecretKey))
                {
                    throw new ArgumentNullException("settings.SecretKey");
                }

                if (!String.IsNullOrEmpty(settings.SessionToken))
                {
                    return new AmazonCloudFrontClient(settings.AccessKey, settings.SecretKey, settings.SessionToken, settings.Region);
                }
                else
                {
                    return new AmazonCloudFrontClient(settings.AccessKey, settings.SecretKey, settings.Region);
                }
            }
            else
            {
                return new AmazonCloudFrontClient(settings.Credentials, settings.Region);
            }
        }



        /// <summary>
        /// Invalidates objects from a CloudFront distribution.
        /// </summary>
        /// <param name="distributionId">The distribution to invalidate objects from.</param>
        /// <param name="items">The path of the objects to invalidate.</param>
        /// <param name="reference">A unique name that ensures the request can't be replayed.</param>
        /// <param name="settings">The <see cref="CloudFrontSettings"/> required to connect to Amazon CloudFront.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task<string> CreateInvalidation(string distributionId, IList<string> items, string reference, CloudFrontSettings settings, CancellationToken cancellationToken = default(CancellationToken))
        {
            //Get Reference
            if (String.IsNullOrEmpty(reference))
            {
                reference = DateTime.Now.Ticks.ToString();
            }



            //Correct Paths
            List<string> paths = new List<string>();

            foreach (string item in items)
            {
                if (!item.StartsWith("/"))
                {
                    paths.Add("/" + item);
                }
            }



            //Create Request
            InvalidationBatch batch = new InvalidationBatch()
            {
                Paths = new Paths()
                {
                    Items = paths.ToList(),
                    Quantity = items.Count
                },

                CallerReference = reference
            };

            CreateInvalidationRequest request = new CreateInvalidationRequest()
            {
                    DistributionId = distributionId,
                    InvalidationBatch = batch
            };



            //Send Request
            _Log.Verbose("Create Invalidation {0}", distributionId);

            AmazonCloudFrontClient client = this.GetClient(settings);

            CreateInvalidationResponse response = await client.CreateInvalidationAsync(request);

            if (response.HttpStatusCode == System.Net.HttpStatusCode.Created)
            {
                return response.Invalidation.Id;
            }
            else
            {
                _Log.Error("Error invalidating object {0}", distributionId);

                return "";
            }
        }
        #endregion
    }
}