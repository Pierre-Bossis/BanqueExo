using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque.Models
{
    public class Personne
    {
        #region Champs privés
        private string _nom;
        private string _prenom;
        private DateTime _dateNaiss;
        #endregion

        #region accesseurs de champ privé
        public string Nom
        {
            get { return _nom; }
            private set { _nom = value; }
        }

        public string Prenom
        {
            get { return _prenom; }
            private set { _prenom = value; }
        }

        public DateTime DateNaiss
        {
            get { return _dateNaiss; }
            private set { _dateNaiss = value; }
        }
        #endregion

        #region Constructors

        public Personne(string nom,string prenom,DateTime dateNaiss)
        {
            Nom = nom;
            Prenom = prenom;
            DateNaiss = dateNaiss;
        }

        #endregion

    }
}
