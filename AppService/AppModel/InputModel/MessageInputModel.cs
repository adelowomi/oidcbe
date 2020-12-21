using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AppService.AppModel.InputModel
{
    public class MessageInputModel
    {
        [Required]
        public string Text { get; set; }

        [JsonIgnore]
        public int SenderId { get; set; }

        [JsonIgnore]
        public int? ReceiverId { get; set; }

        [JsonIgnore]
        public int MessageTypeId { get; set; }

        public int? MessageQuoteId { get; set; }
    }
}
