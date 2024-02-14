using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBooks.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
    }
}