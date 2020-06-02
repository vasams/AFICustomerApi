using System;
using System.ComponentModel.DataAnnotations;

namespace AfiCustomerApi.Data.Models
{
    public class AfiCustomer
    {
        public int AfiCustomerID { get; set; }
        public string SurName { get; set; }
        public string FirstName { get; set; }
        public string PolicyReferenceNumber { get; set; }
        public DateTime? Dob { get; set; }
        public string Email { get; set; }
    }
}
