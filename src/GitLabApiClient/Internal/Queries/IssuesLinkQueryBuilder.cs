using GitLabApiClient.Internal.Utilities;
using GitLabApiClient.Models.Issues.Requests;

namespace GitLabApiClient.Internal.Queries
{
    internal class IssuesLinkQueryBuilder : QueryBuilder<CreateIssueLinkOptions>
    {
        protected override void BuildCore(Query query, CreateIssueLinkOptions options)
        {
            Guard.NotEmpty(options.TargetProjectId, nameof(options.TargetProjectId));

            query.Add("target_project_id", options.TargetProjectId);
            query.Add("target_issue_iid", options.TargetIid);
        }
    }
}
