using System;
using System.Collections.Generic;
using System.Text;

namespace Heyscot_DataAccess.Models
{
    public class CustomerTalents
    {
        public CustomerTalents()
        {
            this.Talents = new List<Talent>();
            this.Customers = new List<Customer>();
        }

        public List<Talent> Talents { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
