using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vicevært.Domain.Entities
{
    public class Rekvisition
    {

        [Key]
        public int RekvisitionId { get; set; }

        public string RekvisitionType { get; set; }

        public string? Kommentar { get; set; }

        public int LejerId { get; set; }
        [ForeignKey("LejerId")]
        public virtual Lejer Lejer { get; set; }



        public enum Typer
        {

            Elektricitet,
            VVS,
            Tømrer,
            Blikkenslager,
            Andet
        }




        public Rekvisition()
        { }

        //public Rekvisition()
        //{ }
        public Rekvisition(string rekvisitiontype, string kommentar, int lejerid)
        {


            RekvisitionType = rekvisitiontype;
            Kommentar = kommentar;
            LejerId = lejerid;

        }
    }
}
