namespace BasicCrud.Data.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }

        // Profile information
        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        // Hash
        public byte[] Hash { get; set; }
    }
}
