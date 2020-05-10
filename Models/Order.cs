using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TextBooky.Models
{
    public class Order // model binding
    {
        [BindNever]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First Name")]
        [StringLength(25)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your street address")]
        [Display(Name = "Street Address")]
        [StringLength(100)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter your City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter your County")]
        public string County { get; set; }

        [Required(ErrorMessage = "Please enter your postcode")]
        public string PostCode { get; set; }

        public List<OrderDetail> OrderDetails { get; set; } // relationship - one to many

        [BindNever]
        public decimal OrderTotal { get; set; }

        [BindNever]
        public DateTime OrderPlaced { get; set; }

    }
}
