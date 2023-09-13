using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque.Models
{
    internal class Epargne : Compte
    {
        public DateTime DateDernierRetrait { get; set; }

        public override double LigneDeCredit
        {
            get
            {
                return 0;
            }
            set
            {
                throw new InvalidOperationException();
            }
        }

        public override void Retrait(double montant)
        {
            if (Solde - montant < 0) throw new Exception("Solde insuffisant");
            base.Retrait(montant);
            DateDernierRetrait = DateTime.Now;
        }

        protected override double CalculInteret()
        {
           return Solde / 100 * 4.5;
        }
    }
}
