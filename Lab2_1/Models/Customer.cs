using Microsoft.AspNetCore.Mvc;
using Lan2_1.Binding;
using Lan2_1.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lan2_1.Models
{
    public class Customer
    {
        [Required(ErrorMessage ="Customer name is required")]
        [StringLength(20,MinimumLength =3,ErrorMessage ="The length of name is from 3 to 20 characters")]
        [DisplayName("Customer Name")]
        [ModelBinder(BinderType = typeof(CheckNameBinding))]
        public string CustomerName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Customer email is required")]
        [DisplayName("Customer Email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Year of birth is required")]
        [DisplayName("Year of birth")]
        [Range(1960,2000, ErrorMessage ="1960-2000")]
        [CustomerValidation]
        public int? YearOfBirth { get; set; }
    }
}
