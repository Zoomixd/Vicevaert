using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vicevært.Contract.Dtos
{
    public class BookingDto
    {
        public int BookingId { get; set; }
        public DateTime Start { get; set; }
        public DateTime Slut { get; set; }
        public int LejemålId { get; set; }
    }
}
