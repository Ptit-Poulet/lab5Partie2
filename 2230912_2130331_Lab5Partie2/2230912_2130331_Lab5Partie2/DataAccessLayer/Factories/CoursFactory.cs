using _2230912_2130331_Lab5Partie2.DataAccessLayer.Factories.Base;
using _2230912_2130331_Lab5Partie2.Models;
using MySql.Data.MySqlClient;

namespace _2230912_2130331_Lab5Partie2.DataAccessLayer.Factories
{
    public class CoursFactory : FactoryBase
    {
        private Cours CreateFromReader(MySqlDataReader mySqlDataReader)
        {
            string code = mySqlDataReader["cou_sigle"].ToString();
            string titre = mySqlDataReader["cou_titre"].ToString();
            int duree = (int)mySqlDataReader["cou_duree"];

            return new Cours(code, titre, duree);

        }


        //Faire les autres méthodes en fonction de ce qui est demandé dans l'énoncé du travail
    }
}
