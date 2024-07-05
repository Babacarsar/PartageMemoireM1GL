using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MySql.Data.EntityFramework;


namespace MetierPM.Modele
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class BdMemoireContext : DbContext
    {
        public BdMemoireContext() : base("connBdMemoire1")
        { 
        }
        public DbSet<Personne> personnes { get; set; }
        public DbSet<Expert> experts { get; set; }
        public DbSet<Commentaire> comments { get; set; }
    }
}