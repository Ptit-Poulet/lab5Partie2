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
    public class CoursController : ControllerBase
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}




        /// <summary>
        /// retourner la liste de cours pour un étudiant donné
        /// </summary>
        /// <param name="codePermanent"></param>
        /// <returns></returns>
        [HttpGet("[action]")] 
        public ActionResult<IEnumerable<Cours>> GetListCoursEtudian(string codePermanent)
        {
            DAL dal = new DAL();

            return dal.CoursFact.GetListCoursEtudiant(codePermanent);
        }


        /// <summary>
        /// retourner l’historique des cours suivis pour un étudiant donné
        /// </summary>
        /// <param name="codePermanent"></param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<Cours>> GetHistoriqueCoursEtudiant(string codePermanent)
        {
            DAL dal = new DAL();

            return dal.CoursFact.GetHistoriqueCoursEtudiant(codePermanent);
        }


        /// <summary>
        /// retourner la liste des cours enseignés par un enseignant donné
        /// </summary>
        /// <param name="idProf"></param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<Cours>> GetListCoursSelonEnseignant(int idProf)
        {
            DAL dal = new DAL();
            return dal.CoursFact.GetListCoursSelonEnseignant(idProf);
        }

    }
}
