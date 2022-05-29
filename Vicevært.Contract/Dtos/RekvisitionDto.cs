using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vicevært.Contract.Dtos
{
    public class RekvisitionDto
    {
        public int RekvisitionId { get; set; }

        public string RekvisitionType { get; set; }

        public string Kommentar { get; set; }

        public int LejerId { get; set; }
    }
}
