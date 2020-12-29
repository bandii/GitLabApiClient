using System;

using GitLabApiClient.Internal.Utilities;
using GitLabApiClient.Models.Issues.Requests;
using GitLabApiClient.Models.Issues.Responses;

namespace GitLabApiClient.Internal.Queries
{
    internal class IssuesLinkQueryBuilder : QueryBuilder<CreateIssueLinkOptions>
    {
        protected override void BuildCore(Query query, CreateIssueLinkOptions options)
        {
            Guard.NotEmpty(options.TargetProjectId, nameof(options.TargetProjectId));

            query.Add("target_project_id", options.TargetProjectId);
            query.Add("target_issue_iid", options.TargetIid);

            if (options.LinkType.HasValue)
            {
                string stateQueryValue = GetStateQueryValue(options.LinkType.Value);
                if (!stateQueryValue.IsNullOrEmpty())
                    query.Add("link_type", stateQueryValue);
            }
        }

        private static string GetStateQueryValue(LinkType linkType)
        {
            switch (linkType)
            {
                case LinkType.RelatesTo:
                    return "relates_to";
                case LinkType.Blocks:
                    return "blocks";
                case LinkType.IsBlockedBy:
                    return "is_blocked_by";
                default:
                    throw new NotSupportedException($"LinkType {linkType} is not supported");
            }
        }
    }
}
