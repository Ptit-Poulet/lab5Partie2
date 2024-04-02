namespace _2230912_2130331_Lab5Partie2.Models
{
    /// <summary>
    /// Classe qui représente un cours, une session, un group et un prof
    /// </summary>
    public class Cours_session_groupe_prof
    {
        public int csgp_id { get; set; }    
        public string csgp_sigle_cours { get; set; }

        public int csgp_id_session { get; set; }
        public int csgp_groupe { get; set; }
        public int csgp_id_prof { get; set; }

    }
}
