using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque.Models
{
    public class Courant
    {
        #region Champs privés
        private double _solde;
        private double _ligneDeCredit;
        #endregion
        
        //raccourci pour auto-prop => taper prop > tab
        //produit le même résultat qu'une propfull à la compilation
        //il s'agit juste d'un raccourci d'écriture
        
        #region Propriétés

        public string Numero { get; set; }

        //raccourci pour une propriété complète => taper propf > tab > tab

        public double Solde
        {
            get { return _solde; }
            private set { _solde = value; }
        }


        public double LigneDeCredit
        {
            get { return _ligneDeCredit; }
            set
            {
                if (value > 0)
                {
                    _ligneDeCredit = value;
                }
            }
        }

        public Personne Titulaire { get; set; }

        #endregion

        #region Methodes
        public void Retrait(double Montant)
        {
            if (Montant < 0) 
                Console.WriteLine("Montant incorrect");
            else
            {
                if (Montant <= Solde + LigneDeCredit)
                    Solde -= Montant;
                else Console.WriteLine("Solde insuffisant");
            }

        }

        public void Depot(double Montant)
        {
            if (Montant >= 0)
                Solde += Montant;
        }
        #endregion

    }
}
