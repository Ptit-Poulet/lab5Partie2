using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _2230912_2130331_Lab5Partie2.Models;
using _2230912_2130331_Lab5Partie2.DataAccessLayer;
using _2230912_2130331_Lab5Partie2.DataAccessLayer.Factories;
using Microsoft.AspNetCore.Http;
using _2230912_2130331_Lab5Partie2.Attributes;

namespace _2230912_2130331_Lab5Partie2.Controllers
{
   // [ApiKey]
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


        ///// <summary>
        ///// Ajouter un étudiant à cours 
        ///// </summary>
        ///// <param name="idCours"></param>
        ///// <param name="codePermanent"></param>
        ///// <returns></returns>
        //[HttpPost("[action]")]
        //public ActionResult<IEnumerable<Etudiant>> AjouterEtudiantDansCours(string codePermanent, string sigleCours, int idProf, int noGroupe)
        //{
        //    DAL dal = new DAL();

        //    try
        //    {
        //        bool estPresent = dal.EtudiantFact.GetEtudiant(codePermanent);
        //        bool existe = dal.CSGPFact.GetCours(idCours);
        //        if (estPresent)
        //        {
        //            if (existe)
        //            {
        //                dal.CSGPFact.AjoutEtudiantDansCours(idCours, codePermanent);
        //                return Ok("L'étudiant a été ajouté avec succès.");

        //            }
        //            return StatusCode(404, "Le cours n'existe pas.");

        //        }
        //        return StatusCode(404, "L'étudiant n'existe pas.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Une erreur s'est produite lors de l'ajout de l'étudiant à un cours : {ex.Message}");
        //    }
        //}

        /// <summary>
        /// Modifier le résultat d'un étudiant selon un cours donné
        /// </summary>
        /// <param name="resultat"></param>
        /// <param name="codePermanent"></param>
        /// <param name="sigleCours"></param>
        /// <param name="idSession"></param>
        /// <returns></returns>
<<<<<<< HEAD
=======
        [HttpPost("[action]")]
        public ActionResult<IEnumerable<Etudiant>> AjouterEtudiantDansCours(string sigleCours, int idProf, int noGroupe, string codePermanent)
        {
            DAL dal = new DAL();

            try
            {
                bool estPresent = dal.EtudiantFact.GetEtudiant(codePermanent);
                int idCours = 1000;
                Cours_session_groupe_prof existingLastCSGP = dal.CSGPFact.GetLastCSGP(sigleCours, idProf, noGroupe);
                if (estPresent)
                {
                    if (existingLastCSGP != null)
                    {
                        dal.CSGPFact.AjoutEtudiantDansCours(existingLastCSGP, codePermanent);
                        return Ok("L'étudiant a été ajouté avec succès.");

                    }
                    return StatusCode(404, "Ce cours n'existe pas pour ces paramètres à la session actuelle !");

                }
                return StatusCode(404, "L'étudiant n'existe pas.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de l'ajout de l'étudiant à un cours : {ex.Message}");
            }
        }

>>>>>>> 6b1142a86e62413f0feb47c6694781c19b78c590
        [HttpPut("[action]")]
        public ActionResult<IEnumerable<Etudiant>> ModifResultatEtudiantDansUnCours(int resultat, string codePermanent, string sigleCours, int idSession)
        {
            DAL dal = new DAL();

            try
            {
                bool estPresent = dal.EtudiantFact.GetEtudiant(codePermanent);
                int idCours = dal.CSGPFact.GetidCoursSelonSigleEtSession(sigleCours, idSession);

                if (estPresent)
                {
                    if (idCours != 1000)
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

        /// <summary>
        /// Retourner les bulletins des cours suivi pour un étudiant donné
        /// </summary>
        /// <param name="codePermanent"></param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<CoursResultat>> GetBulletin(string codePermanent)
        {
            DAL dal = new DAL();
            try
            {
                bool estPresent = dal.EtudiantFact.GetEtudiant(codePermanent);
                if (estPresent)
                {
                    return dal.CoursResultatFact.GetBulletin(codePermanent);
                }
                return StatusCode(404, "L'étudiant n'existe pas.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors du chargement des bulletins depuis la BD : {ex.Message}");
            }

        }
    }
}
