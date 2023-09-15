using examenC_.Models;
using System.Text.Json;


namespace examenC_.Repository
{
    public class UserRepository
    {
        public User connexion(string login, string password)
        {
            User user = new User();

            List<User>? users = new List<User>();

            var jsonData = File.ReadAllText("user.json");

            users = JsonSerializer.Deserialize<List<User>>(jsonData);

            user = users.Find(u => u.Login == login && u.Password == password);

            return user;
        }
    }
}
