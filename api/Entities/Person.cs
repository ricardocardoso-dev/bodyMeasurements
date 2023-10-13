using api.Enums;

namespace api.Entities
{
    public class Person : BaseEntity
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public EPersonType PersonType { get; set; }
    }
}