using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Heading
    {
        [Key]
        public int HeadingId { get; set; }

        [StringLength(50)]
        public string HeadingName { get; set; }

        public DateTime HeadingDate  { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public ICollection<Content> Contents { get; set; }

        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }
    }
}
