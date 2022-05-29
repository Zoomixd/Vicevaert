using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vicevært.Application.Contract.Dtos
{
    public class RekvisitionQueryDto
    {

        public int RekvisitionId { get; set; }

        public string RekvisitionType { get; set; }

        public string Kommentar { get; set; }

        public int LejerId { get; set; }
    }
}
