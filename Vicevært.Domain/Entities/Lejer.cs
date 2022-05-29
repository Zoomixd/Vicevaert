using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vicevært.Domain.Entities
{
    public class Lejer
    {
        [Key]
        public int LejerId { get; set; }

        public int LejemaalId { get; set; }
        [ForeignKey("LejemaalId")]
        public virtual Lejemaal Lejemaal { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        //public DateTime MoveInDate { get; set; }

        //public DateTime? MoveOutDate { get; set; }
    }
}
