namespace _2230912_2130331_Lab5Partie2.Models
{
    /// <summary>
    /// Classe qui représente un cours, une session, un group et un prof
    /// </summary>
    public class Cours_session_groupe_prof
    {
        /// <summary>
        /// Code unique
        /// </summary>
        public int csgp_id { get; set; }
        /// <summary>
        /// Sigle de cours
        /// </summary>
        public string csgp_sigle_cours { get; set; }
        /// <summary>
        /// Code unique de session
        /// </summary>
        public int csgp_id_session { get; set; }
        /// <summary>
        /// Groupe
        /// </summary>
        public int csgp_groupe { get; set; }
        /// <summary>
        /// Code unique d'un prof
        /// </summary>
        public int csgp_id_prof { get; set; }
        /// <summary>
        /// Constructeur vide pour déserialisation
        /// </summary>
        public Cours_session_groupe_prof()
        {

        }
        /// <summary>
        /// Constructeur 
        /// </summary>
        /// <param name="csgp_id"></param>
        /// <param name="csgp_sigle_cours"></param>
        /// <param name="csgp_id_session"></param>
        /// <param name="csgp_groupe"></param>
        /// <param name="csgp_id_prof"></param>
        public Cours_session_groupe_prof(int csgp_id, string csgp_sigle_cours, int csgp_id_session, int csgp_groupe, int csgp_id_prof)
        {
            this.csgp_id = csgp_id;
            this.csgp_sigle_cours = csgp_sigle_cours;
            this.csgp_id_session = csgp_id_session;
            this.csgp_groupe = csgp_groupe;
            this.csgp_id_prof = csgp_id_prof;
        }
    }
}
