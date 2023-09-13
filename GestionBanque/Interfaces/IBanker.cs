using GestionBanque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque.Interfaces
{
    internal interface IBanker : ICustomer
    {
        //Si nous ajoutions la propriété « LigneDeCredit » à « IBanker », définir sur papier les modifications qu’il faudrait apporter à nos classes
        Personne Titulaire { get; }
        string Numero { get; }
        void AppliquerInteret();
    }
}
