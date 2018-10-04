using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class User:BaseEntity
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
