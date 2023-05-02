using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein.Entities
{
    [Table("contact")]
    public class Contact
    {
        [Column("contact_id")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ContactId { get; set; }
        [Required]
        [Column("owner_account_id")]
        public Guid OwnerAccountId { get; set; }
        [NotMapped]
        public Account OwnerAccount { get; set; }
        [NotMapped]
        public Account InContact { get; set; }
        [Required]
        [Column("in_contact_id")]
        public Guid InContactId { get; set; }
    }
}
