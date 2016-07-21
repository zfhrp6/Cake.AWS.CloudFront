#region Using Statements
    using System.IO;

    using Cake.Core;
    using Cake.Core.IO;
    using Cake.AWS.S3;

    using NSubstitute;
#endregion



namespace Cake.AWS.CloudFront.Tests
{
    internal static class CakeHelper
    {
        #region Functions (3)
            public static ICakeEnvironment CreateEnvironment()
            {
                var environment = Substitute.For<ICakeEnvironment>();
                environment.WorkingDirectory = Directory.GetCurrentDirectory();

                return environment;
            }


        
            public static IS3Manager CreateS3Manager()
            {
                return new S3Manager(new FileSystem(), CakeHelper.CreateEnvironment(), new DebugLog());
            }

            public static ICloudFrontManager CreateCloudFrontManager()
            {
                return new CloudFrontManager(CakeHelper.CreateEnvironment(), new DebugLog());
            }
        #endregion
    }
}
