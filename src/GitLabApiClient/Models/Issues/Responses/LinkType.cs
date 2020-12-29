using System.Runtime.Serialization;

namespace GitLabApiClient.Models.Issues.Responses
{
    /// <summary>
    /// Type of the link between issues
    /// </summary>
    public enum LinkType
    {
        [EnumMember(Value = "relates_to")]
        RelatesTo,

        [EnumMember(Value = "blocks")]
        Blocks,

        [EnumMember(Value = "is_blocked_by")]
        IsBlockedBy,
    }
}
