using _2230912_2130331_Lab5Partie2.DataAccessLayer.Factories.Base;
using _2230912_2130331_Lab5Partie2.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

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

        /// <summary>
        /// Permettre de vérifier la présence d'un cours
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool GetCours(int id)
        {
            bool EstPresent = false;
            MySqlConnection mySqlCnn = null;
            try
            {
                mySqlCnn = new MySqlConnection(CnnStr);
                mySqlCnn.Open();

                using (MySqlCommand mySqlCmd = mySqlCnn.CreateCommand())
                {
                    mySqlCmd.CommandText = "SELECT * FROM h24_web_transac_2230912.tp5_cours_session_groupe_prof WHERE csgp_id = @Id";

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

        /// <summary>
        /// Permet de vérifier si un cours(existe) a été donné à une session particulière
        /// </summary>
        /// <param name="sigle"></param>
        /// <param name="idSession"></param>
        /// <returns></returns>
        public bool GetCours(string sigleCours, int idSession)
        {
            bool EstPresent = false;
            MySqlConnection mySqlCnn = null;
            try
            {
                mySqlCnn = new MySqlConnection(CnnStr);
                mySqlCnn.Open();

                using (MySqlCommand mySqlCmd = mySqlCnn.CreateCommand())
                {

                    mySqlCmd.CommandText = "SELECT * FROM h24_web_transac_2230912.tp5_cours_session_groupe_prof " +
                        "WHERE csgp_sigle_cours = @sigle and csgp_id_session = @idSession";

                    mySqlCmd.Parameters.AddWithValue("@sigle", sigleCours);
                    mySqlCmd.Parameters.AddWithValue("@idSession", idSession);


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


        public bool GetCoursSelonSigle(string sigleCours)
        {
            bool EstPresent = false;
            MySqlConnection mySqlCnn = null;
            try
            {
                mySqlCnn = new MySqlConnection(CnnStr);
                mySqlCnn.Open();

                using (MySqlCommand mySqlCmd = mySqlCnn.CreateCommand())
                {
                    mySqlCmd.CommandText = "SELECT * FROM h24_web_transac_2230912.tp5_cours_session_groupe_prof WHERE csgp_sigle_cours = @Sigle";

                    mySqlCmd.Parameters.AddWithValue("@Sigle", sigleCours);
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

        public int GetidCoursSelonSigleEtSession(string sigle, int idSession)
        {
            int idCours = 1000;
            MySqlConnection mySqlCnn = null;
            try
            {
                mySqlCnn = new MySqlConnection(CnnStr);
                mySqlCnn.Open();

                using (MySqlCommand mySqlCmd = mySqlCnn.CreateCommand())
                {
                    mySqlCmd.CommandText = "SELECT csgp_id FROM h24_web_transac_2230912.tp5_cours_session_groupe_prof WHERE csgp_sigle_cours = @Sigle AND csgp_id_session = @IdSession";

                    mySqlCmd.Parameters.AddWithValue("@Sigle", sigle);
                    mySqlCmd.Parameters.AddWithValue("@IdSession", idSession);

                    using (MySqlDataReader mySqlDataReader = mySqlCmd.ExecuteReader())
                    {
                        if (mySqlDataReader.Read())
                        {
                            idCours = (int)mySqlDataReader["csgp_id"];
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

            return idCours;
        }

        /// <summary>
        /// Permet d'inscrire un étudiant dans un cours donné
        /// </summary>
        /// <param name="id"></param>
        /// <param name="codePermanent"></param>
        //public void AjoutEtudiantDansCours(string codePermanent, string sigleCours, int idProf, int noGroupe)
        //{

        //    MySqlConnection mySqlCnn = null;
        //    try
        //    {
        //        mySqlCnn = new MySqlConnection(CnnStr);
        //        mySqlCnn.Open();

        //        using (MySqlCommand mySqlCmd = mySqlCnn.CreateCommand())
        //        {
        //            mySqlCmd.CommandText = "UPDATE h24_web_transac_2230912.tp5_cours_session_groupe_prof" +
        //                "SET csgp_groupe = 1 " +
        //                "WHERE csgp_id = @Id; " +
        //                "INSERT INTO h24_web_transac_2230912.tp5_etudiant_courssessiongroupeprof(ecsgp_csgp_id,ecsgp_etu_codepermanent) " +
        //                "VALUES (@Id,@codePermanent)";

        //            mySqlCmd.Parameters.AddWithValue("@Id", id);
        //            mySqlCmd.Parameters.AddWithValue("@codePermanent", codePermanent);

        //            mySqlCmd.ExecuteNonQuery();
        //        }
        //    }
        //    finally
        //    {
        //        if (mySqlCnn != null)
        //        {
        //            mySqlCnn.Close();
        //        }
        //    }

        //}
        /// <summary>
        /// Permet de modifier l'enseignant associé à un cours
        /// </summary>
        /// <param name="idEnseignant"></param>
        /// <param name="idCours"></param>
        public void ModifEnseignantCours(string sigleCours, int idSession, int idProfActuel, int idProfNew)
        {
            MySqlConnection mySqlCnn = null;
            try
            {
                mySqlCnn = new MySqlConnection(CnnStr);
                mySqlCnn.Open();

                using (MySqlCommand mySqlCmd = mySqlCnn.CreateCommand())
                {
                    mySqlCmd.CommandText = "update h24_web_transac_2230912.tp5_cours_session_groupe_prof set csgp_id_prof = @idProfNew " +
                        "WHERE csgp_sigle_cours= @sigleCours and csgp_id_session= @idSession AND csgp_id_prof = @idProfActuel";

                    mySqlCmd.Parameters.AddWithValue("@idProfNew", idProfNew);
                    mySqlCmd.Parameters.AddWithValue("@sigleCours", sigleCours);
                    mySqlCmd.Parameters.AddWithValue("@idSession", idSession);
                    mySqlCmd.Parameters.AddWithValue("@idProfActuel", idProfActuel);

                    mySqlCmd.ExecuteNonQuery();

                }
            }
            finally
            {
                if (mySqlCnn != null)
                {
                    mySqlCnn.Close();
                }
            }
        }
    }
}
