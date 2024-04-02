namespace _2230912_2130331_Lab5Partie2.Models
{
    /// <summary>
    /// Classe qui représente un étudiant
    /// </summary>
    public class Etudiant
    {
        /// <summary>
        /// Code permanent
        /// </summary>
        public string etu_code_permanent { get; set; }  
        /// <summary>
        /// Nom
        /// </summary>
        public string etu_nom { get; set; }
        /// <summary>
        /// Prenom
        /// </summary>
        public string etu_prenom { get; set; }
        /// <summary>
        /// Date de naissance
        /// </summary>
        public string etu_date_naissance { get; set; }
        /// <summary>
        /// Date d'inscription
        /// </summary>
        public string etu_date_inscription { get; set; }
        /// <summary>
        /// Date du diplome
        /// </summary>
        public string etu_date_diplome { get; set; }
        /// <summary>
        /// Numéro de DA
        /// </summary>
        public string etu_num_da { get; set; }
        /// <summary>
        /// Constructeur vide pour désérialiisation
        /// </summary>
        public Etudiant()
        {

        }
        /// <summary>
        /// Constructeur 
        /// </summary>
        /// <param name="etu_code_permanent"></param>
        /// <param name="etu_nom"></param>
        /// <param name="etu_prenom"></param>
        /// <param name="etu_date_naissance"></param>
        /// <param name="etu_date_inscription"></param>
        /// <param name="etu_date_diplome"></param>
        /// <param name="etu_num_da"></param>
        public Etudiant(string etu_code_permanent, string etu_nom, string etu_prenom, string etu_date_naissance, string etu_date_inscription, string etu_date_diplome, string etu_num_da)
        {
            this.etu_code_permanent = etu_code_permanent;
            this.etu_nom = etu_nom;
            this.etu_prenom = etu_prenom;
            this.etu_date_naissance = etu_date_naissance;
            this.etu_date_inscription = etu_date_inscription;
            this.etu_date_diplome = etu_date_diplome;
            this.etu_num_da = etu_num_da;
        }
    }
}
