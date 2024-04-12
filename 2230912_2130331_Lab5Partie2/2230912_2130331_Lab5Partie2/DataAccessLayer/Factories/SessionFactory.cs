using _2230912_2130331_Lab5Partie2.DataAccessLayer.Factories.Base;
using _2230912_2130331_Lab5Partie2.Models;
using MySql.Data.MySqlClient;

namespace _2230912_2130331_Lab5Partie2.DataAccessLayer.Factories
{
    public class SessionFactory : FactoryBase
    {
        private Session CreateFromReader(MySqlDataReader mySqlDataReader)
        {
            int id = (int)mySqlDataReader["se_id"];
            string identification = mySqlDataReader["se_identification"].ToString();

            return new Session(id, identification);

        }

    }
}
