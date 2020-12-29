using Newtonsoft.Json;

namespace GitLabApiClient.Models.Issues.Responses
{
    /// <summary>
    /// Defines a relation of two linked issues
    /// </summary>
    public sealed class IssuesLinkRelation
    {
        [JsonProperty("source_issue")]
        public IssueLink SourceIssue { get; set; }

        [JsonProperty("target_issue")]
        public IssueLink TargetIssue { get; set; }

        [JsonProperty("link_type")]
        public LinkType LinkType { get; set; }
    }
}
