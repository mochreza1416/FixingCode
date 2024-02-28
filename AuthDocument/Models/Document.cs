using System.ComponentModel.DataAnnotations;

namespace AuthDocument.Models
{
    public class Document
    {
        [Key]
        public int DocumentId { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public byte[] FileData { get; set; }
    }
}
