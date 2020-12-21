using System;
namespace AppService.AppModel.ViewModel
{
    public class MessageViewModel
    {
        public string Text { get; set; }

        public int SenderId { get; set; }

        public VendorViewModel Sender { get; set; }

        public VendorViewModel Receiver { get; set; }

        public MessageIndicatorViewModel MessageIndicator { get; set; }

        public string MessageType { get; set; }

        public string MessageStatus { get; set; }

        public MessageViewModel MessageQuote { get; set; }
    }
}
