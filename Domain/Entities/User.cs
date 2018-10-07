using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public abstract class User : BaseEntity
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
    public class Admin : User { }
    public class Employee : User { }
    public class FiredEmployee : User { }
}
