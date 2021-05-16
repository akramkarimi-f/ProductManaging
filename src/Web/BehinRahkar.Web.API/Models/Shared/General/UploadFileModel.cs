using System.ComponentModel.DataAnnotations;

namespace BehinRahkar.Web.API.Models.Shared.General
{
    public class UploadFileModel
    {
        [Required]
        public string File { get; set; }
        [Required]
        public string ContentType { get; set; }
    }
}
