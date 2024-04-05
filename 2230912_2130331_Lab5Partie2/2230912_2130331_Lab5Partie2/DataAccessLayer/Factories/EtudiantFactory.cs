using _2230912_2130331_Lab5Partie2.DataAccessLayer.Factories.Base;
using _2230912_2130331_Lab5Partie2.Models;
using MySql.Data.MySqlClient;

namespace _2230912_2130331_Lab5Partie2.DataAccessLayer.Factories
{
    public class EtudiantFactory : FactoryBase
    {
        private Etudiant CreateFromReader(MySqlDataReader mySqlDataReader)
        {

            string codePermanent = mySqlDataReader["etu_code_permanent"].ToString();
            string nom = mySqlDataReader["etu_nom"].ToString();
            string prenom = mySqlDataReader["etu_prenom"].ToString();
            string DateNaissance = mySqlDataReader["etu_date_naissance"].ToString();
            string DateInscription = mySqlDataReader["etu_date_inscription"].ToString();
            string DateDiplome = mySqlDataReader["etu_date_diplome"].ToString();
            int DA = (int)mySqlDataReader["etu_num_da"];


            return new Etudiant(codePermanent, nom, prenom, DateNaissance, DateInscription, DateDiplome, DA);

        }

        /// <summary>
        /// Retourner la liste des finissants pour une année donnée
        /// </summary>
        /// <param name="DateDiplome"></param>
        /// <returns></returns>
        public List<Etudiant> GetEtudiantSelonDateDiplome(string DateDiplome)
        {
            List<Etudiant> etudiant = new List<Etudiant>();
            MySqlConnection mySqlCnn = null;
            try
            {
                mySqlCnn = new MySqlConnection(CnnStr);
                mySqlCnn.Open();

                using (MySqlCommand mySqlCmd = mySqlCnn.CreateCommand())
                {
                    mySqlCmd.CommandText = "SELECT * FROM h24_web_transac_2230912.tp5_etudiant WHERE etu_date_diplome = @DateDiplome";
                    mySqlCmd.Parameters.AddWithValue("@DateDiplome", DateDiplome);

                    using(MySqlDataReader mySqlDataReader = mySqlCmd.ExecuteReader())
                    {
                        while (mySqlDataReader.Read())
                        {
                            etudiant.Add(CreateFromReader(mySqlDataReader));
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

            return etudiant;
        }

        /// <summary>
        /// Permettre de retourner la liste des étudiants inscrits à un cours donné
        /// </summary>
        /// <returns></returns>
        public List<Etudiant> GetListEtudiantCours(string sigleCours)
        {

            List<Etudiant> listEtudiants = new List<Etudiant>();
            MySqlConnection mySqlCnn = null;
            try
            {
                mySqlCnn = new MySqlConnection(CnnStr);
                mySqlCnn.Open();

                using (MySqlCommand mySqlCmd = mySqlCnn.CreateCommand())
                {
                    mySqlCmd.CommandText = "SELECT etu_code_permanent, etu_nom, etu_prenom, etu_date_naissance, etu_date_inscription, etu_date_diplome, etu_num_da " +
                        "FROM h24_web_transac_2230912.tp5_etudiant as e join h24_web_transac_2230912.tp5_etudiant_courssessiongroupeprof as ecsgp " +
                        "on e.etu_code_permanent = ecsgp.ecsgp_etu_codepermanent join h24_web_transac_2230912.tp5_cours_session_groupe_prof as csgp " +
                        "on csgp.csgp_id = ecsgp.ecsgp_csgp_id join h24_web_transac_2230912.tp5_cours as c on c.cou_sigle = csgp.csgp_sigle_cours " +
                        "where cou_sigle = @sigleCours";
                    mySqlCmd.Parameters.AddWithValue("@sigleCours", sigleCours);

                    using (MySqlDataReader mySqlDataReader = mySqlCmd.ExecuteReader())
                    {
                        while (mySqlDataReader.Read())
                        {
                            listEtudiants.Add(CreateFromReader(mySqlDataReader));
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

            return listEtudiants;
        }

        /// <summary>
        /// Permet de vérifier la présence d'un étudiant
        /// </summary>
        /// <param name="codePermanent"></param>
        /// <returns></returns>
        public bool GetEtudiant(string codePermanent)
        {

            Etudiant etudiant = new Etudiant();
            bool EstPresent = false;
            MySqlConnection mySqlCnn = null;
            try
            {
                mySqlCnn = new MySqlConnection(CnnStr);
                mySqlCnn.Open();

                using (MySqlCommand mySqlCmd = mySqlCnn.CreateCommand())
                {
                    mySqlCmd.CommandText = "SELECT * FROM h24_web_transac_2230912.tp5_etudiant WHERE etu_codepermanent = @codePermanent";

                    mySqlCmd.Parameters.AddWithValue("@codePermanent", codePermanent);

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

        ///// <summary>
        ///// Permettre de désinscrire un étudiant à un cours
        ///// </summary>
        ///// <param name="id"></param>

        //public void DeleteEtudiantCours(string codePermanent, string sigleCours)
        //{
        //    MySqlConnection mySqlCnn = null;

        //    try
        //    {
        //        mySqlCnn = new MySqlConnection(CnnStr);
        //        mySqlCnn.Open();

        //        using (MySqlCommand mySqlCmd = mySqlCnn.CreateCommand())
        //        {
        //            mySqlCmd.CommandText = "La bonne requêtte DELETE à faire";
        //            mySqlCmd.Parameters.AddWithValue("@codePermanent", codePermanent);
        //            mySqlCmd.Parameters.AddWithValue("@sigleCours", sigleCours);
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
    }
}
