using System;
using System.Collections.Generic;

namespace miniprojet_potcommun
{
    internal class Program : Personne
    {
        public static void Main(string[] args)
        {
            Personne p = new Personne();
            Console.WriteLine("Bonjour et bienvenue sur CommuMoney ! Qui participera au projet ? (ctrl pour quitter, alt pour finir)");

            string[] participants=new string[64];
            

                for (int k = 0; k < 64; k++)
                {
                    Console.WriteLine("Nom numéro {0}", k + 1);
                    participants[k] = (Console.ReadLine());
                }

            
            
            
        }
    }
}