using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLibrary.Models
{
    public abstract class User
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int Tokens { get; set; }
    }
}
