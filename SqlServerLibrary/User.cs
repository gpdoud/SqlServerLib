using System;
using System.Collections.Generic;
using System.Text;

namespace SqlServerLibrary {
    
    public class User {
        
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Reviewer { get; set; }
        public bool Admin { get; set; }

    }
}
