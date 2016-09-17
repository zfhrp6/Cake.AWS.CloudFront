#region Using Statements
    using System;

    using Cake.Core;

    using Amazon;
    using Amazon.Runtime;
#endregion



namespace Cake.AWS.CloudFront
{
    /// <summary>
    /// Contains extension methods for <see cref="ICakeEnvironment" />.
    /// </summary>
    public static class CakeEnvironmentExtensions
    {
        /// <summary>
        /// Helper method to get the AWS Credentials from environment variables
        /// </summary>
        /// <param name="environment">The cake environment.</param>
        /// <returns>A new <see cref="CloudFrontSettings"/> instance to be used in calls to the <see cref="ICloudFrontManager"/>.</returns>
        public static CloudFrontSettings CreateCloudFrontSettings(this ICakeEnvironment environment)
        {
            if (environment == null)
            {
                throw new ArgumentNullException("environment");
            }

            CloudFrontSettings settings = new CloudFrontSettings();

            //AWS Fallback
            AWSCredentials creds = FallbackCredentialsFactory.GetCredentials();
            if (creds != null)
            {
                settings.Credentials = creds;
            }

            //Environment Variables
            string region = environment.GetEnvironmentVariable("AWS_REGION");
            if (!String.IsNullOrEmpty(region))
            {
                settings.Region = RegionEndpoint.GetBySystemName(region);
            }

            return settings;
        }
    }
}
