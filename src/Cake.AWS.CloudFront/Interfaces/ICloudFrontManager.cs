#region Using Statements
using System.Collections.Generic;
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
        string CreateInvalidation(string distributionId, IList<string> items, string reference, CloudFrontSettings settings);
        #endregion
    }
}