using _2230912_2130331_Lab5Partie2.DataAccessLayer.Factories.Base;
using _2230912_2130331_Lab5Partie2.Models;
using MySql.Data.MySqlClient;

namespace _2230912_2130331_Lab5Partie2.DataAccessLayer.Factories
{
    public class EtudiantFactory : FactoryBase
    {
        private Etudiant CreateFromReader(MySqlDataReader mySqlDataReader)
        {
            int id = (int)mySqlDataReader["Id"];
            string code = mySqlDataReader["Code"].ToString();
            string name = mySqlDataReader["Name"].ToString();
            short qtyInStock = (short)mySqlDataReader["QuantityInStock"];

            return new Product(id, code, name, qtyInStock);
        }
    }
}
