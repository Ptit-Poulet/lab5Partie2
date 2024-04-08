namespace _2230912_2130331_Lab5Partie2.Models
{
    public class CoursResultat
    {
        /// <summary>
        /// Cours associé au bulletin
        /// </summary>
        public Cours Cours { get; set; }

        /// <summary>
        /// Résultat sanctionné par le bulletin 
        /// </summary>
        public string Resultat {  get; set; }


        //Constructeur vide requis pour la désérialisation
        public CoursResultat()
        { 

        }  
        
        public CoursResultat(Cours cours, string resultat)
        {
            Cours = cours;
            Resultat = resultat;
        }
    }
}
