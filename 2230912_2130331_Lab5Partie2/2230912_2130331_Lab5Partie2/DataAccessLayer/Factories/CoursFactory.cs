using _2230912_2130331_Lab5Partie2.DataAccessLayer.Factories.Base;
using _2230912_2130331_Lab5Partie2.Models;
using MySql.Data.MySqlClient;

namespace _2230912_2130331_Lab5Partie2.DataAccessLayer.Factories
{
    public class CoursFactory : FactoryBase
    {
        private Cours CreateFromReader(MySqlDataReader mySqlDataReader)
        {
            string sigle = mySqlDataReader["cou_sigle"].ToString() ?? string.Empty;
            string titre = mySqlDataReader["cou_titre"].ToString() ?? string.Empty;
            int duree = (int)mySqlDataReader["cou_duree"];

            return new Cours(sigle, titre, duree);

        }

        /// <summary>
        /// Permettre de retourner la liste de cours pour un étudiant donné
        /// </summary>
        /// <returns></returns>
        public List<Cours> GetListCoursEtudiant(string codePermanent)
        {
            List<Cours> listCours = new List<Cours>();

            MySqlConnection mySqlCnn = null;
            try
            {
                mySqlCnn = new MySqlConnection(CnnStr);
                mySqlCnn.Open();

                using MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                {
                    mySqlCmd.CommandText = "SELECT  cou_sigle, cou_titre, cou_duree " +
                        " FROM h24_web_transac_2230912.tp5_etudiant_courssessiongroupeprof as ecsgp " +
                        "join h24_web_transac_2230912.tp5_cours_session_groupe_prof as csgp on ecsgp.ecsgp_id = csgp.csgp_id " +
                        "join h24_web_transac_2230912.tp5_cours as c on c.cou_sigle = csgp.csgp_sigle_cours " +
                        "where ecsgp_etu_codepermanent = @codePermanent";


                    mySqlCmd.Parameters.AddWithValue("@codePermanent", codePermanent);

                    using (MySqlDataReader mySqlDataReader = mySqlCmd.ExecuteReader())
                    {
                        while (mySqlDataReader.Read())
                        {
                            listCours.Add(CreateFromReader(mySqlDataReader));
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

            return listCours;
        }


        /// <summary>
        /// Permettre de retourner l’historique des cours suivis pour un étudiant donné
        /// </summary>
        /// <param name="codePermanent"></param>
        /// <returns></returns>
        public List<Cours> GetHistoriqueCoursEtudiant(string codePermanent)
        {
            List<Cours> listCours = new List<Cours>();

            MySqlConnection mySqlCnn = null;
            try
            {
                mySqlCnn = new MySqlConnection(CnnStr);
                mySqlCnn.Open();

                using (MySqlCommand mySqlCmd = mySqlCnn.CreateCommand())
                {
                    mySqlCmd.CommandText = "SELECT cou_sigle, cou_titre, cou_duree " +
                        "FROM h24_web_transac_2230912.tp5_session as s " +
                        "join h24_web_transac_2230912.tp5_cours_session_groupe_prof as csgp on s.se_id = csgp.csgp_id_session " +
                        "join h24_web_transac_2230912.tp5_etudiant_courssessiongroupeprof as ecsgp on ecsgp.ecsgp_csgp_id = csgp.csgp_id " +
                        "join h24_web_transac_2230912.tp5_cours as c on c.cou_sigle = csgp.csgp_sigle_cours " +
                        "where ecsgp_etu_codepermanent = @codePermanent";


                    mySqlCmd.Parameters.AddWithValue("@codePermanent", codePermanent);

                    using (MySqlDataReader mySqlDataReader = mySqlCmd.ExecuteReader())
                    {
                         //bool read = mySqlDataReader.Read(); 
                        while (mySqlDataReader.Read())
                        {
                            listCours.Add(CreateFromReader(mySqlDataReader));
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

            return listCours;
        }



        /// <summary>
        /// Permettre de retourner la liste des cours enseignés par un enseignant donné
        /// </summary>
        /// <param name="idProf"></param>
        /// <returns></returns>
        public List<Cours> GetListCoursSelonEnseignant(int idProf)
        {
            List<Cours> listCoursEnseignant = new List<Cours>();
            MySqlConnection mySqlCnn = null;
            try
            {
                mySqlCnn = new MySqlConnection(CnnStr);
                mySqlCnn.Open();

                using (MySqlCommand mySqlCmd = mySqlCnn.CreateCommand())
                {
                    mySqlCmd.CommandText = "SELECT cou_sigle, cou_titre, cou_duree " +
                        "FROM tp5_cours_session_groupe_prof AS t JOIN tp5_cours AS c " +
                        "ON t.csgp_sigle_cours = c.cou_sigle WHERE t.csgp_id_prof = @idProf";

                    mySqlCmd.Parameters.AddWithValue("@idProf", idProf);

                    using (MySqlDataReader mySqlDataReader = mySqlCmd.ExecuteReader())
                    {
                        while (mySqlDataReader.Read())
                        {
                            listCoursEnseignant.Add(CreateFromReader(mySqlDataReader));
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

            return listCoursEnseignant;
        }
    }
    }
