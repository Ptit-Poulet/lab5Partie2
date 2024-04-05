using _2230912_2130331_Lab5Partie2.DataAccessLayer.Factories;
namespace _2230912_2130331_Lab5Partie2.DataAccessLayer
{
    public class DAL
    {
        private CoursFactory _coursFact = null;
        public CoursFactory CoursFact
        {
            get
            {
                if (_coursFact == null)
                {
                    _coursFact = new CoursFactory();
                }

                return _coursFact;
            }
        }

        private CSGPFactory _csgpFact = null;
        public CSGPFactory CSGPFact
        {
            get
            {
                if(_csgpFact == null)
                {
                    _csgpFact = new CSGPFactory();  
                }

                return _csgpFact;   
            }
        }

        private ECSGPFactory _ecsgpFact = null;
        public ECSGPFactory ECSGPFact
        {
            get
            {
                if(_ecsgpFact == null)
                {
                    _ecsgpFact= new ECSGPFactory();
                }

                return _ecsgpFact;
            }
        }

        private EnseignantFactory _enseignantFact = null;
        public EnseignantFactory EnseignantFact
        {
            get
            {
                if(_enseignantFact == null)
                {
                    _enseignantFact= new EnseignantFactory();
                }

                return _enseignantFact;
            }
        }

        private EtudiantFactory _etudiantFact = null;
        public EtudiantFactory EtudiantFact
        {
            get
            {
                if(_etudiantFact == null)
                {
                    _etudiantFact = new EtudiantFactory();
                }

                return _etudiantFact;
            }
        }

        private SessionFactory _sessionFact = null;
        public SessionFactory SessionFact
        {
            get
            {
                if(_sessionFact == null)
                {
                    _sessionFact= new SessionFactory();
                }
                return _sessionFact;
            }
        }
    }
}
