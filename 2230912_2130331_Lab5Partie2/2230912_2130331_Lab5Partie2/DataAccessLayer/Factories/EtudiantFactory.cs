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
    }
}
