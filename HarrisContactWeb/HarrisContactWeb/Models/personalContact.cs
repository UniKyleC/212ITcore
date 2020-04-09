using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrisContactWeb.Models
{
    public class personalContact
    {
        //setting the variables you want in the database, and making sure they're 'get' and 'set' appropriately
        public int personalContactID { get; set; }
        public string personalContactFirstName { get; set; }
        public string personalContactLastName { get; set; }
        public string personalContactTelephone { get; set; }
        public string personalContactHomeTelephone { get; set; }
        public string personalContactEmail { get; set; }
        public string personalContactAddress1 { get; set; }
        public string personalContactAddress2 { get; set; }
        public string personalContactCity { get; set; }
        public string personalContactPostcode { get; set; }


    }
}
