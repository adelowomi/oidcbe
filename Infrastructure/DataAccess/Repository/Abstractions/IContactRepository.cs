using System;
using System.Collections.Generic;
using Core.Model;

namespace Infrastructure.DataAccess.Repository.Abstractions
{
    public interface IContactRepository
    {
        Contact CreateAndReturn(Contact contact);

        IEnumerable<Contact> GetAllContacts();

        Contact GetById(int id);
    }
}
