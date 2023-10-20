using Lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Persistence
{
    public class UserRepository
    {
        private readonly List<User> _users = new List<User>();

        public UserRepository()
        {

        }

        public User CreateFilm(User user)
        {
            _users.Add(user);

            return user;
        }

        public void DeleteUser(User user)
        {
            _users.Remove(user);
        }

        public void UpdateUser(User user)
        {
            var m = _users.FirstOrDefault(f => f.Id == user.Id);
            m = user;
        }

        public User? GetFilm(Guid id)
        {
            return _users.FirstOrDefault(f => f.Id == id);
        }

        public List<User> GetFilms()
        {
            return _users;
        }
    }
}
