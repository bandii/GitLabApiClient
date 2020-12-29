using GitLabApiClient.Internal.Utilities;
using GitLabApiClient.Models.Issues.Responses;

using Newtonsoft.Json;

namespace GitLabApiClient.Models.Issues.Requests
{
    /// <summary>
    /// Used to create a link between issues
    /// </summary>
    public sealed class CreateIssueLinkRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateIssueLinkRequest"/> class.
        /// </summary>
        public CreateIssueLinkRequest(string targetProjectId, int targetIid)
        {
            Guard.NotEmpty(targetProjectId, nameof(targetProjectId));

            TargetProjectId = targetProjectId;
            TargetIid = targetIid;
        }

        /// <summary>
        /// The id of the target issue's project
        /// </summary>
        [JsonProperty("target_project_id")]
        public string TargetProjectId { get; }

        /// <summary>
        /// The internal id of the target issue
        /// </summary>
        /// <remarks>
        /// <see cref="ModifiableObject.Iid"/>
        /// </remarks>
        [JsonProperty("target_issue_iid")]
        public int TargetIid { get; }

        /// <summary>
        /// Type of the relation to be created between the issues
        /// </summary>
        [JsonProperty("link_type")]
        public LinkType LinkType { get; set; }
    }
}
