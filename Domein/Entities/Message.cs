using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein.Entities
{
    [Table("message")]
    public  class Message
    {
        [Column("message_id")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid MessageId { get; set; }

        [Column("message_text")]
        public string MessageText { get; set; }

        [Column("sender_account_id")]
        [Required]
        public Guid SenderAccountId { get; set; }
        [NotMapped]
        public Account SenderAccount { get; set; }

        [Column("reciever_account_id")]
        [Required]
        public Guid RecieverAccountId { get; set; }

        [NotMapped]
        public Account RecieverAccount { get; set; }

        [Column("sent_time")]
        public DateTime SentTime  { get; set; } 

    }
}
