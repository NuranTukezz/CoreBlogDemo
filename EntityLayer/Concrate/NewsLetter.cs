using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrate
{
    public class NewsLetter
    {
        [Key]//şu işlem solide aykırı ama key Attributes olmadan migrations oluşturamadım bu sebeple yazmak zorunda kaldım
        public int MailID { get; set; }
        public string Mail { get; set; }
        public bool MailStatus { get; set; }
    }
}
