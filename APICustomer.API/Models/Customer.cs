using System;
using System.Collections.Generic;

#nullable disable

namespace APICustomer.API.Models
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Otp { get; set; }
        public DateTime? ExpOtp { get; set; }
    }
}
