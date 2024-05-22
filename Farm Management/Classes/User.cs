namespace Classes.User
{
    public class User
    {
        private string Username;
        private int UserID;

        public User(string Username, int UserID)
        {
            this.Username = Username;
            this.UserID = UserID;
        }

        public string GetUsername()
        {
            return Username;
        }

        public int GetUserID()
        {
            return UserID;
        }
    }
}
