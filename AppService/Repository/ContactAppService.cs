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
    public class ContactAppService : ResponseViewModel, IContactAppService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public ContactAppService(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public ResponseViewModel CreateContact(ContactInputModel contact)
        {
            return Ok(_mapper.Map<Contact, ContactViewModel>(_contactRepository.CreateAndReturn(_mapper.Map<ContactInputModel, Contact>(contact))));
        }

        public ResponseViewModel GetContacts()
        {
            return Ok(_contactRepository.GetAllContacts().Select(_mapper.Map<Contact, ContactViewModel>));
        }
    }
}
