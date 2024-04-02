using _2230912_2130331_Lab5Partie2.DataAccessLayer.Factories.Base;
using _2230912_2130331_Lab5Partie2.Models;
using MySql.Data.MySqlClient;

namespace _2230912_2130331_Lab5Partie2.DataAccessLayer.Factories
{
    public class ECSGPFactory : FactoryBase
    {
        private Etudiant_coursesessiongroupeprof CreateFromReader(MySqlDataReader mySqlDataReader)
        {
            int id = (int)mySqlDataReader["ecsgp_id"];
            int csgp_id = (int)mySqlDataReader["ecsgp_csgp_id"];
            string etu_codePermanent = mySqlDataReader["ecsgp_etu_codepermanent"].ToString();
            int resultat = (int)mySqlDataReader["ecsgp_resultat"];

            return new Etudiant_coursesessiongroupeprof(id, csgp_id, etu_codePermanent, resultat);

        }
        /// <summary>
        /// Retourner « le bulletin » des cours suivis pour un étudiant donné
        /// </summary>
        /// <param name="codePermanent"></param>
        /// <returns></returns>
        public Etudiant_coursesessiongroupeprof[] GetResultatSelonetudiant(string codePermanent)
        {
            List<Etudiant_coursesessiongroupeprof> eCSGP = new List<Etudiant_coursesessiongroupeprof>();
            MySqlConnection mySqlCnn = null;
            try
            {
                mySqlCnn = new MySqlConnection(CnnStr);
                mySqlCnn.Open();

                using (MySqlCommand mySqlCmd = mySqlCnn.CreateCommand())
                {
                    mySqlCmd.CommandText = "SELECT ecsgp_resultat FROM tp5_etudiant_courssessiongroupeprof WHERE ecsgp_etu_codepermanent = @codePermanent";
                    mySqlCmd.Parameters.AddWithValue("@codePermanent", codePermanent);

                    using (MySqlDataReader mySqlDataReader = mySqlCmd.ExecuteReader())
                    {
                        if (mySqlDataReader.Read())
                        {
                            eCSGP.Add(CreateFromReader(mySqlDataReader));
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

            return eCSGP.ToArray();
        }
    }
}
