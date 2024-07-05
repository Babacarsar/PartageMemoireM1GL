using MetierPM.Modele;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MetierPM
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
        private readonly BdMemoireContext _db;
        private readonly ILogger<Service1> _logger;

        public Service1(BdMemoireContext db, ILogger<Service1> logger)
        {
            _db = db;
            _logger = logger;
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public bool AddExpert(Expert expert)
        {
            try
            {
                _db.experts.Add(expert);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while adding an expert.");
                return false;
            }
        }

        public bool UpdateExpert(Expert expert)
        {
            try
            {
                var leExpert = _db.experts.Find(expert.ID);
                if(leExpert == null)
                {

                    leExpert.Prenom = expert.Prenom;
                    leExpert.Nom =expert.Nom;
                    _db.SaveChanges();
                    return true;

                }
                
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while updating an expert.");
                return false;
            }
            return false;
        }

        public bool DeleteExpert(int? IdExpert)
        {
            try
            {
                var leExpert = _db.experts.Find(IdExpert);
                if (leExpert == null)
                {
                    _db.experts.Remove(leExpert); 
                    _db.SaveChanges();
                    return true;

                }

            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while deleting an expert.");
                return false;
            }
            return false;
        }


        public List<Expert> GetAllExpert()
        {
            return _db.experts.ToList();

        }
        public Expert GetExpert(int? IdExpert)
        {
            return _db.experts.Find(IdExpert);
        }
        public List<Expert> GetExperts (string Nom , string Prenom, string Specialite)
        {
            var liste = _db.experts.ToList();
            if(!string.IsNullOrEmpty(Nom))
            {
                liste = liste.Where(a=>a.Nom.ToUpper().Contains(Nom.ToUpper())).ToList();
            }
       

            if (!string.IsNullOrEmpty(Prenom))
            {
                liste = liste.Where(a => a.Prenom.ToUpper().Contains(Prenom.ToUpper())).ToList();
            }
            

            if (string.IsNullOrEmpty(Specialite))
            {
                liste = liste.Where(a => a.Nom.ToUpper().Contains(Specialite.ToUpper())).ToList();
            }
            return liste;

          

        }
    }
}
