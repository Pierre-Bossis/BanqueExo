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

        private Dictionary<string, Courant> _comptes = new();

        public Courant? this[string numero]
        {
            get
            {
                Courant? lecompte = null;
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
        public void Ajouter(Courant c)
        {
            if (!_comptes.ContainsKey(c.Numero))
            {
                _comptes.Add(c.Numero, c);
            }
            else
            {
                throw new Exception($"Le compte {c.Numero} est déjà présent!");
            }

        }

    }
}
