using System;
namespace Core.Model
{
    public class BaseEntity
    {
        public int Id { get; set; }

        //public string ModifiedBy { get; set; }

        //public string CreatedBy { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsEnabled { get; set; }
        
    }
}
