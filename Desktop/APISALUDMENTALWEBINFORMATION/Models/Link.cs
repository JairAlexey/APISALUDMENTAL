using System.ComponentModel.DataAnnotations;

namespace APIWEBINFO.Models
{
    public class Link
    {
        [Key]
        public int IdLink { get; set; }
        public string linkVideo { get; set; }

    }
}
