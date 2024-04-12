using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _2230912_2130331_Lab5Partie2.Models;
using _2230912_2130331_Lab5Partie2.DataAccessLayer;
using _2230912_2130331_Lab5Partie2.DataAccessLayer.Factories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _2230912_2130331_Lab5Partie2.Attributes;
namespace _2230912_2130331_Lab5Partie2.Controllers
{

    //[ApiKey]
    [ApiController]
    [Route("[controller]")]
    public class CoursController : ControllerBase
    {

        /// <summary>
        /// Retourner la liste des cours actuel pour un étudiant donné
        /// </summary>
        /// <param name="codePermanent"></param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<Cours>> GetListCoursActuelEtudiant(string codePermanent)
        {
            List<Cours> cours;
            DAL dal = new DAL();

            try
            {
                bool estPresent = dal.EtudiantFact.GetEtudiant(codePermanent);

                if (estPresent)
                {
                    cours = dal.CoursFact.GetListCoursEtudiant(codePermanent);

                    if(cours.Count > 0)
                    {
                        return cours;
                    }
                    return StatusCode(200, "L'étudiant n'a aucun cours dans la session actuel.");
                }
                return StatusCode(404, "L'étudiant n'existe pas.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de l'ajout de l'étudiant à un cours : {ex.Message}");
            }
        }

        /// <summary>
        /// Retourner l’historique des cours suivis pour un étudiant donné
        /// </summary>
        /// <param name="codePermanent"></param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<Cours>> GetHistoriqueCoursEtudiant(string codePermanent) //TOUS LES COURS OU SELON UNE SESSION ?
        {
            DAL dal = new DAL();
            try
            {
                bool estPresent = dal.EtudiantFact.GetEtudiant(codePermanent);
                if (estPresent)
                {
                    return dal.CoursFact.GetHistoriqueCoursEtudiant(codePermanent);
                }
                return StatusCode(404, "L'étudiant n'existe pas.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de l'ajout de l'étudiant à un cours : {ex.Message}");
            }
        }

        /// <summary>
        /// Ajoute un nouveau cours 
        /// </summary>
        /// <param name="sigle"></param>
        /// <param name="titre"></param>
        /// <param name="duree"></param>
        /// <param name="idProf"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public ActionResult<IEnumerable<Cours>> AjouterUnCours(string sigle, string titre, int duree, int idProf)
        {
            DAL dal = new DAL();

            try
            {
                bool EstPresent = dal.EnseignantFact.GetEnseignant(idProf);
                if (!EstPresent)
                    return StatusCode(404, "id du prof n'existe pas.");

                int session = dal.SessionFact.GetSessionActuel();
                dal.CoursFact.AddCours(sigle, titre, duree, idProf, session);

                return Ok("Le cours a été ajouté avec succès.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de l'ajout du cours : {ex.Message}");
            }
        }

        /// <summary>
        /// Modifie l'enseignant qui est affecté à un cours
        /// </summary>
        /// <param name="sigleCours"></param>
        /// <param name="idSession"></param>
        /// <param name="idProfActuel"></param>
        /// <param name="idProfNew"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public ActionResult ModifiEnseignantCours(string sigleCours, int idSession, int idProfActuel, int idProfNew)
        {
            DAL dal = new DAL();

            try
            {
                bool existe = dal.CSGPFact.GetCours(sigleCours, idSession);
                bool existingEnseignant = idProfActuel == dal.EnseignantFact.GetIdEnseignantCours(sigleCours, idSession);

                if (existe)
                {
                    if(existingEnseignant)
                    {
                        dal.CSGPFact.ModifEnseignantCours(sigleCours, idSession, idProfActuel, idProfNew);
                        return Ok("L'enseignant a été modifié avec succès.");
                    }

                    return StatusCode(404, "Cet enseignant n\'existe pas ou n'est pas associé à ce cours !");

                }
                return StatusCode(404, "Le cours n'existe pas.");

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la modification de  l'enseignant du cours : {ex.Message}");
            }
        }

        /// <summary>
        /// Enleve un étudiant d'un cours spécifique
        /// </summary>
        /// <param name="codePermanent"></param>
        /// <param name="sigleCours"></param>
        /// <param name="idSession"></param>
        /// <returns></returns>
        [HttpDelete("[action]")]
        public ActionResult EnleverEtudiantDansUnCours(string codePermanent, string sigleCours, int idSession)
        {
            DAL dal = new DAL();

            try
            {
                bool estPresent = dal.EtudiantFact.GetEtudiant(codePermanent);
                bool existe = dal.CSGPFact.GetCoursSelonSigle(sigleCours);
                int idCours = dal.CSGPFact.GetidCoursSelonSigleEtSession(sigleCours, idSession);
                if (estPresent)
                {
                    if (existe)
                    {
                        if (idCours != 1000)
                        {
                            dal.ECSGPFact.SupprEtudiantCours(codePermanent, idCours);
                            return Ok("L'étudiant a été enlevé avec succès.");
                        }


                    }
                    return StatusCode(404, "Le cours n'existe pas.");

                }
                return StatusCode(404, "L'étudiant n'existe pas.");

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la suppression d'un étudiant du cours : {ex.Message}");
            }
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

            try
            {
                bool existe = dal.EnseignantFact.GetEnseignant(idProf);

                if (existe)
                {
                    return dal.CoursFact.GetListCoursSelonEnseignant(idProf);

                }
                return StatusCode(404, "L'enseignant n'existe pas.");

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors du chargement des cours depuis la BD : {ex.Message}");
            }
        }

    }
}
