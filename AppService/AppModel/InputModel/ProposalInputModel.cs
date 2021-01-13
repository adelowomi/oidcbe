using System;
using System.Text.Json.Serialization;

namespace AppService.AppModel.InputModel
{
    public class ProposalInputModel
    {
        public int JobId { get; set; }

        [JsonIgnore]
        public int AppUserId { get; set; }

        [JsonIgnore]
        public int ProposalStatusId { get; set; }
    }
}
