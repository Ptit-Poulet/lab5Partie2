using _2230912_2130331_Lab5Partie2.DataAccessLayer.Factories.Base;
using _2230912_2130331_Lab5Partie2.Models;
using MySql.Data.MySqlClient;

namespace _2230912_2130331_Lab5Partie2.DataAccessLayer.Factories
{
    public class CSGPFactory : FactoryBase
    {
        private Cours_session_groupe_prof CreateFromReader(MySqlDataReader mySqlDataReader)
        {
            int id = (int)mySqlDataReader["csgp_id"];
            string etu_codePermanent = mySqlDataReader["csgp_sigle_cours"].ToString();
            int id_session = (int)mySqlDataReader["csgp_id_session"];
            int groupe = (int)mySqlDataReader["csgp_groupe"];
            int id_prof = (int)mySqlDataReader["csgp_id_prof"];

            return new Cours_session_groupe_prof(id, etu_codePermanent, id_session, groupe, id_prof);

        }
        /// <summary>
        /// Retourner la liste des cours enseignés par un enseignant donné
        /// </summary>
        /// <param name="idProf"></param>
        /// <returns></returns>
        private Cours_session_groupe_prof[] GetListCoursSelonEnseignant(int idProf)
        {
            List<Cours_session_groupe_prof> cSGP = new List<Cours_session_groupe_prof>();
            MySqlConnection mySqlCnn = null;
            try
            {
                mySqlCnn = new MySqlConnection(CnnStr);
                mySqlCnn.Open();

                using (MySqlCommand mySqlCmd = mySqlCnn.CreateCommand())
                {
                    mySqlCmd.CommandText = "SELECT c.cou_titre FROM tp5_cours_session_groupe_prof AS t " +
                        "JOIN tp5_cours AS c " +
                        "ON t.csgp_sigle_cours = c.cou_sigle " +
                        "WHERE t.csgp_id_prof = @idProf";

                    mySqlCmd.Parameters.AddWithValue("@idProf", idProf);

                    using (MySqlDataReader mySqlDataReader = mySqlCmd.ExecuteReader())
                    {
                        if (mySqlDataReader.Read())
                        {
                            cSGP.Add(CreateFromReader(mySqlDataReader));
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

            return cSGP.ToArray();
        }
    }
}
