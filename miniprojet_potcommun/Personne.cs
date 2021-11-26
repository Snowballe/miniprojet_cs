using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniprojet_potcommun
{
    class Personne
    {
        public Personne(string prenom, int argentDepense)
        {
            m_Prenom = prenom;
            m_ArgentDepense = argentDepense;
            m_ArgentRecu = 0;
        }

        public string m_Prenom { get; set; }
        public int m_ArgentDepense { get; set; }
        public int m_ArgentRecu { get; set; }

    }
    
}
