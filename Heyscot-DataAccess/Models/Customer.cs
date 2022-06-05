using System;
using System.Collections.Generic;
using System.Text;

namespace Heyscot_DataAccess.Models
{
    public class Customer : BaseIdentity
    {
        public DateTime RegistrationDate { get; set; }
    }
}
