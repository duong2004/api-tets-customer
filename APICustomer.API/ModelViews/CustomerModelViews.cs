using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APICustomer.API.ModelViews
{
    public class CustomerModelViews
    {
        public class CustomerModelView
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }
            public DateTime CreatedDate { get; set; }
            public string ConvertStringDate => CreatedDate.ToString("dd/MM/yyyy");
        }
        public class AddCustomerModelView
        {
            [Required(ErrorMessage = "Vui lòng nhập tên khách hàng.")]
            [MaxLength(50)]
            public string Name { get; set; }
            [MaxLength(250)]
            public string Address { get; set; }
            [MaxLength(10), MinLength(10)]
            public string Phone { get; set; }
        }
    }
}
