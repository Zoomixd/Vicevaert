using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vicevært.Domain.Entities
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        public DateTime Start { get; set; }

        public DateTime Slut { get; set; }


        public int LejemålId { get; set; }
        [ForeignKey("LejemålId")]
        public virtual Lejemaal Lejemaal { get; set; }




        public Booking()
        { }

        //public Rekvisition()
        //{ }
        public Booking(DateTime start, DateTime slut, int lejemålid)
        {


            Start = start;

            Slut = slut;

            LejemålId = lejemålid;

        }
    }
}
