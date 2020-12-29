using System.Collections.Generic;
using System.Threading.Tasks;

using GitLabApiClient.Internal.Http;
using GitLabApiClient.Internal.Paths;
using GitLabApiClient.Models.Issues.Requests;
using GitLabApiClient.Models.Issues.Responses;

namespace GitLabApiClient
{
    /// <inheritdoc />
    public sealed class IssueLinksClient : IIssueLinksClient
    {
        private readonly GitLabHttpFacade _httpFacade;

        internal IssueLinksClient(GitLabHttpFacade httpFacade) => _httpFacade = httpFacade;

        /// <inheritdoc />
        public async Task<List<IssueLink>> GetAsync(ProjectId projectId,
                                                    int sourceIssueIid) =>
            await _httpFacade.Get<List<IssueLink>>($"projects/{projectId}/issues/{sourceIssueIid}/links");

        /// <inheritdoc />
        public async Task<IssuesLinkRelation> CreateAsync(ProjectId projectId,
                                                          int sourceIssueIid,
                                                          CreateIssueLinkRequest createIssueLinkRequest) =>
            await _httpFacade.Post<IssuesLinkRelation>($"projects/{projectId}/issues/{sourceIssueIid}/links",
                                                       createIssueLinkRequest);
    }
}
