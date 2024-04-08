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

    }
}
