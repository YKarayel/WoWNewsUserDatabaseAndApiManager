using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Uid { get; set; }
        public string Token { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
