using System;
using System.Collections.Generic;
using GitLabApiClient.Models.Milestones.Responses;
using Newtonsoft.Json;

namespace GitLabApiClient.Models.Issues.Responses
{
    /// <summary>
    /// Defines a linked issue
    /// </summary>
    public sealed class IssueLink : ModifiableObject
    {
        [JsonProperty("issue_link_id")]
        public int IssueLinkId { get; set; }

        [JsonProperty("subscribed")]
        public bool Subsribed { get; set; }

        [JsonProperty("link_type")]
        public LinkType LinkType { get; set; }

        [JsonProperty("link_created_at")]
        public DateTime? LinkCreatedAt { get; set; }

        [JsonProperty("link_updated_at")]
        public DateTime? LinkUpdatedAt { get; set; }

        [JsonProperty("project_id")]
        public string ProjectId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("state")]
        public IssueState State { get; set; }

        [JsonProperty("assignees")]
        public List<Assignee> Assignees { get; } = new List<Assignee>();

        [JsonProperty("assignee")]
        public Assignee Assignee { get; set; }

        [JsonProperty("labels")]
        public List<string> Labels { get; } = new List<string>();

        [JsonProperty("author")]
        public Assignee Author { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("milestone")]
        public Milestone Milestone { get; set; }

        [JsonProperty("user_notes_count")]
        public int UserNotesCount { get; set; }

        [JsonProperty("due_date")]
        public string DueDate { get; set; }

        [JsonProperty("web_url")]
        public string WebUrl { get; set; }

        [JsonProperty("confidential")]
        public bool Confidential { get; set; }

        [JsonProperty("weight")]
        public int? Weight { get; set; }
    }
}
