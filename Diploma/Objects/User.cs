namespace Diploma.Objects
{
    public class User
    {

        private string Username { get; init; } = string.Empty;
        private string Password { get; init; } = string.Empty;
        private string? PswConfirm { get; init; } = string.Empty;

        public User(string username, string password, string? pswConfirm = null)
        {
            Username = username;
            Password = password;
            PswConfirm = pswConfirm;
        }

        public string GetUsername() => Username;

        public string GetPassword() => Password;

        public string GetPswConfirm() => PswConfirm;
    }
}