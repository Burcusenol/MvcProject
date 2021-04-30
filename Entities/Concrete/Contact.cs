using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string UserMail { get; set; }

        [StringLength(50)]
        public string Subject { get; set; }
        public string Message { get; set; }

    }
}
