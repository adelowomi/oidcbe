using System;
using System.Collections.Generic;
using Core.Model;

namespace Infrastructure.DataAccess.Repository.Abstractions
{
    public interface IContactRepository
    {
        Contact CreateAndReturn(Contact contact);

        IEnumerable<Contact> GetAll();

        Contact GetById(int id);
    }
}
