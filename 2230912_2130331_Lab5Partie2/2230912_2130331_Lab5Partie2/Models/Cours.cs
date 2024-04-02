namespace _2230912_2130331_Lab5Partie2.Models
{
    public class Cours
    {
        
        /// <summary>
        /// Code du cours 
        /// </summary>
        public string  CodeCours { get; set; }

        /// <summary>
        /// Titre du cours
        /// </summary>
        public string TitreCours { get; set; }


        /// <summary>
        /// Durée du cours
        /// </summary>
        public int DureeCours { get; set; }  


        //Constructeur vide requis pour la désérialisation

        public Cours()
        { 

        }

        public Cours (string codeCours, string titreCours, int dureeCours)
        {
            CodeCours = codeCours;
            TitreCours = titreCours;
            DureeCours = dureeCours;
        }   
    }
}
