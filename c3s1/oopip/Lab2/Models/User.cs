using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Models
{
    public enum Role
    {
        Admin,
        User
    }

    public class User
    {
        public required Guid Id { get; set; }
        public required string Nickname { get; set; }
        public required Role Role { get; set; }
    }
}
