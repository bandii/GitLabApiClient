using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using GitLabApiClient.Internal.Http;
using GitLabApiClient.Internal.Paths;
using GitLabApiClient.Internal.Queries;
using GitLabApiClient.Models.Issues.Requests;
using GitLabApiClient.Models.Issues.Responses;

namespace GitLabApiClient
{
    /// <inheritdoc />
    public sealed class IssueLinksClient : IIssueLinksClient
    {
        private readonly GitLabHttpFacade _httpFacade;
        private readonly IssuesLinkQueryBuilder _issuesLinkQueryBuilder;

        internal IssueLinksClient(GitLabHttpFacade httpFacade, IssuesLinkQueryBuilder issuesLinkQueryBuilder)
        {
            _httpFacade = httpFacade;
            _issuesLinkQueryBuilder = issuesLinkQueryBuilder;
        }

        /// <inheritdoc />
        public async Task<List<IssueLink>> GetAsync(ProjectId projectId,
                                                    int sourceIssueIid) =>
            await _httpFacade.Get<List<IssueLink>>($"projects/{projectId}/issues/{sourceIssueIid}/links");

        /// <inheritdoc />
        public async Task<IssuesLinkRelation> CreateAsync(ProjectId projectId,
                                                          int sourceIssueIid,
                                                          Action<CreateIssueLinkOptions> options)
        {
            var queryOptions = new CreateIssueLinkOptions();
            options?.Invoke(queryOptions);

            string url = _issuesLinkQueryBuilder.Build($"projects/{projectId}/issues/{sourceIssueIid}/links",
                                                       queryOptions);
            return await _httpFacade.Post<IssuesLinkRelation>(url);
        }
    }
}
