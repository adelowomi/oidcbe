using System;
namespace AppService.AppModel.ViewModel
{
    public class MessageViewModel
    {
        public string Text { get; set; }

        public int? MessageIndicatorId { get; set; }

        public MessageIndicatorViewModel MessageIndicator { get; set; }

        public int SenderId { get; set; }

        public VendorViewModel Sender { get; set; }

        public int? ReceiverId { get; set; }

        public VendorViewModel Receiver { get; set; }

        public int MessageTypeId { get; set; }

        public MessageTypeViewModel MessageType { get; set; }

        public int MessageStatusId { get; set; }

        public MessageStatusViewModel MessageStatus { get; set; }

        public int? MessageQuoteId { get; set; }

        public MessageViewModel MessageQuote { get; set; }
    }
}
