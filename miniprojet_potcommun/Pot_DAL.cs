using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniprojet_potcommun
{
    class Pot_DAL
    {
        public int ID { get; set; }
        public int ids_participants { get; set; }
        public DateTime? m_created_at { get; set; }
        public DateTime? m_updated_at { get; set; }
        public float argent_totale { get; set; }
        
        public List 
//public Polygone_DAL(IEnumerable<Point_DAL> desPoint)
        //            => (Points) = (desPoint.ToList());
        public Pot_DAL(IEnumerable<Participant> desParticipants)
            => (ids_participants) = (desParticipants.ToList());
        
        public Pot_DAL(int id, , DateTime Created_at, DateTime Updated_at)
            =>(ID, )
    }
}
