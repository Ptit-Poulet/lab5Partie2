using _2230912_2130331_Lab5Partie2.SQL;

namespace _2230912_2130331_Lab5Partie2.DataAccessLayer.Factories.Base
{
    public class FactoryBase
    {
        private string _cnnStr = string.Empty;

        public string CnnStr
        {
            get
            {
                if (_cnnStr == string.Empty)
                {
                    var config = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();
                    var sectionConnectionString = config.GetSection("ConnectionString");
                    Lab5Config connectionString = sectionConnectionString.Get<Lab5Config>();
                    _cnnStr = connectionString.BuildConnectionString();
                }

                return _cnnStr;
            }
        }
    }
}
