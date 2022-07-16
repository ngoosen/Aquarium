using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSharquarium
{
    public enum Sexe { Mâle, Femelle};
    internal class Aquarium
    {
        public string Nom { get; set; }
        public List<IPoisson> Poissons { get; set; }
        public List<Algue> Algues { get; set; }

        // Ctor

        public Aquarium()
        {
            Poissons = new List<IPoisson>();
            Algues = new List<Algue>();
        }
        public Aquarium(string nom) : this()
        {
            Nom = nom;
        }

        // Méthodes
        public void AjouterPoisson(IPoisson p)
        {
            Poissons.Add(p);
        }

        public void AjouterAlgue()
        {
            Algue algue = new Algue();
            Algues.Add(algue);
        }
        public void AjouterAlgue(int nb)
        {
            for(int i = 0; i < nb; i++)
            {
                AjouterAlgue();
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public List<string> Inventaire() // Ecrire dans la console le nombre de résidents et énumérer leurs caractéristiques (algues et poisson séparés)
        {
            List<string> inventaire = new();
            inventaire.Add($"\nAlgues: {Algues.Count()} résidents");
            int index = 0;
            foreach (Algue a in Algues)
            {
                inventaire.Add($"{++index} - Une algue: {a.Age} ans - {a.PV} PV");
            }
            index = 0;
            inventaire.Add("------------------------");
            inventaire.Add($"Poissons: {Poissons.Count()} résidents");
            foreach (IPoisson p in Poissons)
            {
                inventaire.Add($"{++index} - {p.Nom}: {p.GetRace()} - {p.Sexe} - {p.Age} ans - {p.PV} PV");
            }
            return inventaire;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public List<string> Editer() // Ajouter via la console des algues ou des poissons
        {
            List<string> edit = new();
            int choix = 0;
            while (choix != 5)
            {
                Console.WriteLine("Que voulez-vous faire?");
                Console.WriteLine("1 - Ajouter un poisson");
                Console.WriteLine("2 - Ajouter une algue");
                Console.WriteLine("3 - Ajouter des résidents via un fichier texte");
                Console.WriteLine("4 - Retirer un résident");
                Console.WriteLine("5 - J'ai terminé!");

                if (int.TryParse(Console.ReadLine(), out choix))
                {
                    switch (choix)
                    {
                        case 1:
                            Console.WriteLine("Comment-souhaitez-vous appeler votre poisson?"); // Nom
                            string nom = Console.ReadLine();

                            Console.WriteLine("Quel âge a votre poisson?"); // Âge
                            int choixAge;
                            while (!int.TryParse(Console.ReadLine(), out choixAge))
                            {
                                Console.WriteLine("Veuillez entrer un chiffre valable!");
                            }

                            Console.WriteLine("Quel est le sexe de votre poisson? 1 - Mâle ou 2 - Femelle"); // Sexe
                            int choixSexe;
                            while (!int.TryParse(Console.ReadLine(), out choixSexe))
                            {
                                Console.WriteLine("Veuillez entrer un chiffre valable!");
                            }
                            Sexe sexe = (choixSexe == 1) ? Sexe.Mâle : Sexe.Femelle;

                            Console.WriteLine("Enfin, quelle est la race de votre poisson?"); // Race
                            Console.WriteLine("1 - Bar");
                            Console.WriteLine("2 - Carpe");
                            Console.WriteLine("3 - Mérou");
                            Console.WriteLine("4 - Poisson-clown");
                            Console.WriteLine("5 - Sole");
                            Console.WriteLine("6 - Thon");

                            int choixRace;

                            while (!int.TryParse(Console.ReadLine(), out choixRace))
                            {
                                Console.WriteLine("Veuillez entrer un chiffre valable!");
                            }

                            IPoisson nouveauPoisson; // Création du poisson

                            switch (choixRace)
                            {
                                case 1:
                                    nouveauPoisson = new Bar(nom, choixAge, sexe);
                                    break;
                                case 2:
                                    nouveauPoisson = new Carpe(nom, choixAge, sexe);
                                    break;
                                case 3:
                                    nouveauPoisson = new Merou(nom, choixAge, sexe);
                                    break;
                                case 4:
                                    nouveauPoisson = new PoissonClown(nom, choixAge, sexe);
                                    break;
                                case 5:
                                    nouveauPoisson = new Sole(nom, choixAge, sexe);
                                    break;
                                case 6:
                                    nouveauPoisson = new Thon(nom, choixAge, sexe);
                                    break;
                                default:
                                    nouveauPoisson = new Carpe(nom, choixAge, sexe);
                                    break;
                            }
                            Poissons.Add(nouveauPoisson);            // Ajout du poisson dans la liste et confirmation
                            Console.WriteLine("Votre poisson a bien été ajouté!");
                            Console.WriteLine($"{nouveauPoisson.Nom}: {nouveauPoisson.GetRace()} - {nouveauPoisson.Sexe} - {nouveauPoisson.Age} ans - {nouveauPoisson.PV} PV");
                            edit.Add("Votre poisson a bien été ajouté!");
                            edit.Add($"{nouveauPoisson.Nom}: {nouveauPoisson.GetRace()} - {nouveauPoisson.Sexe} - {nouveauPoisson.Age} ans - {nouveauPoisson.PV} PV\n");

                            break;
                        case 2:
                            Console.WriteLine("Combien d'algues souhaitez-vous ajouter?");
                            int nbAlguesAAjouter;
                            while (!int.TryParse(Console.ReadLine(), out nbAlguesAAjouter))
                            {
                                Console.WriteLine("Veuillez entrer un nombre valide!");
                            }
                            AjouterAlgue(nbAlguesAAjouter);
                            Console.WriteLine(nbAlguesAAjouter + " algues ont poussé!");
                            edit.Add(nbAlguesAAjouter + " algues ont poussé!");
                            break;
                        case 4:
                            Console.WriteLine("Si vous souhaitez retirer une algue, tapez 1.");
                            Console.WriteLine("Si vous souhaitez retirer un poisson, tapez 2");

                            int poissonOuAlgue;
                            while (!int.TryParse(Console.ReadLine(), out poissonOuAlgue))
                            {
                                Console.WriteLine("Veuillez entrer un chiffre valide!");
                            }

                            Console.WriteLine("Entrez le numéro du résident à retirer");
                            int indexARetirer;

                            while (!int.TryParse(Console.ReadLine(), out indexARetirer))
                            {
                                Console.WriteLine("Veuillez entrez un nombre valide!");
                            }

                            if (poissonOuAlgue == 1 && Algues.Count() >= indexARetirer)
                            {
                                Algues.RemoveAt(indexARetirer - 1);
                                Console.WriteLine("L'algue a été retirée de l'aquarium!");
                                edit.Add("L'algue a été retirée de l'aquarium!");
                            }
                            else if (poissonOuAlgue == 2 && Poissons.Count() >= indexARetirer)
                            {
                                string nomDuPoissonARetirer = Poissons[indexARetirer - 1].Nom;
                                Poissons.RemoveAt(indexARetirer - 1);
                                Console.WriteLine(nomDuPoissonARetirer + " a été retiré.e de l'aquarium!");
                                edit.Add(nomDuPoissonARetirer + " a été retiré.e de l'aquarium!");
                            }
                            else Console.WriteLine("Veuillez entrer un nombre valide.");

                            break;
                        case 3:                                                                //////// Editer via un fichier texte
                            Console.WriteLine("Veuillez entrer le nom du fichier");
                            string fileName = Console.ReadLine();

                            try
                            {
                                StreamReader sr = new StreamReader($"C:\\CSharquariumSaves\\{fileName}.txt");       // Attention au chemin

                                while (!sr.EndOfStream)
                                {
                                    string line = sr.ReadLine();

                                    if (int.TryParse(line[0].ToString(), out int chiffre1))
                                    {
                                        string[] split = line.Split(" ");

                                        int nbAlgues = int.Parse(split[0]);
                                        int ageAlgues = int.Parse(split[2]);

                                        for (int i = 0; i < nbAlgues; i++)
                                        {
                                            Algue a = new Algue(ageAlgues, 5);
                                            Algues.Add(a);
                                            Console.WriteLine($"Une algue de {a.Age} ans a été ajoutée!");
                                            edit.Add($"Une algue de {a.Age} ans a été ajoutée!");
                                        }
                                    }
                                    else
                                    {
                                        string[] split = line.Split(", ");

                                        string nomPoisson = split[0];
                                        string racePoisson = split[1];

                                        string[] decoupAge = split[2].Split(" ");
                                        int agePoisson = int.Parse(decoupAge[0]);
                                        Sexe sexePoisson = (new Random()).Next(0, 2) == 1 ? Sexe.Mâle : Sexe.Femelle;

                                        IPoisson p;

                                        switch (racePoisson)
                                        {
                                            case "Bar":
                                                p = new Bar(nomPoisson, agePoisson, sexePoisson);
                                                break;
                                            case "Carpe":
                                                p = new Carpe(nomPoisson, agePoisson, sexePoisson);
                                                break;
                                            case "Mérou":
                                                p = new Merou(nomPoisson, agePoisson, sexePoisson);
                                                break;
                                            case "Poisson-clown":
                                                p = new PoissonClown(nomPoisson, agePoisson, sexePoisson);
                                                break;
                                            case "Sole":
                                                p = new Sole(nomPoisson, agePoisson, sexePoisson);
                                                break;
                                            case "Thon":
                                                p = new Thon(nomPoisson, agePoisson, sexePoisson);
                                                break;
                                            default:
                                                p = new Bar(nomPoisson, agePoisson, sexePoisson);
                                                break;
                                        }

                                        Poissons.Add(p);
                                        Console.WriteLine($"{p.Nom} - {p.GetRace()} - {p.Sexe} - {p.Age} ans a été ajouté.e!");
                                        edit.Add($"{p.Nom} - {p.GetRace()} - {p.Sexe} - {p.Age} ans a été ajouté.e!\n");
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("\nErreur: fichier introuvable!");
                                Console.WriteLine("Vérifiez que vous avez bien entré le nom de fichier correct (sans l'extension .txt).\n");
                            }
                            break;
                        case 5:
                            Console.WriteLine("Bloup!");
                            break;
                    }
                }
                else Console.WriteLine("Veuillez entrer un chiffre valide!");
            }
            Console.WriteLine("Compris! Souhaitez-vous voir l'inventaire? 1 - Oui   2- Non");
            if (int.TryParse(Console.ReadLine(), out int inventaireOuPas))
            {
                if (inventaireOuPas == 1)
                {
                    foreach(string s in Inventaire())
                    {
                        Console.WriteLine(s);
                        edit.Add(s);
                    }
                }
            }
            else Console.WriteLine("Ok, la nuit va passer!");
            return edit;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public List<string> DinerTime() // Parcourir la liste des poissons et nourrir ceux qui ont faim
        {
            List<string> miam = new();
            Random randomNumber = new Random();
            List<IPoisson> listeMorts = new List<IPoisson>();

            foreach (IPoisson p in Poissons)
            {
                if (!listeMorts.Contains(p) && p.PV <= 5)
                { 
                    if (p is Carnivore)
                    {
                        int i = randomNumber.Next(0, Poissons.Count());

                        while (listeMorts.Contains(Poissons[i]))
                        {
                            i = randomNumber.Next(0, Poissons.Count());
                        }

                        if (p.GetRace() == Poissons[i].GetRace() && p != Poissons[i])
                        {
                            miam.Add($"{p.Nom} a attaqué {Poissons[i].Nom}! {Poissons[i].Nom} perd 4 PV.");
                            Poissons[i].PV -= 4;
                        }
                        else if (p.GetRace() != Poissons[i].GetRace())
                        {
                            miam.Add($"{p.Nom} a mangé {Poissons[i].Nom}! {Poissons[i].Nom} a été retiré.e de l'aquarium.");
                            p.Manger(Poissons[i]);
                            listeMorts.Add(Poissons[i]);
                        }
                    }
                    else
                    {
                        int i = randomNumber.Next(0, Algues.Count());
                        p.Manger(Algues[i]);
                    }
                }
            }
            foreach(IPoisson p in listeMorts)
            {
                Poissons.Remove(p);
            }
            return miam;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public string Prenom(Sexe sexe)
        {
            List<string> prenomsF = new List<string>() { "Joséphine", "Nathalie", "Julia", "Catherine", "Coralie", "Sophie", "Clémence", "Lorie", "Marjorie", "Johanna", "Karen", "Sabrina", "Gaëlle", "Sigrid", "Caroline" };
            List<string> prenomsM = new List<string>() { "Charles", "Harry", "Aurélien", "Nicolas", "Sébastien", "Dimitri", "Victor", "Martin", "Claude", "Fabien", "Jules", "Laurent", "Michael", "Francis", "Lucas" };
            if(sexe == Sexe.Femelle) return prenomsF[(new Random()).Next(0, prenomsF.Count())];
            else return prenomsM[(new Random()).Next(0, prenomsF.Count())];
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public List<string> Reproduction()  // Gestion de la reproduction pour les poissons et les algues
        {
            List<string> laReproduction = new();
            List<Algue> listeBebesAlgues = new();
            List<IPoisson> listeBebesPoissons = new();

            foreach (Algue a in Algues)  // Reproduction des algues
            {
                if(a.PV >= 10)
                {
                    Algue nouvelleAlgue = new Algue(5);
                    a.PV = 5;
                    listeBebesAlgues.Add(nouvelleAlgue);
                    laReproduction.Add("Une algue a poussé!");
                }
            }
            foreach (IPoisson p in Poissons)   // Reproduction des poissons
            {
                if(p.PV > 5)
                {
                    int randomNumber = (new Random()).Next(0, Poissons.Count());

                    if (p.SeReproduire(Poissons[randomNumber]))
                    {
                        Sexe sexeRandom = ((new Random()).Next(0, 2) == 1) ? Sexe.Mâle : Sexe.Femelle;

                        laReproduction.Add($"Un.e {p.GetRace()} {sexeRandom} est né.e!");
                        string nomNouveauPoisson = Prenom(sexeRandom);

                        IPoisson bebePoisson;

                        switch (p.GetRace())
                        {
                            case "Bar":
                                bebePoisson = new Bar(nomNouveauPoisson, 0, sexeRandom);
                                break;
                            case "Carpe":
                                bebePoisson = new Carpe(nomNouveauPoisson, 0, sexeRandom);
                                break;
                            case "Mérou":
                                bebePoisson = new Merou(nomNouveauPoisson, 0, sexeRandom);
                                break;
                            case "Poisson-clown":
                                bebePoisson = new PoissonClown(nomNouveauPoisson, 0, sexeRandom);
                                break;
                            case "Sole":
                                bebePoisson = new Sole(nomNouveauPoisson, 0, sexeRandom);
                                break;
                            case "Thon":
                                bebePoisson = new Thon(nomNouveauPoisson, 0, sexeRandom);
                                break;
                            default:
                                bebePoisson = new Bar(nomNouveauPoisson, 0, sexeRandom);
                                break;
                        }
                        listeBebesPoissons.Add(bebePoisson);
                        laReproduction.Add($"{bebePoisson.Nom} : {bebePoisson.Sexe} - {bebePoisson.Age} ans - {bebePoisson.PV} a été ajouté.e à l'aquarium.\n");
                    }
                }
            }
            foreach(Algue bebe in listeBebesAlgues)
            {
                Algues.Add(bebe);
            }
            foreach(IPoisson bebe in listeBebesPoissons)
            {
                Poissons.Add(bebe);
            }
            return laReproduction;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public List<string> PasserNuit() // Passer la nuit: gestion des morts et des PV
                                 //     Gérer les Hermaphrodites avec l'âge, Reproduction, DinerTime puis état des lieux avec Inventaire.
                                 //     Permet aussi d'ajouter de nouveaux résidents via Editer
        {
            List<string> laNuitPasse = new();
            List<Algue> listeMortsAlgues = new();
            List<IPoisson> listeMortsPoissons = new();

            ///// Age ++, PV-- et gestion des morts /////
            foreach (Algue a in Algues)
            {
                a.Age++;
                a.PV++;

                if(a.PV <= 0)
                {
                    listeMortsAlgues.Add(a);
                    laNuitPasse.Add("Une algue est morte!");
                }
                else if (a.Age >= 20)
                {
                    listeMortsAlgues.Add(a);
                    laNuitPasse.Add("Une algue est morte de vieillesse!");
                }
            }
            foreach(IPoisson p in Poissons)
            {
                p.Age++;
                p.PV--;

                if(p.PV <= 0)
                {
                    listeMortsPoissons.Add(p);
                    laNuitPasse.Add(p.Nom + " est mort.e de faim!");
                }
                else if (p.Age >= 20)
                {
                    listeMortsPoissons.Add(p);
                    laNuitPasse.Add(p.Nom + " est mort.e de vieillesse!");
                }
                if(p.Age == 10 && (p is Bar || p is Merou))      // Gestion Hermaphrodites avec l'âge
                {
                    p.Sexe = (p.Sexe == Sexe.Mâle) ? Sexe.Femelle : Sexe.Mâle;
                }
            }
            foreach(Algue algueRetiree in listeMortsAlgues)
            {
                Algues.Remove(algueRetiree);
            }
            foreach(IPoisson poissonRetire in listeMortsPoissons)
            {
                Poissons.Remove(poissonRetire);
            }

            ///// Reproduction et DinerTime //////
            
            foreach(string s in Reproduction())
            {
                laNuitPasse.Add(s);
            }

            foreach(string s in DinerTime())
            {
                laNuitPasse.Add(s);
            }

            //Retirer les algues mortes après DinerTime
            List<Algue> algueARetirer = new();
            foreach(Algue a in Algues)
            {
                if(a.PV <= 0)
                {
                    algueARetirer.Add(a);
                }
            }
            foreach(Algue a in algueARetirer)
            {
                Algues.Remove(a);
            }
            if(algueARetirer.Count() > 1)
            {
                Console.WriteLine($"{algueARetirer.Count()} algues ont été mangées! Souhaitez-vous en ajouter de nouvelles?");
                Console.WriteLine("Entrez un nombre d'algues à ajouter, si vous ne souhaitez pas en ajouter, entrez simplement zéro.");

                int nbAlguesAAjouter;
                while (!int.TryParse(Console.ReadLine(), out nbAlguesAAjouter))
                {
                    Console.WriteLine("Veuillez entrer un chiffre valide!");
                }
                AjouterAlgue(nbAlguesAAjouter);
            }

            ///// Inventaire et edit /////
            
            foreach(string s in Inventaire())
            {
                laNuitPasse.Add(s);
            }

            if(Poissons.Count() < 10)
            {
                Console.WriteLine("Attention! Il reste moins de 10 poissons dans l'aquarium! Voulez-vous ajouter de nouveaux poissons? 1- Oui ou 2 - Non");

                int ajouterOuPas;

                while(!int.TryParse(Console.ReadLine(), out ajouterOuPas))
                {
                    Console.WriteLine("Veuillez entrer un chiffre valide!");
                }

                if (ajouterOuPas == 1)
                {
                    foreach(string s in Editer())
                    {
                        laNuitPasse.Add(s);
                    }
                }
            }
            if(Poissons.Count() > 36 || Algues.Count() > 18)
            {
                Console.WriteLine("Attention! Vous avez atteint la capacité maximale de l'aquarium (36 poissons et 18 algues max) ! Veuillez modifier votre aquarium!");
                foreach (string s in Editer())
                {
                    laNuitPasse.Add(s);
                }
            }
            else if (Algues.Count() < 2)
            {
                Console.WriteLine("Attention! Il ne reste qu'une algue dans l'aquarium! Voulez-vous ajouter de nouvelles algues? 1 - Oui ou 2 - Non");

                int ajouterOuPas;

                while (!int.TryParse(Console.ReadLine(), out ajouterOuPas))
                {
                    Console.WriteLine("Veuillez entrer un chiffre valide!");
                }

                Console.WriteLine("Combien d'algues souhaitez-vous ajouter?");
                int nbAlgues;
                while(!int.TryParse(Console.ReadLine(), out nbAlgues))
                {
                    Console.WriteLine("Veuillez entrer un nombre valide!");
                }
                AjouterAlgue(nbAlgues);
                laNuitPasse.Add(nbAlgues + " algues ont été ajoutées!");
            }

            laNuitPasse.Add("Fin de la nuit!\n");
            return laNuitPasse;
        }
    }
}