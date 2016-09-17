#region Using Statements
    using System;
    using System.Linq;
    using System.Collections.Generic;

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
        #region Fields (2)
            private readonly ICakeEnvironment _Environment;
            private readonly ICakeLog _Log;
        #endregion





        #region Constructor (1)
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





        #region Helper Functions (1)
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

                    return new AmazonCloudFrontClient(settings.AccessKey, settings.SecretKey, settings.Region);
                }
                else
                {
                    return new AmazonCloudFrontClient(settings.Credentials, settings.Region);
                }
            }
        #endregion





        #region Main Functions (1)
            /// <summary>
            /// Invalidates objects from a CloudFront distribution.
            /// </summary>
            /// <param name="distributionId">The distribution to invalidate objects from.</param>
            /// <param name="items">The path of the objects to invalidate.</param>
            /// <param name="reference">A unique name that ensures the request can't be replayed.</param>
            /// <param name="settings">The <see cref="CloudFrontSettings"/> required to connect to Amazon CloudFront.</param>
            public string CreateInvalidation(string distributionId, IList<string> items, string reference, CloudFrontSettings settings)
            {
                //Get Reference
                if (String.IsNullOrEmpty(reference))
                {
                    reference = DateTime.Now.Ticks.ToString();
                }



                //Create Request
                InvalidationBatch batch = new InvalidationBatch()
                {
                    Paths = new Paths()
                    {
                        Items = items.ToList()
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

                CreateInvalidationResponse response = client.CreateInvalidation(request);

                if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
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
