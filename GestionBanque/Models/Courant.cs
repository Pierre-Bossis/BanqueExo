using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque.Models
{
    public class Courant : Compte
    {
        #region Champs privés
        private double _ligneDeCredit;
        #endregion

        #region Propriétés

        public  double LigneDeCredit
        {
            get { return _ligneDeCredit; }
            private set
            {
                if (value > 0)
                {
                    _ligneDeCredit = value;
                }
            }
        }
        #endregion

        #region Constructors
        public Courant(string numero, Personne titulaire) : base(numero, titulaire)
        {
        }

        //public Courant(string numero, Personne titulaire, double solde) : base(numero,titulaire,solde)
        //{
            
        //}

        public Courant(string numero, Personne titulaire, double ligneDeCredit):this(numero,titulaire)
        {
            LigneDeCredit= ligneDeCredit;
        }

        #endregion

        #region Methodes
        public override void Retrait(double Montant)
        {
            if(Montant <= Solde + LigneDeCredit)
            {
                base.Retrait(Montant);
            }
            else Console.WriteLine("Solde insuffisant");

        }

        public static double operator +(Courant c1,Courant c2)
        {
            if (c1.Solde < 0 && c2.Solde >= 0) return c2.Solde;
            if(c2.Solde < 0 && c1.Solde >= 0) return c1.Solde;
            if (c2.Solde < 0 && c1.Solde < 0) return 0;
            return c1.Solde + c2.Solde;
        }

        protected override double CalculInteret()
        {
            if(Solde > 0)
            {
                return Solde / 100 * 3;
            }

            return Solde / 100 * 9.75;
        }
        #endregion

    }
}