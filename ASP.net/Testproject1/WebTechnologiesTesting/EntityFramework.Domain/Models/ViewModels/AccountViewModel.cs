using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Domain.Models.ViewModels {
    public class AccountViewModel {

        public string Username { get; set; }
        
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
    }
}
