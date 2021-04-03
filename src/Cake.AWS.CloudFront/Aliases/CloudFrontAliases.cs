#region Using Statements
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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
        public static async Task<string> CreateInvalidation(this ICakeContext context, string distributionId, string item, CloudFrontSettings settings)
        {
            return await context.CreateManager().CreateInvalidation(distributionId, new List<string>() { item }, "", settings);
        }

        /// <summary>
        /// Invalidates objects from a CloudFront distribution.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="distributionId">The distribution to invalidate objects from.</param>
        /// <param name="item">The path of the object to invalidate.</param>
        /// <param name="reference">A unique name that ensures the request can't be replayed.</param>
        /// <param name="settings">The <see cref="CloudFrontSettings"/> required to connect to Amazon CloudFront.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("CloudFront")]
        public static async Task<string> CreateInvalidation(this ICakeContext context, string distributionId, string item, string reference, CloudFrontSettings settings)
        {
            return await context.CreateManager().CreateInvalidation(distributionId, new List<string>() { item }, reference, settings);
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
        public static async Task<string> CreateInvalidation(this ICakeContext context, string distributionId, IList<string> items, CloudFrontSettings settings)
        {
            return await context.CreateManager().CreateInvalidation(distributionId, items, "", settings);
        }

        /// <summary>
        /// Invalidates objects from a CloudFront distribution.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="distributionId">The distribution to invalidate objects from.</param>
        /// <param name="items">The path of the objects to invalidate.</param>
        /// <param name="reference">A unique name that ensures the request can't be replayed.</param>
        /// <param name="settings">The <see cref="CloudFrontSettings"/> required to connect to Amazon CloudFront.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("CloudFront")]
        public static async Task<string> CreateInvalidation(this ICakeContext context, string distributionId, IList<string> items, string reference, CloudFrontSettings settings)
        {
            return await context.CreateManager().CreateInvalidation(distributionId, items, reference, settings);
        }

        /// <summary>
        /// Get invalidation status from a CloudFront distribution.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="distributionId">The distribution to invalidate objects from.</param>
        /// <param name="invalidationId">The invalidation to get.</param>
        /// <param name="settings">The <see cref="CloudFrontSettings"/> required to connect to Amazon CloudFront.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("CloudFront")]
        public static async Task<string> GetInvalidation(this ICakeContext context, string distributionId, string invalidationId, CloudFrontSettings settings)
        {
            return await context.CreateManager().GetInvalidation(distributionId, invalidationId, settings);
        }
    }
}