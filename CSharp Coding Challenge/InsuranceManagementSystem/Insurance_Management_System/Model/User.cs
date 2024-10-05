namespace Insurance_Management_System.Model
{
    internal class User
    {
        public int UserID { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public User()
        {
            
        }

        public User(int userID, string userName, string password, string role)
        {
            UserID = userID;
            UserName = userName;
            Password = password;
            Role = role;
        }

        public override string ToString()
        {
            return $"UserID: {UserID}\tUser Name: {UserName}\tPassword: {Password}\tRole: {Role}";
        }
    }
}
