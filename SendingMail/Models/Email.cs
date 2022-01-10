using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SendingMail.Models
{
    public class Email
    {
        public string Name { get; set; }
        public string EmailAdress { get; set; }
        public string Topic { get; set; }
        public string Comment { get; set; }
    }
}
