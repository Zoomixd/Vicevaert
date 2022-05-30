using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vicevært.Application.Contract.Dtos
{
    public class BookingQueryDto
    {
        public int BookingId { get; set; }
        public DateTime Start { get; set; }
        public DateTime Slut { get; set; }
        public int LejemålId { get; set; }
    }
}
