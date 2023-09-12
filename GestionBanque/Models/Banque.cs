using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque.Models
{
    public class Banque
    {

        #region Properties
        public string Nom { get; set; }
        #endregion

        private Dictionary<string, Compte> _comptes = new();

        public Compte? this[string numero]
        {
            get
            {
                Compte? lecompte = null;
                if (_comptes.TryGetValue(numero, out lecompte))
                {
                    return lecompte;
                }
                return lecompte; // ou return null
            }
            private set
            {
                _comptes[numero] = value;
            }
        }
        /// <summary>
        /// Permet d'ajouter un compte à la banque
        /// </summary>
        /// <param name="c">Le compte à ajouter <see cref="Courant"/></param>
        /// <exception cref="Exception">Sera lancée si le compte est déjà présent dans la banque</exception>
        public void Ajouter(Compte c)
        {
            if (!_comptes.ContainsKey(c.Numero)) _comptes.Add(c.Numero, c);

            else throw new Exception($"Le compte {c.Numero} est déjà présent!");

        }

        public void Supprimer(string numero)
        {
            if (_comptes.ContainsKey(numero)) _comptes.Remove(numero);

            else throw new Exception($"Le compte {numero} n'existe pas !");
        }

        public double AvoirDesComptes(Personne titulaire)
        {
            double res = 0;
            foreach (Courant item in _comptes.Values)
            {
                if(titulaire.Nom == item.Titulaire.Nom)
                {
                    res = (item + res);
                }
            }
            return res;
        }
    }
}
