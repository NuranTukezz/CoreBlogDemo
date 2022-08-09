using Microsoft.AspNetCore.Http;

namespace CoreBlogDemo.Models
{
    public class AddProfileImage
    {
        //Bu classın amacı=> görsel yükleyebilmek için oluşturuldu WriterImage IFormFile türüne çevirdim dosya yükleyebilmek için

        public int WriterID { get; set; }
        public string WriterName { get; set; }
        public string WriterAbout { get; set; }
        public IFormFile WriterImage { get; set; }
        public string WriterMail { get; set; }
        public string WriterPassword { get; set; }
        public bool WriterStatus { get; set; }
    }
}
