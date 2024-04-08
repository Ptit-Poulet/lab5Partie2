using _2230912_2130331_Lab5Partie2.DataAccessLayer.Factories.Base;
using _2230912_2130331_Lab5Partie2.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace _2230912_2130331_Lab5Partie2.DataAccessLayer.Factories
{
    public class CoursResultatFactory : FactoryBase
    {
        private CoursResultat CreateFromReader(MySqlDataReader mySqlDataReader)
        {
            string sigle = mySqlDataReader["cou_sigle"].ToString() ?? string.Empty;
            string titre = mySqlDataReader["cou_titre"].ToString() ?? string.Empty;
            int duree = (int)mySqlDataReader["cou_duree"];
            string resultat = mySqlDataReader["ecsgp_resultat"].ToString() ?? string.Empty;

            Cours cours = new Cours(sigle, titre, duree);

            return new CoursResultat(cours, resultat);
        }


        /// <summary>
        /// retourner « le bulletin » des cours suivis pour un étudiant donné
        /// </summary>
        /// <param name="codePermanent"></param>
        /// <returns></returns>
        public List<CoursResultat> GetBulletin(string codePermanent)
        {
            List<CoursResultat> coursResultats = new List<CoursResultat>();

            MySqlConnection mySqlCnn= null;
            try
            {
                mySqlCnn = new MySqlConnection(CnnStr);
                mySqlCnn.Open();

                using MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                {
                    mySqlCmd.CommandText = "SELECT cou_sigle, cou_titre, cou_duree, ecsgp_resultat " +
                        "FROM h24_web_transac_2230912.tp5_session as s join h24_web_transac_2230912.tp5_cours_session_groupe_prof as csgp " +
                        "on s.se_id = csgp.csgp_id_session join h24_web_transac_2230912.tp5_etudiant_courssessiongroupeprof as ecsgp " +
                        "on ecsgp.ecsgp_csgp_id = csgp.csgp_id join h24_web_transac_2230912.tp5_cours as c " +
                        "on c.cou_sigle = csgp.csgp_sigle_cours where ecsgp_etu_codepermanent = @codePermanent";

                    mySqlCmd.Parameters.AddWithValue("@codePermanent", codePermanent);

                    using (MySqlDataReader mySqlDataReader = mySqlCmd.ExecuteReader()) 
                    {
                        while (mySqlDataReader.Read())
                        {
                            coursResultats.Add(CreateFromReader(mySqlDataReader));
                        }

                        mySqlDataReader.Close();
                    }
                }
            }
            finally
            {
                if (mySqlCnn != null)
                {
                    mySqlCnn.Close();
                }
            }

            return coursResultats;  
        }
    }
}
