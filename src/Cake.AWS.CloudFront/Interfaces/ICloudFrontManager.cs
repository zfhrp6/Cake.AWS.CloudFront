#region Using Statements
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
#endregion



namespace Cake.AWS.CloudFront
{
    /// <summary>
    /// Provides a high level utility for managing Amazon CloudFront distributions
    /// </summary>
    public interface ICloudFrontManager
    {
        #region Methods
        /// <summary>
        /// Invalidates objects from a CloudFront distribution.
        /// </summary>
        /// <param name="distributionId">The distribution to invalidate objects from.</param>
        /// <param name="items">The path of the objects to invalidate.</param>
        /// <param name="reference">A unique name that ensures the request can't be replayed.</param>
        /// <param name="settings">The <see cref="CloudFrontSettings"/> required to connect to Amazon CloudFront.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task <string> CreateInvalidation(string distributionId, IList<string> items, string reference, CloudFrontSettings settings, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get invalidation status from a CloudFront distribution.
        /// </summary>
        /// <param name="distributionId">The distribution to invalidate objects from.</param>
        /// <param name="invalidationId">The invalidation to get.</param>
        /// <param name="settings">The <see cref="CloudFrontSettings"/> required to connect to Amazon CloudFront.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<string> GetInvalidation(string distributionId, string invalidationId, CloudFrontSettings settings, CancellationToken cancellationToken = default(CancellationToken));
        #endregion
    }
}