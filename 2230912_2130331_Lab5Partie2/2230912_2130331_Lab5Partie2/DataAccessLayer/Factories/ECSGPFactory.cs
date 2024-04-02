using _2230912_2130331_Lab5Partie2.Models;
using MySql.Data.MySqlClient;

namespace _2230912_2130331_Lab5Partie2.DataAccessLayer.Factories
{
    public class ECSGPFactory
    {
        private Etudiant_coursesessiongroupeprof CreateFromReader(MySqlDataReader mySqlDataReader)
        {
            int id = (int)mySqlDataReader["ecsgp_id"];
            int csgp_id = (int)mySqlDataReader["ecsgp_csgp_id"];
            string etu_codePermanent = mySqlDataReader["ecsgp_etu_codepermanent"].ToString();
            int resultat = (int)mySqlDataReader["ecsgp_resultat"];

            return new Etudiant_coursesessiongroupeprof(id, csgp_id, etu_codePermanent, resultat);

        }
    }
}
