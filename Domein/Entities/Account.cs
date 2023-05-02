using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Domein.Entities
{
    [Table("account")]
    public class Account
    {
        [Column("account_id")]
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AccountId { get; set; }
        [Required]
        [Column("first_name")]
        public string  FirstName { get; set; }
        [Column("last_name")]
        public string? LastName { get; set; }
        [Column("user_name")]
        public string? UserName { get; set; }
        [Column("phone_number")]
        [Required]
        public string PhoneNumber { get; set; }
        [NotMapped]
        public ICollection<Message> AllMessages { get; set; }
        [Column("password")]
        public int? Password { get; set; }
    }
}
