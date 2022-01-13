using System;
using System.Collections.Generic;

#nullable disable

namespace APICustomer.API.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Serial { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ProductName { get; set; }
        public int Quanity { get; set; }
    }
}
