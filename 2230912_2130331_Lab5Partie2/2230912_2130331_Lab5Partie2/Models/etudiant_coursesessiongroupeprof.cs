namespace _2230912_2130331_Lab5Partie2.Models
{
    /// <summary>
    /// Classe qui représente un étudiant, un cours, une session, un groupe et un prof
    /// </summary>
    public class Etudiant_coursesessiongroupeprof
    {
        /// <summary>
        /// Code unique
        /// </summary>
        public int ecsgp_id { get; set; }
        /// <summary>
        /// Code selon le coursSP
        /// </summary>
        public int ecsgp_csp_id { get; set; }
        /// <summary>
        /// Code permanent
        /// </summary>
        public string ecsgp_etu_codepermanent { get; set; }
        /// <summary>
        /// Resultat
        /// </summary>
        public int ecsgp_resultat { get; set; }

        /// <summary>
        /// Constructeur vide pour déserialisation
        /// </summary>
        public Etudiant_coursesessiongroupeprof()
        {

        }
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="ecsgp_id"></param>
        /// <param name="ecsgp_csp_id"></param>
        /// <param name="ecsgp__etu_codepermanent"></param>
        /// <param name="ecsgp_resultat"></param>
        public Etudiant_coursesessiongroupeprof(int ecsgp_id, int ecsgp_csp_id, string ecsgp_etu_codepermanent, int ecsgp_resultat)
        {
            this.ecsgp_id = ecsgp_id;
            this.ecsgp_csp_id = ecsgp_csp_id;
            this.ecsgp_etu_codepermanent = ecsgp_etu_codepermanent;
            this.ecsgp_resultat = ecsgp_resultat;
        }
    }
}
