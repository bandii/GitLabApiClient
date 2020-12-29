using FluentAssertions;

using GitLabApiClient.Internal.Queries;
using GitLabApiClient.Models.Issues.Requests;
using GitLabApiClient.Models.Issues.Responses;

using Xunit;

namespace GitLabApiClient.Test.Internal.Queries
{
    public class IssuesLinksOptionsBuilderTest
    {
        [Fact]
        public void NonDefaultQueryBuilt()
        {
            var sut = new IssuesLinkQueryBuilder();

            string query = sut.Build(
                                     "https://gitlab.com/api/v4/projects/proj_1/issues/1/links",
                                     new CreateIssueLinkOptions
                                     {
                                         TargetProjectId = "proj_1", TargetIid = 2, LinkType = LinkType.IsBlockedBy
                                     });

            query.Should().BeEquivalentTo("https://gitlab.com/api/v4/projects/proj_1/issues/1/links?"
                                          + "target_project_id=proj_1"
                                          + "&target_issue_iid=2"
                                          + "&link_type=is_blocked_by");
        }
    }
}
