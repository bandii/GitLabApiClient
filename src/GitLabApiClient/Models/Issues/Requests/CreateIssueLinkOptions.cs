namespace GitLabApiClient.Models.Issues.Requests
{
    /// <summary>
    /// Options for issues links listing
    /// </summary>
    public class CreateIssueLinkOptions
    {
        internal CreateIssueLinkOptions() { }

        /// <summary>
        /// The id of the target issue's project
        /// </summary>
        public string TargetProjectId { get; set; }

        /// <summary>
        /// The internal id of the target issue
        /// </summary>
        /// <remarks>
        /// <see cref="ModifiableObject.Iid"/>
        /// </remarks>
        public int TargetIid { get; set; }
    }
}
