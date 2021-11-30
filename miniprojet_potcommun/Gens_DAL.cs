using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniprojet_potcommun
{
    class Gens_DAL
    {
        public int ID { get; set; }

        public DateTime? m_created_at { get; set; }
        public DateTime? m_updated_at { get; set; }

        public string m_prenom { get; set; }

        public double m_Argent_depense { get; set; }

        public Gens_DAL(int id, DateTime? created_at, DateTime? updated_at, string prenom, double argent)
            => (ID, m_created_at, m_updated_at, m_prenom, m_Argent_depense) = (id, created_at, updated_at, prenom, argent);

        public Gens_DAL(int id, DateTime? created_at, string prenom, double argent)
            => (ID, m_created_at, m_prenom, m_Argent_depense) = (id, created_at, prenom, argent);

        public Gens_DAL(string prenom, double argent)
            => (m_prenom, m_Argent_depense) = (prenom, argent);

        //public List<Point_DAL> Points { get; set; }

        ////public Polygone_DAL(List<Point_DAL> desPoints)
        ////{
        ////    Points = desPoints;            
        ////}

        //public Polygone_DAL(IEnumerable<Point_DAL> desPoint)
        //            => (Points) = (desPoint.ToList());
        //public Polygone_DAL(int id, DateTime? dateCreation, DateTime? dateModification, IEnumerable<Point_DAL> desPoint)
        //            => (ID, DateCreation, DateModification, Points) = (id, dateCreation, dateModification, desPoint.ToList());
    }
}
