using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetierPM.Modele
{
    public class Commentaire
    {
        [Key]
        public int IdCommentaire { get; set; }

        [MaxLength(300), Required]
        public string laDemande { get; set; }
        [MaxLength(300)]
        public string laReponse { get; set; }

        public int? IdDemandeur { get; set; }
        [ForeignKey("IdDemandeur")]
        public Personne demandeur { get; set; }
        public DateTime dateCommentaire { get; set; } = DateTime.Now;

        public DateTime dateDemande { get; set; } = DateTime.Now;
        public DateTime dateReponse { get;set; }
        public int? IdRepondeur { get; set; }
        [ForeignKey("IdRepondeur")]
        public Personne expert { get; set; }
    }
}