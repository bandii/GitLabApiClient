using System.Linq;
using System.Threading.Tasks;

using FluentAssertions;

using GitLabApiClient.Internal.Queries;
using GitLabApiClient.Models.Issues.Requests;
using GitLabApiClient.Models.Issues.Responses;

using Xunit;

using static GitLabApiClient.Test.Utilities.GitLabApiHelper;

namespace GitLabApiClient.Test
{
    [Trait("Category", "LinuxIntegration")]
    [Collection("GitLabContainerFixture")]
    public class IssuesLinksClientTest
    {
        private readonly IssuesClient _issuesClient = new IssuesClient(GetFacade(),
                                                                       new IssuesQueryBuilder(),
                                                                       new ProjectIssueNotesQueryBuilder());

        private readonly IIssueLinksClient _sut = new IssueLinksClient(GetFacade());

        [Fact]
        public async Task CanLinkTwoNewIssuesTogetherThenFetchThem()
        {
            // Given two issues
            var sourceIssue = await _issuesClient.CreateAsync(TestProjectTextId,
                                                              new CreateIssueRequest("IssueLink_Title_1"));
            var targetIssue = await _issuesClient.CreateAsync(TestProjectTextId,
                                                              new CreateIssueRequest("IssueLink_Title_1"));

            // When I link the first as BlockedBy the second
            var retFromPost = await _sut.CreateAsync(TestProjectTextId,
                                                     sourceIssue.Iid,
                                                     options =>
                                                     {
                                                         options.TargetProjectId = TestProjectTextId;
                                                         options.TargetIid = targetIssue.Iid;
                                                     });

            // Then the relation is created
            retFromPost.Should().Match<IssuesLinkRelation>(testee => testee.LinkType == LinkType.RelatesTo
                                                                     && testee.SourceIssue.Iid == sourceIssue.Iid
                                                                     && testee.TargetIssue.Iid == targetIssue.Iid);

            // When I fetch it from the links API
            var retFromGet = await _sut.GetAsync(TestProjectTextId, sourceIssue.Iid);

            // Then the result is the same
            retFromGet.Should().NotBeNullOrEmpty();
            retFromGet.Should().HaveCount(1);

            retFromGet.Single().Should().Match<IssueLink>(testee => testee.LinkType == LinkType.RelatesTo
                                                                    && testee.Iid == targetIssue.Iid);
        }
    }
}
