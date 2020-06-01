using System;

namespace AfiCustomerApi.Data.Models
{
    public class AfiCustomer
    {
        public int ID { get; set; }

        public string SurName { get; set; }

        public string FirstName { get; set; }

        public string PolicyReferenceNumber { get; set; }
    }
}
