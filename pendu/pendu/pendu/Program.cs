using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace penduCsharp
{
    class Pendu
    {
        private readonly char[] alphabet = {
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};

        bool existe;
        bool dispo;
        string mot = "chaton";




        //check si dans la lettre du user est bien dans le mot mystere 
        //et renvoie le mot comprenant les lettres juste les lettres fausse reste des etoiles (*)
        public string DecouvreLeMot(string mot, char lettreUser, string motEtoile)
        {

            StringBuilder etoile = new StringBuilder(motEtoile);
            StringBuilder ind = new StringBuilder(mot);

            for (int i = 0; i < motEtoile.Length; i++)
            {
                if (ind[i].Equals(lettreUser))
                {
                    etoile[i] = lettreUser;
                    motEtoile = etoile.ToString();

                }
            }
            return motEtoile;
        }

        /* verifie si le mot contient la lettre du user et 
         * retourne existe true ou false
         */
        public bool DansLeMot(char lettre, string mot)

        {
            foreach (var lettres in mot)
            {
                existe = mot.Contains(lettre) ? true : false;
            }
            return existe;
        }

        /* enleve la lettre du user des lettres dispo alpha
         * si elle est dispo retourne true / sinon retourne false
         * renvoi l'alpha modifié*/

        public List<char> RemoveLettre(char lettre, List<char> alpha)

        {
            try
            {
                int i = alpha.IndexOf(lettre);
                alpha.Remove(alpha[i]);

                dispo = true;
            }
            catch (ArgumentOutOfRangeException)
            {



                dispo = false;
            }

            return alpha;
        }


        public static void Main(string[] args)
        {

            var Pendu = new Pendu();
            var alpha = new List<char>(Pendu.alphabet);

            bool ContinuerPartie = true;

            string motEtoile = new string('*', Pendu.mot.Length);
            int vie = 5;



            while (ContinuerPartie == true && vie > 0 && motEtoile != Pendu.mot)
            {


                Console.Write("\n\n\n\n\n\n " +
                                            "##################################################"+
                                       "\n        Voici le mot mystere a trouver  => {0}    "+
                                        "\n##################################################" , motEtoile);
                Console.WriteLine("\n >>>> Les lettres disponibles sont :");

                alpha.ForEach(i => Console.Write("{0}", i));

                Console.WriteLine("\n >>>> \n Veuillez entrer une lettre :");


                char lettreUser = Console.ReadKey().KeyChar;
                Pendu.RemoveLettre(lettreUser, alpha);

                if (Pendu.dispo == true)
                {

                    Pendu.DansLeMot(lettreUser, Pendu.mot);

                    if (Pendu.existe)
                    {

                        motEtoile = Pendu.DecouvreLeMot(Pendu.mot, lettreUser, motEtoile);
                        Console.WriteLine("\n >>>>>>>> {0} <<<<<<<<<<" ,motEtoile);

                        if (Pendu.mot == motEtoile)
                        {
                            Console.WriteLine("bravooooooooooooooooo!!!!");
                        }
                    }
                    else
                    {

                        vie--;
                        Console.Write(" \n #################################################\n" +
                                                       "# Il vous reste {0} vie(s) disponible pour trouver le mot # " +
                                                   "\n #################################################\n ", vie);
                    }

                }
                else
                {
                    Console.WriteLine("\n la lettre à deja ete utilisée");


                }


            }
        }
    }
}