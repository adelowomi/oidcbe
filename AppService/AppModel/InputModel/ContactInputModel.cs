using System;
using Newtonsoft.Json;

namespace AppService.AppModel.InputModel
{
    public class ContactInputModel
    {
        public string ContactName { get; set; }

        public string Telephone { get; set; }

        public int ContactTypeId { get; set; }

        public string EmailAddress { get; set; }

        [JsonIgnore]
        public DateTime DateCreated => DateTime.Now;
    }
}
