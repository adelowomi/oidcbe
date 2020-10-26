using System;
namespace Core.Model
{
    public class OrganizationType : BaseEntity
    {
        public string Name { get; set; }
    }
}

enum OrganizationTypeEnum
{
    INDIVIDUAL = 1,
    CORPORATE
}
