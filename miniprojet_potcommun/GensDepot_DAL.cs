using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniprojet_potcommun
{
    class GensDepot_DAL
    {
        public override List<Gens_DAL> GetAll()
        {
            dbConnect();

            commande.CommandText = "select ID, dateCreation, dateModification from Polygones";
            var reader = commande.ExecuteReader();

            var depotPoint = new PointDepot_DAL();

            var listePolygone = new List<Polygone_DAL>();

            while (reader.Read())
            {
                var points = depotPoint.GetAllByIDPolygone(reader.GetInt32(0));

                var p = new Polygone_DAL(reader.GetInt32(0),
                                        reader.GetDateTime(1),
                                        reader.GetSqlDateTime(2).IsNull ? null : reader.GetDateTime(2),
                                        points);

                listePolygone.Add(p);
            }

            DetruireConnexionEtCommande();

            return listePolygone;
        }

        public override Polygone_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select ID, dateCreation, dateModification from Polygones where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            var depotPoint = new PointDepot_DAL();

            Polygone_DAL p;

            if (reader.Read())
            {
                var points = depotPoint.GetAllByIDPolygone(reader.GetInt32(0));

                p = new Polygone_DAL(reader.GetInt32(0),
                                        reader.GetDateTime(1),
                                        reader.GetSqlDateTime(2).IsNull ? null : reader.GetDateTime(2),
                                        points);
            }
            else
            {
                throw new Exception($"Pas de polygone avec l'ID {ID}");
            }

            DetruireConnexionEtCommande();

            return p;
        }

        public override Polygone_DAL Insert(Polygone_DAL poly)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into Polygones(dateCreation)"
                                    + " values (GetDate()); select scope_identity()";
            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            poly.DateCreation = GetByID(ID).DateCreation;

            DetruireConnexionEtCommande();

            var depotPoint = new PointDepot_DAL();
            foreach (var item in poly.Points)
            {
                item.IDPolygone_DAL = ID;
                depotPoint.Insert(item);
            }

            return poly;
        }

        public override Polygone_DAL Update(Polygone_DAL poly)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update Polygones set dateModification=getDate() where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", poly.ID));

            var nbLignes = (int)commande.ExecuteNonQuery();

            if (nbLignes != 1)
            {
                throw new Exception($"Impossible de mettre à jour le polygone d'ID {poly.ID}");
            }

            poly.DateModification = GetByID(poly.ID).DateModification;

            DetruireConnexionEtCommande();

            var depotPoint = new PointDepot_DAL();
            foreach (var item in poly.Points)
            {
                depotPoint.Update(item);
            }

            return poly;
        }

        public override void Delete(Polygone_DAL poly)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update Polygones set dateModification=getDate() where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", poly.ID));

            var nbLignes = (int)commande.ExecuteNonQuery();

            if (nbLignes != 1)
            {
                throw new Exception($"Impossible de supprimer le polygone d'ID {poly.ID}");
            }

            DetruireConnexionEtCommande();
        }
    }
}
