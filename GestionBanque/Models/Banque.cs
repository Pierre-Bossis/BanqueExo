using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque.Models
{
    public class Banque
    {
        #region Private Fields
        private string _nom;
        #endregion

        #region Properties
        public string Nom
		{
			get { return _nom; }
			set { _nom = value; }
		}
        #endregion
        //test
        //Un indexeur retournant un compte sur base de son numéro
        public Dictionary<string, Courant> indexor = new();
        //clé = numéro de compte
        //valeur = la personne

        public void Ajouter(Courant compte)
        {
            indexor.Add(compte.Numero, compte);
            Console.WriteLine("Compte ajouté");
        }

        public void Supprimer(string numero)
        {
            indexor.Remove(numero);
            Console.WriteLine("Compte supprimé");
        }

    }
}
