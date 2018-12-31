

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace GolfPracticeTracker.Models
{
    public class FileUpload
    {
        //[Display(Name = "SkyTrak CSV")]
        //[StringLength(40, MinimumLength = 3)]
        //public string FileName { get; set; }

        [Display(Name = "Upload new SkyTrak CSV practice data")]
        public IFormFile UploadSkyTrakFile { get; set; }
    }
}
