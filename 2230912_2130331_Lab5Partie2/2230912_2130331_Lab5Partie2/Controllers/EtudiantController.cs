using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _2230912_2130331_Lab5Partie2.Models;
using _2230912_2130331_Lab5Partie2.DataAccessLayer;
using _2230912_2130331_Lab5Partie2.DataAccessLayer.Factories;
using Microsoft.AspNetCore.Http;
using _2230912_2130331_Lab5Partie2.Attributes;
using Microsoft.AspNetCore.Mvc;


namespace _2230912_2130331_Lab5Partie2.Controllers
{
    [ApiKey]
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
        public ActionResult<IEnumerable<Etudiant>> GetListEtudiantCours(int idCours)
        {
            DAL dal = new DAL();
            try
            {
                bool estPresent = dal.CSGPFact.GetCours(idCours);
                if (estPresent)
                {
                    return dal.EtudiantFact.GetListEtudiantCours(idCours);
                }
                return StatusCode(404, "Le cours n'existe pas.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la visualisation d'un cours : {ex.Message}");
            }
        }


        /// <summary>
        /// Ajouter un étudiant à cours 
        /// </summary>
        /// <param name="idCours"></param>
        /// <param name="codePermanent"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public ActionResult<IEnumerable<Etudiant>> AjouterEtudiantDansCours(string codePermanent, string sigleCours, int idProf, int noGroupe, string codePermanent)
        {
            DAL dal = new DAL();

            try
            {
                bool estPresent = dal.EtudiantFact.GetEtudiant(codePermanent);
                bool existe = dal.CSGPFact.GetCours(idCours);
                if (estPresent)
                {
                    if (existe)
                    {
                        dal.CSGPFact.AjoutEtudiantDansCours(idCours, codePermanent);
                        return Ok("L'étudiant a été ajouté avec succès.");

                    }
                    return StatusCode(404, "Le cours n'existe pas.");

                }
                return StatusCode(404, "L'étudiant n'existe pas.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de l'ajout de l'étudiant à un cours : {ex.Message}");
            }
        }

        [HttpPut("[action]")]
        public ActionResult ModifResultatEtudiantDansUnCours(int resultat, string codePermanent, int idCours)
        {
            DAL dal = new DAL();

            try
            {
                bool estPresent = dal.EtudiantFact.GetEtudiant(codePermanent);
                bool existe = dal.CSGPFact.GetCours(idCours);
                if (estPresent)
                {
                    if (existe)
                    {
                        dal.ECSGPFact.ModifResultatEutdiant(resultat, codePermanent, idCours);
                        return Ok("Le résultat de l'étudiant a été modifié avec succès.");

                    }
                    return StatusCode(404, "Le cours n'existe pas.");

                }
                return StatusCode(404, "L'étudiant n'existe pas.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la modification d'un de l'étudiant à un cours : {ex.Message}");
            }
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
            try
            {
                bool convert = DateTime.TryParse(DateDiplome, out DateTime date);

                if (!convert)
                {
                    return StatusCode(401, "Le format de la date n'est pas bon.");
                }

                List<Etudiant> etudiants = dal.EtudiantFact.GetEtudiantSelonDateDiplome(date);

                if (etudiants != null)
                {
                    return etudiants;
                }
                return StatusCode(404, "Il n'y a pas de finissants pour cette année.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la visualisation des diplomés : {ex.Message}");
            }

        }
    }
}
