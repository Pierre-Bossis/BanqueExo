using GestionBanque.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque.Models
{
    internal class Epargne : Compte
    {
        public DateTime DateDernierRetrait { get; private set; }

        #region Constructors

        public Epargne(string numero, Personne titulaire):base(numero,titulaire)
        {
            
        }

        public Epargne(string numero, Personne titulaire, double solde) : base(numero, titulaire, solde)
        {
        }

        #endregion

        #region Methods
        public override void Retrait(double montant)
        {
            if (Solde - montant < 0) throw new SoldeInsuffisantException("");
            base.Retrait(montant);
            DateDernierRetrait = DateTime.Now;
        }

        protected override double CalculInteret()
        {
            return Solde / 100 * 4.5;
        } 
        #endregion
    }
}
