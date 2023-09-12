using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque.Models
{
    public class Compte
    {
        protected double _solde;

        public string Numero { get; set; }
        public virtual double Solde
        {
            get { return _solde; }
            private set { _solde = value; }
        }
        public Personne Titulaire { get; set; }

        public virtual void Retrait(double montant)
        {
            if (montant < 0) throw new Exception("Montant doit etre positif");
            Solde -= montant;

        }

        public virtual void Depot(double montant)
        {
            if (montant >= 0)
                Solde += montant;
        }

        public static double operator +(Compte c, double m)
        {
            return (c.Solde > 0 ? c.Solde : 0) + m;
        }
    }
}
