#region Using Statements
    using System.Collections.Generic;

    using Xunit;

    using Cake.Core.IO;
    using Cake.AWS.S3;
#endregion



namespace Cake.AWS.CloudFront.Tests
{
    public class CloudFrontTests
    {
        [Fact]
        public void Test_Invalidation()
        {
            //Sync Directory
            SyncSettings settings = CakeHelper.CreateEnvironment().CreateSyncSettings();
            settings.BucketName = "cake-aws-s3";
            settings.KeyPrefix = "cloudfront.tests/utils/";

            IS3Manager s3 = CakeHelper.CreateS3Manager();
            IList<string> keys = s3.SyncUpload(new DirectoryPath("../../utils/"), settings);

            Assert.NotEmpty(keys);



            //Invalidate Keys
            ICloudFrontManager cloud = CakeHelper.CreateCloudFrontManager();
            string invalidation = cloud.CreateInvalidation("E212F1OAIR275D", keys, "", CakeHelper.CreateEnvironment().CreateCloudFrontSettings());

            Assert.NotNull(invalidation);
        }
    }
}
