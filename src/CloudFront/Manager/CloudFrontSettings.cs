﻿#region Using Statements
    using Amazon;
#endregion



namespace Cake.AWS.CloudFront
{
    /// <summary>
    /// The settings to use with requests to Amazon CloudFront
    /// </summary>
    public class CloudFrontSettings
    {
        #region Constructor (1)
            /// <summary>
            /// Initializes a new instance of the <see cref="CloudFrontSettings" /> class.
            /// </summary>
            public CloudFrontSettings()
            {
                Region = RegionEndpoint.EUWest1;
            }
        #endregion





        #region Properties (3)
            /// <summary>
            /// The AWS Access Key ID
            /// </summary>
            public string AccessKey { get; set; }

            /// <summary>
            /// The AWS Secret Access Key.
            /// </summary>
            public string SecretKey { get; set; }



            /// <summary>
            /// The endpoints available to AWS clients.
            /// </summary>
            public RegionEndpoint Region { get; set; }
        #endregion
    }
}
