using System;
using System.Collections.Generic;
using Core.Model;

namespace Infrastructure.DataAccess.Repository.Abstractions
{
    public interface IMessageRepository
    {
        IEnumerable<Message> GetAllMessages();

        IEnumerable<MessageType> GetMessageTypes();

        IEnumerable<MessageStatus> GetMessageStatuses();

        Message CreateMessage(Message message);

        Message UpdateMessage(Message message);
    }
}
