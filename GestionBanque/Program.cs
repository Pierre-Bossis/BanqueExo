using GestionBanque.Models;


//utilité : ne pas laisser la liste en free access, chercher seulement des infos spécifique et qu'on connais
//via le numéro de compte ici
Personne p1 = new Personne("Pendragon", "Arthur", DateTime.Now);

Personne p2 = new("Pendragon", "Arthur", DateTime.Now);

Courant c1 = new Courant("BE1234",p1);
c1.Depot(500);


Courant c2 = new Courant("BE56789",p2);
c2.Depot(500.10);

Banque banque = new();
banque.Nom = "Fortis";
Compte.PassageEnNegatifEvent += banque.PassageEnNegatifAction;

Console.WriteLine($"Le solde du compte {c1.Numero} de {c1.Titulaire.Nom} est de {c1.Solde}");

c1.Retrait(200);
Console.WriteLine($"Le solde du compte {c1.Numero} de {c1.Titulaire.Nom} est de {c1.Solde}");
c1.Retrait(500);
Console.WriteLine($"Le solde du compte {c1.Numero} de {c1.Titulaire.Nom} est de {c1.Solde}");

//c1.LigneDeCredit = 500; plus possible suite au passage en private du set
c1.Retrait(1000);
Console.WriteLine($"Le solde du compte {c1.Numero} de {c1.Titulaire.Nom} est de {c1.Solde}");

banque.Ajouter(c1);
banque.Ajouter(c2);

double monArgent = c1 + c2;
Console.WriteLine("Total des avoirs : " + monArgent);

try
{
    banque.Ajouter(c1);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine(banque.AvoirDesComptes(p1));
c1.AppliquerInteret();
//b1.Supprimer(c1.Numero);
//try
//{
//    b1.Supprimer(c1.Numero);
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

//exemple pour récupérer une info voulue
//Console.WriteLine(b1["BE1234"].Solde);