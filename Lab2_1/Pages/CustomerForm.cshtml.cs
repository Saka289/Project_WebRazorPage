using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lan2_1.Models;

namespace Lan2_1.Pages
{
    public class CustomerFormModel : PageModel
    {
        public string Message { get; set; }
        [BindProperty]
        public Customer customerInfo { get; set; }  
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                Message = "Information is OK ";
                ModelState.Clear();
            }
            else
            {
                Message = "Error input data";
            }
        }
    }
}
