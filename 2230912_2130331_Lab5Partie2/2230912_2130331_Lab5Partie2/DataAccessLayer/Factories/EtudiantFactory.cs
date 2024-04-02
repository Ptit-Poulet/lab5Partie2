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
            int DA = (int)mySqlDataReader["etu_date_diplome"];


            return new Etudiant(codePermanent, nom, prenom, DateNaissance, DateInscription, DateDiplome, DA);
        }
    }
}
