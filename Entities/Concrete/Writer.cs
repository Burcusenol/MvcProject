using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterId { get; set; }

        [StringLength(50)]
        public string WriterName { get; set; }

        [StringLength(50)]
        public string WriterSurName { get; set; }

        [StringLength(100)]
        public string WriterImage { get; set; }

        [StringLength(100)]
        public string WriterAbout { get; set; }

        [StringLength(200)]
        public string WriterEmail { get; set; }

        [StringLength(200)]
        public string WriterPassword { get; set; }

        [StringLength(50)]
        public string WriterTitle { get; set; }
        public ICollection<Heading> Headings { get; set; }
        public ICollection<Content> Contents { get; set; }

    }
}
