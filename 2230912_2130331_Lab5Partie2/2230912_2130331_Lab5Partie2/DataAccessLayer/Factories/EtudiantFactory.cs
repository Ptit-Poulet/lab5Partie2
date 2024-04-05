using _2230912_2130331_Lab5Partie2.DataAccessLayer.Factories.Base;
using _2230912_2130331_Lab5Partie2.Models;
using MySql.Data.MySqlClient;

namespace _2230912_2130331_Lab5Partie2.DataAccessLayer.Factories
{
    public class EtudiantFactory : FactoryBase
    {
        private Etudiant CreateFromReader(MySqlDataReader mySqlDataReader)
        {
<<<<<<< HEAD

            string codePermanent = mySqlDataReader["etu_code_permanent"].ToString();
            string nom = mySqlDataReader["etu_nom"].ToString();
            string prenom = mySqlDataReader["etu_prenom"].ToString();
            string DateNaissance = mySqlDataReader["etu_date_naissance"].ToString();
            string DateInscription = mySqlDataReader["etu_date_inscription"].ToString();
            string DateDiplome = mySqlDataReader["etu_date_diplome"].ToString();
            int DA = (int)mySqlDataReader["etu_date_diplome"];


            return new Etudiant(codePermanent, nom, prenom, DateNaissance, DateInscription, DateDiplome, DA);

        }

        /// <summary>
        /// Retourner la liste des finissants pour une année donnée
        /// </summary>
        /// <param name="DateDiplome"></param>
        /// <returns></returns>
        public Etudiant[] GetEtudiantSelonDateDiplome(string DateDiplome)
        {
            List<Etudiant> etudiant = new List<Etudiant>();
            MySqlConnection mySqlCnn = null;
            try
            {
                mySqlCnn = new MySqlConnection(CnnStr);
                mySqlCnn.Open();

                using (MySqlCommand mySqlCmd = mySqlCnn.CreateCommand())
                {
                    mySqlCmd.CommandText = "SELECT etu_nom, etu_prenom FROM tp5_etudiant WHERE etu_date_diplome = @DateDiplome";
                    mySqlCmd.Parameters.AddWithValue("@DateDiplome", DateDiplome);

                    using(MySqlDataReader mySqlDataReader = mySqlCmd.ExecuteReader())
                    {
                        if (mySqlDataReader.Read())
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

            return etudiant.ToArray();
=======
            string codePermanent = mySqlDataReader["etu_code_permanent"].ToString();
            string nom = mySqlDataReader["etu_nom"].ToString();
            string prenom = mySqlDataReader["etu_prenom"].ToString();
            string DateNaissance = mySqlDataReader["etu_date_naissance"].ToString();
            string DateInscription = mySqlDataReader["etu_date_inscription"].ToString();
            string DateDiplome = mySqlDataReader["etu_date_diplome"].ToString();
            int DA = (int)mySqlDataReader["etu_date_diplome"];


            return new Etudiant(codePermanent, nom, prenom, DateNaissance, DateInscription, DateDiplome, DA);
>>>>>>> 25404073853b15fa8d9c392e4f75b4357c78f82c
        }

        /// <summary>
        /// Permettre de retourner la liste des étudiants inscrits à un cours donné
        /// </summary>
        /// <returns></returns>
        public List<Etudiant> GetListEtudiantCours(string titre)
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
                "FROM gestionpedagogique.tp5_etudiant as e join gestionpedagogique.tp5_etudiant_courssessiongroupeprof as ecsgp " +
                "on e.etu_code_permanent = ecsgp.ecsgp_etu_codepermanent " +
                "join gestionpedagogique.tp5_cours_session_groupe_prof as csgp on csgp.csgp_id = ecsgp.ecsgp_csgp_id " +
                "join gestionpedagogique.tp5_cours as c on c.cou_sigle = csgp.csgp_sigle_cours " +
                " where cou_titre = @titreCours";
                    mySqlCmd.Parameters.AddWithValue("@titreCours", titre);

                    using (MySqlDataReader mySqlDataReader = mySqlCmd.ExecuteReader())
                    {
                        if (mySqlDataReader.Read())
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
        /// Permettre de désinscrire un étudiant à un cours
        /// </summary>
        /// <param name="id"></param>

        public void DeleteEtudiantCours(string codePermanent, string sigleCours)
        {
            MySqlConnection mySqlCnn = null;

            try
            {
                mySqlCnn = new MySqlConnection(CnnStr);
                mySqlCnn.Open();

                using (MySqlCommand mySqlCmd = mySqlCnn.CreateCommand())
                {
                    mySqlCmd.CommandText = "La bonne requêtte DELETE à faire";
                    mySqlCmd.Parameters.AddWithValue("@codePermanent", codePermanent);
                    mySqlCmd.Parameters.AddWithValue("@sigleCours", sigleCours);
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
