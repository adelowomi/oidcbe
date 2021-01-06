using System;
using System.Linq;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Repository.Abstractions;
using AutoMapper;
using Core.Model;
using Infrastructure.DataAccess.Repository.Abstractions;

namespace AppService.Repository
{
    public class MessageAppService : ResponseViewModel, IMessageAppService
    {
        protected readonly IMessageRepository _messageRepository;
        protected readonly IUserService _userService;
        protected readonly IMapper _mapper;

        public MessageAppService(IMessageRepository messageRepository,
                                  IUserService userService,
                                  IMapper mapper)
        {
            _messageRepository = messageRepository;
            _userService = userService;
            _mapper = mapper;
        }

        public ResponseViewModel GetConversation()
        {
            var user = _userService.GetCurrentLoggedOnUserAsync().Result;

            return Ok(_messageRepository.GetAllMessages().Where(x => x.SenderId == user.Id || x.ReceiverId == user.Id).Select(_mapper.Map<Message, MessageViewModel>));
        }

        public ResponseViewModel GetConversation(int userId)
        {
            var user = _userService.GetCurrentLoggedOnUserAsync().Result;

            var resutls = _messageRepository
                                .GetAllMessages()
                                        .Where(x => x.SenderId == user.Id && x.ReceiverId == userId)
                                                .Select(_mapper.Map<Message, MessageViewModel>);

            return Ok(resutls);
        }

        public ResponseViewModel GetMessageStatues()
        {
            return Ok(_messageRepository.GetMessageStatuses().Select(_mapper.Map<MessageStatus, MessageStatusViewModel>));
        }

        public ResponseViewModel GetMessageTypes()
        {
            return Ok(_messageRepository.GetMessageTypes().Select(_mapper.Map<MessageType, MessageTypeViewModel>));
        }

        public ResponseViewModel SendMessage(MessageInputModel message)
        {
            message.SenderId = _userService.GetCurrentLoggedOnUserAsync().Result.Id;

            var results = _messageRepository
                            .CreateMessage(_mapper.Map<MessageInputModel, Message>(message));

            return Ok(_mapper.Map<Message, MessageViewModel>(results));
        }
    }
}
