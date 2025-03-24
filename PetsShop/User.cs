namespace PetsShop
{
    public class User
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int ID { get; set; }

        public User() { }
        public User(string userName, string password, string firstName, string lastName, int id)
        {
            this.userName = userName;
            this.password = password;
            this.firstName = firstName;
            this.lastName = lastName;
            ID = id;
        }
    }
}
