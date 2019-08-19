using DatingApp.API.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
namespace DatingApp.API.Data
{
    public class Seed
    {
        private readonly DataContext _context;
        public Seed(DataContext context)
        {
            _context = context;
        }

        public void SeedUser()
        {

            var UserData = System.IO.File.ReadAllText("Data/UserSeedData.json");

            var users = JsonConvert.DeserializeObject<List<User>>(UserData);

            foreach (var user in users)
            {

                byte[] passwordHash, passwordSalt;
                CreatePasswordHash("password", out passwordHash, out passwordSalt);
                user.UserName = user.UserName.ToLower();
                user.PasswordHash=passwordHash;
                user.PasswordSalt=passwordSalt;
                _context.Add(user);
            }

            _context.SaveChanges();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}