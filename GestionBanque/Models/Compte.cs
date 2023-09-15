using GestionBanque.Exceptions;
using GestionBanque.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque.Models
{
    public abstract class Compte :  IBanker, ICustomer
    {
        #region Private Fields
        protected double _solde;
        #endregion

        #region Events
        //public delegate void PassageEnNegatifDelegate(Compte compte);

        public static event Action<Compte> PassageEnNegatifEvent = null;

        #endregion

        #region Props
        public string Numero { get; private set; }
        public virtual double Solde
        {
            get { return _solde; }
            private set
            {
                _solde = value;
            }
        }
        public Personne Titulaire { get; private set; }

        #endregion

        #region Abstract
        //public abstract double LigneDeCredit { get; set; }  
        #endregion

        #region Constructors
        public Compte(string numero, Personne titulaire)
        {
            Numero = numero;
            Titulaire = titulaire;
        }
        public Compte(string numero, Personne titulaire, double solde) : this(numero, titulaire)
        {
            Solde = solde;
        }
        #endregion

        #region Methods

        protected void TakeEvent()
        {
            PassageEnNegatifEvent?.Invoke(this);
            // ou alors 
            /*if(PassageEnNegatifEvent != null)
            {
                PassageEnNegatifEvent(this);
            }*/
        }

        public virtual void Retrait(double montant)
        {
            if (montant < 0) throw new Exception("Montant doit etre positif");
            if (montant > Solde) /*throw*/ new SoldeInsuffisantException("Le solde est insuffisant");
            Solde -= montant;

        }

        public virtual void Depot(double montant)
        {
            if(montant < 0) throw new ArgumentOutOfRangeException("Montant doit être positif");
                Solde += montant;
        }

        public static double operator +(Compte c, double m)
        {
            return (c.Solde > 0 ? c.Solde : 0) + m;
        }

        protected abstract double CalculInteret();

        public void AppliquerInteret()
        {
            Solde += CalculInteret();
            Console.WriteLine(Solde);
        } 
        #endregion
    }
}
