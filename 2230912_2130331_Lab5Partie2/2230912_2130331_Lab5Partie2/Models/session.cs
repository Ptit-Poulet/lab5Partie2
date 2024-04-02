namespace _2230912_2130331_Lab5Partie2.Models
{
    /// <summary>
    /// Classe qui représtente une session
    /// </summary>
    public class Session
    {
        /// <summary>
        /// Code unique 
        /// </summary>
        public int se_id { get; set; }

        /// <summary>
        /// Identification
        /// </summary>
        public string se_identification { get; set; }

        /// <summary>
        /// Constructeur vide requis pour désérialisation
        /// </summary>
        public Session()
        {

        }
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="se_id"></param>
        /// <param name="se_identification"></param>
        public Session(int se_id, string se_identification)
        {
            this.se_id = se_id;
            this.se_identification = se_identification;
        }
    }
}
