using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrisContactWeb.Models
{
    public class businessContact
    {
        //setting the variables you want in the database, and making sure they're 'get' and 'set' appropriately
        public int businessContactID { get; set; }
        public string businessContactFirstName { get; set; }
        public string businessContactLastName { get; set; }
        public string businessContactTelephone { get; set; }
        public string businessContactBusinessTelephone { get; set; }
        public string businessContactEmail { get; set; }
        public string businessContactAddress1 { get; set; }
        public string businessContactAddress2 { get; set; }
        public string businessContactCity { get; set; }
        public string businessContactPostcode { get; set; }

    }
}
