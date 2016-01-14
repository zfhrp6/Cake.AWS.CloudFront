﻿#region Using Statements
    using System.Collections.Generic;

    using Cake.Core;
    using Cake.Core.Annotations;
#endregion



namespace Cake.AWS.CloudFront
{
    /// <summary>
    /// Contains Cake aliases for configuring Amazon Cloud Front distributions
    /// </summary>
    [CakeAliasCategory("AWS")]
    [CakeNamespaceImport("Amazon")]
    [CakeNamespaceImport("Amazon.CloudFront")]
    public static class CloudFrontAliases
    {
        private static ICloudFrontManager CreateManager(this ICakeContext context)
        {
            return new CloudFrontManager(context.Environment, context.Log);
        }



        /// <summary>
        /// Invalidates objects from a CloudFront distribution.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="distributionId">The distribution to invalidate objects from.</param>
        /// <param name="item">The path of the object to invalidate.</param>
        /// <param name="settings">The <see cref="CloudFrontSettings"/> required to connect to Amazon CloudFront.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("CloudFront")]
        public static void CreateInvalidation(this ICakeContext context, string distributionId, string item, CloudFrontSettings settings)
        {
            context.CreateManager().CreateInvalidation(distributionId, new List<string>() { item }, settings);
        }

        /// <summary>
        /// Invalidates objects from a CloudFront distribution.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="distributionId">The distribution to invalidate objects from.</param>
        /// <param name="items">The path of the objects to invalidate.</param>
        /// <param name="settings">The <see cref="CloudFrontSettings"/> required to connect to Amazon CloudFront.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("CloudFront")]
        public static void CreateInvalidation(this ICakeContext context, string distributionId, IList<string> items, CloudFrontSettings settings)
        {
            context.CreateManager().CreateInvalidation(distributionId, items, settings);
        }
    }
}
