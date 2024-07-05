using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetierPM.Modele
{
    public class Personne
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage ="*") , MaxLength(80 , ErrorMessage ="taille maximal 80")]
        public string Nom { get; set; }
        [Required(ErrorMessage = "*"), MaxLength(80, ErrorMessage = "taille maximal 80")]
        public string Prenom { get; set; }
    }
}