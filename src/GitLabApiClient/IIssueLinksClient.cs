using System.Collections.Generic;
using System.Threading.Tasks;

using GitLabApiClient.Internal.Paths;
using GitLabApiClient.Models.Issues.Requests;
using GitLabApiClient.Models.Issues.Responses;

namespace GitLabApiClient
{
    /// <summary>
    /// Client for issue links API
    /// </summary>
    /// <remarks>
    /// https://docs.gitlab.com/ee/api/issue_links.html
    /// </remarks>
    public interface IIssueLinksClient
    {
        /// <summary>
        /// Gets all linked issue of the issue with <paramref name="sourceIssueIid"/>
        /// </summary>
        Task<List<IssueLink>> GetAsync(ProjectId projectId, int sourceIssueIid);

        /// <summary>
        /// Creates new link between issues
        /// </summary>
        /// <returns>Both the issues and the relation between them</returns>
        Task<IssuesLinkRelation> CreateAsync(ProjectId projectId,
                                             int sourceIssueIid,
                                             CreateIssueLinkRequest createIssueLinkRequest);
    }
}
