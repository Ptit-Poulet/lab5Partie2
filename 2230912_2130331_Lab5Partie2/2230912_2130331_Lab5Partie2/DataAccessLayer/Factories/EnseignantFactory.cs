using _2230912_2130331_Lab5Partie2.DataAccessLayer.Factories.Base;
using _2230912_2130331_Lab5Partie2.Models;
using MySql.Data.MySqlClient;

namespace _2230912_2130331_Lab5Partie2.DataAccessLayer.Factories
{
    public class EnseignantFactory : FactoryBase
    {
        private Enseignant CreateFromReader(MySqlDataReader mySqlDataReader)
        {
            int id = (int)mySqlDataReader["en_id"];
            string nom = mySqlDataReader["en_nom"].ToString();
            string prenom = mySqlDataReader["en_prenom"].ToString();
            int numeroEmploye = (int)mySqlDataReader["en_numero_employe"];
            string dateEmbauche = mySqlDataReader["en_date_embauche"].ToString();
            string dateRetraite = mySqlDataReader["en_date_retraite"].ToString();


            return new Enseignant(id, nom, prenom, numeroEmploye, dateEmbauche, dateRetraite);
        }



        /// <summary>
        /// Permettre de vérifier la présence d'un enseignant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool GetEnseignant(int id)
        {
            bool EstPresent = false;
            MySqlConnection mySqlCnn = null;
            try
            {
                mySqlCnn = new MySqlConnection(CnnStr);
                mySqlCnn.Open();

                using (MySqlCommand mySqlCmd = mySqlCnn.CreateCommand())
                {
                    mySqlCmd.CommandText = "SELECT * FROM h24_web_transac_2230912.tp5_enseignant where en_id= @Id;";

                    mySqlCmd.Parameters.AddWithValue("@Id", id);

                    using (MySqlDataReader mySqlDataReader = mySqlCmd.ExecuteReader())
                    {
                        if (mySqlDataReader.Read())
                        {
                            EstPresent = true;
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

            return EstPresent;
        }

        public int GetIdEnseignantCours(string sigleCours, int idSession)
        {
            int idEnseignant = 1000;
            MySqlConnection mySqlCnn = null;
            try
            {
                mySqlCnn = new MySqlConnection(CnnStr);
                mySqlCnn.Open();

                using (MySqlCommand mySqlCmd = mySqlCnn.CreateCommand())
                {
                    mySqlCmd.CommandText = "SELECT csgp_id_prof FROM h24_web_transac_2230912.tp5_cours_session_groupe_prof " +
                        "where csgp_sigle_cours= @sigleCours and csgp_id_session = @idSession;";

                         mySqlCmd.Parameters.AddWithValue("@sigleCours", sigleCours);
                         mySqlCmd.Parameters.AddWithValue("@idSession", idSession);

                    using (MySqlDataReader mySqlDataReader = mySqlCmd.ExecuteReader())
                    {
                        if (mySqlDataReader.Read())
                        {
                            idEnseignant = Convert.ToInt32(mySqlDataReader["csgp_id_prof"]);
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

            return idEnseignant;
        }

    }
}
