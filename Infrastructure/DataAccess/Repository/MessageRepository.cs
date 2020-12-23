using System;
using System.Collections.Generic;
using System.Linq;
using Core.Model;
using Infrastructure.DataAccess.DataContext;
using Infrastructure.DataAccess.Repository.Abstractions;
using Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repository
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public MessageRepository(AppDbContext context) : base(context)
        {
          
        }

        public Message CreateMessage(Message message)
        {
            if (message.MessageActionId == (int)MessageActionEnum.NEW)
            {
                var last = GetAllMessages().LastOrDefault();

                if (last == null)
                {
                    message.MessageIndicatorId = CreateMessageIndicator().Id;

                }
                else
                {
                    message.MessageIndicatorId = last.MessageIndicatorId;
                }
            }
            //} else if(message.MessageIndicatorId == (int)MessageActionEnum.REPLY) {

            //    FindMessageIndicator(message.Indicator).Id;
            //}
            else
            {
                var indicator = string.IsNullOrEmpty(message.Indicator) ? CreateMessageIndicator() : FindMessageIndicator(message.Indicator);

                message.MessageIndicatorId = indicator.Id;
            }

            message.MessageStatusId = (int)MessageStatusEnum.PENDING;

            if(message.MessageTypeId == 0)
            {
                message.MessageTypeId = (int)MessageTypeEnum.CHAT;
            }

            if(message.MessageQuoteId == 0)
            {
                message.MessageQuoteId = null;
            }

            if (message.ReceiverId == 0)
            {
                message.ReceiverId = null;
            }

            var result = CreateAndReturn(message);

            return GetAllMessages().FirstOrDefault(x => x.Id == result.Id);
        }

        public MessageIndicator FindMessageIndicator (string indicator)
        {
            var result = _context.MessageIndicators.FirstOrDefault(x => x.Name == indicator);

            return result;
        }

        public MessageIndicator CreateMessageIndicator ()
        {
            var indicator = new MessageIndicator
            {
                Reference = $"ID-REX-{Helper.RandomNumber(12)}",
                IsEnded = false,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
            };

            _context.MessageIndicators.Add(indicator);
            Save();
            return indicator;
        }

        public IEnumerable<Message> GetAllMessages()
        {
            var results = _context.Messages
                .Include(x => x.Receiver)
                .Include(x => x.MessageType)
                .Include(x => x.Sender)
                .Include(x => x.MessageStatus)
                .Include(x => x.MessageIndicator)
                ;
            return results;
        }

        public IEnumerable<MessageStatus> GetMessageStatuses()
        {
            return _context.MessageStatuses.ToList();
        }

        public IEnumerable<MessageType> GetMessageTypes()
        {
            return _context.MessageTypes.ToList();
        }

        public Message UpdateMessage(Message message)
        {
            var result = Update(message);

            return GetAllMessages().FirstOrDefault<Message>(x => x.Id == result.Id);
        }
    }
}
