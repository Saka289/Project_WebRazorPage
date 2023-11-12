using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lan2_1.Pages
{
    public class UploadFilesModelModel : PageModel
    {

        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;
        public UploadFilesModelModel(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            _environment = environment;
        }
        [Required(ErrorMessage = "Please choose at least one file.")]
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = "png,jpg,jpeg,gif")]
        [DisplayName("Choose file(s) to upload")]
        [BindProperty]
        public IFormFile[] FileUpLoads { get; set; }
        public async Task OnPostAsync()
        {
            if (FileUpLoads != null)
            {
                foreach (var FileUpLoad in FileUpLoads)
                {
                    var file = Path.Combine(_environment.ContentRootPath, "Images", FileUpLoad.FileName);
                    using (var fileStream = new FileStream(file, FileMode.Create))
                    {
                        await FileUpLoad.CopyToAsync(fileStream);
                    }
                }

            }
        }
    }
}
