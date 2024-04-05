using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _2230912_2130331_Lab5Partie2.Models;
using _2230912_2130331_Lab5Partie2.DataAccessLayer;
using _2230912_2130331_Lab5Partie2.DataAccessLayer.Factories;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;


namespace _2230912_2130331_Lab5Partie2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EtudiantController : ControllerBase
    {
        
        /// <summary>
        /// retourner la liste des étudiants inscrits à un cours donné
        /// </summary>
        /// <param name="titre"></param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<Etudiant>> GetListEtudiantCours(string titre)
        {
            DAL dal = new DAL();

            return dal.EtudiantFact.GetListEtudiantCours(titre);
        }


        /// <summary>
        /// Retourner la liste des finissants pour une année donnée
        /// </summary>
        /// <param name="DateDiplome"></param>
        /// <returns></returns>

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<Etudiant>> GetEtudiantSelonDateDiplome(string DateDiplome)
        {
            DAL dal = new DAL();

            return dal.EtudiantFact.GetEtudiantSelonDateDiplome(DateDiplome);
        }
    }
}
