using System;
using System.Linq;
using AppService.AppModel.ViewModel;
using AppService.Repository.Abstractions;
using AutoMapper;
using Core.Model;
using Infrastructure.DataAccess.Repository.Abstractions;

namespace AppService.Repository
{
    public class ContactAppService : ResponseViewModel, IContactAppService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public ContactAppService(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public ResponseViewModel GetContacts()
        {
            return Ok(_contactRepository.GetAll().Select(_mapper.Map<Contact, ContactViewModel>))
        }
    }
}
