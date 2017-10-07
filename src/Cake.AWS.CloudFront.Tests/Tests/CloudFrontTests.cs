#region Using Statements
using System;
using System.Collections.Generic;

using Xunit;
using Shouldly;

using Cake.Core;
using Cake.Core.IO;
using Cake.AWS.S3;
using Cake.AWS.CloudFront;
#endregion



namespace Cake.AWS.CloudFront.Tests
{
    public class CloudFrontTests
    {
        [Fact]
        public void Test_Invalidation()
        {
            //Sync Directory
            ICakeEnvironment env = CakeHelper.CreateEnvironment();

            DirectoryPath path = new DirectoryPath("./Files/").MakeAbsolute(env.WorkingDirectory);
            System.IO.File.WriteAllText(path.FullPath + "/Test.txt", Guid.NewGuid().ToString());



            SyncSettings settings = env.CreateSyncSettings();
            settings.BucketName = "cake-aws-s3";
            settings.KeyPrefix = "cloudfront.tests/utils/";

            IS3Manager s3 = CakeHelper.CreateS3Manager();
            IList<string> keys = s3.SyncUpload(path, settings);

            keys.ShouldNotBeEmpty();



            //Invalidate Keys
            ICloudFrontManager cloud = CakeHelper.CreateCloudFrontManager();
            string invalidation = cloud.CreateInvalidation("E212F1OAIR275D", keys, "", CakeHelper.CreateEnvironment().CreateCloudFrontSettings());

            invalidation.ShouldNotBeNullOrEmpty();
        }
    }
}
