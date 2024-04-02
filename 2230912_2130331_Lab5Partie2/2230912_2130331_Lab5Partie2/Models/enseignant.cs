namespace _2230912_2130331_Lab5Partie2.Models
{
    /// <summary>
    /// Classe qui représente un enseignant
    /// </summary>
    public class Enseignant
    {
        /// <summary>
        /// Code unique
        /// </summary>
        public int en_id { get; set; }
        /// <summary>
        /// Nom
        /// </summary>
        public string en_nom { get; set; }
        /// <summary>
        /// Prenom
        /// </summary>
        public string en_prenom { get; set; }
        /// <summary>s
        /// Numéro d'employé
        /// </summary>
        public int en_numero_employe { get; set; }
        /// <summary>
        /// Date d'embauche
        /// </summary>
        public string en_date_embauche { get; set; }
        /// <summary>
        /// Date de retraite
        /// </summary>
        public string en_date_retraite { get; set; }
        /// <summary>
        /// Constructeur vide pour déserialisation
        /// </summary>
        public Enseignant()
        {

        }
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="en_id"></param>
        /// <param name="en_nom"></param>
        /// <param name="en_prenom"></param>
        /// <param name="en_numero_employe"></param>
        /// <param name="en_date_embauche"></param>
        /// <param name="en_date_retraite"></param>
        public Enseignant(int en_id, string en_nom, string en_prenom, int en_numero_employe, string en_date_embauche, string en_date_retraite)
        {
            this.en_id = en_id;
            this.en_nom = en_nom;
            this.en_prenom = en_prenom;
            this.en_numero_employe = en_numero_employe;
            this.en_date_embauche = en_date_embauche;
            this.en_date_retraite = en_date_retraite;
        }
    }
}
