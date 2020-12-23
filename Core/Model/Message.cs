using System;
namespace Core.Model
{
    public class Message : BaseEntity
    {
        public string Text { get; set; }

        public int? MessageIndicatorId { get; set; }

        public MessageIndicator MessageIndicator { get; set; }

        public int SenderId { get; set; }

        public AppUser Sender { get; set; }

        public int? ReceiverId { get; set; }

        public AppUser Receiver { get; set; }

        public int MessageTypeId { get; set; }

        public MessageType MessageType { get; set; }

        public int MessageStatusId { get; set; }

        public MessageStatus MessageStatus { get; set; }

        public int? MessageQuoteId { get; set; }

        public Message MessageQuote { get; set; }

        public string Indicator { get; set; }

        public int MessageActionId { get; set; }

        public MessageAction MessageAction { get; set; }
    }


    public enum MessageActionEnum
    {
        NEW = 1,
        REPLY
    }
}
