using System;
using System.Collections.Generic;

namespace Core.Model
{
    public class MessageIndicator : BaseNameEntity
    {
        public string Reference { get; set; }

        public bool IsEnded { get; set; }

        public IEnumerable<Message> Messages { get; set; }
    }
}
