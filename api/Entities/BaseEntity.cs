namespace api.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public string UserNameCreator { get; set; }

        public string UserNameLastChange { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime LastChangeDate { get; set; }

    }
}