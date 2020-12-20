using System.Collections.Generic;
using System.Linq;
using Core.Model;
using Infrastructure.DataAccess.DataContext;
using Infrastructure.DataAccess.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repository
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        public ContactRepository(AppDbContext context) : base(context)
        {

        }

        public IEnumerable<Contact> GetAllContacts ()
        {
            var results = _context
                                .Contacts
                                    .Include(x => x.ContactType)
                                        .ToList();

            return results;
        }
    }
}
