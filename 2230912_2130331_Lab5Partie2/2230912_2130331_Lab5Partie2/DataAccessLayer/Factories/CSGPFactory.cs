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
        /// Permet d'inscrire un étudiant dans un cours donné
        /// </summary>
        /// <param name="id"></param>
        /// <param name="codePermanent"></param>
        public void PutEtudiantDansCours(int id, string codePermanent)
        {
            
            MySqlConnection mySqlCnn = null;
            try
            {
                mySqlCnn = new MySqlConnection(CnnStr);
                mySqlCnn.Open();

                using (MySqlCommand mySqlCmd = mySqlCnn.CreateCommand())
                {
                    mySqlCmd.CommandText = "UPDATE h24_web_transac_2230912.tp5_cours_session_groupe_prof" +
                        "SET csgp_groupe = 1 WHERE csgp_id = @Id;" +
                        "INSERT INTO h24_web_transac_2230912.tp5_etudiant_courssessiongroupeprof (ecsgp_csgp_id,ecsgp_etu_codepermanent)" +
                        "VALUES (@Id,@codePremanent)";

                    mySqlCmd.Parameters.AddWithValue("@Id", id);
                    mySqlCmd.Parameters.AddWithValue("@codePermanent", codePermanent);

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
        /// <summary>
        /// Permet de modifier l'enseignant associé à un cours
        /// </summary>
        /// <param name="idEnseignant"></param>
        /// <param name="idCours"></param>
        public void ModifEnseignantCours(int idEnseignant, int idCours)
        {
            MySqlConnection mySqlCnn = null;
            try
            {
                mySqlCnn = new MySqlConnection(CnnStr);
                mySqlCnn.Open();

                using (MySqlCommand mySqlCmd = mySqlCnn.CreateCommand())
                {
                    mySqlCmd.CommandText = "UPDATE h24_web_transac_2230912.tp5_cours_session_groupe_prof " +
                        "SET csgp_id_prof = @idProf" +
                        "WHERE csgp_id = @idCours";

                    mySqlCmd.Parameters.AddWithValue("@idProf", idEnseignant);
                    mySqlCmd.Parameters.AddWithValue("@idCours", idCours);

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
