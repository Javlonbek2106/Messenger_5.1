using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein.Entities
{
    public  class BunchOfAccount
    {
        [Column("bunch_of_accounts_id")]
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public Guid BunchOfAccountsId { get; set; }
        [NotMapped]
        public Account InnerAccount { get; set; }
        [Required]
        [Column("inner_account_id")]
        public Guid InnerAccountId { get; set; }
    }
}
