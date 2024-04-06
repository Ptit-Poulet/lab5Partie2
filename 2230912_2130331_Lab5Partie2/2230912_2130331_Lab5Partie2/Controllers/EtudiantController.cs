﻿using Microsoft.AspNetCore.Mvc;
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
        //public IActionResult Index()
        //{
        //    return View();
        //}



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
        /// Ajouter un étudiant à cours 
        /// </summary>
        /// <param name="idCours"></param>
        /// <param name="codePermanent"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public ActionResult<IEnumerable<Etudiant>> AjouterEtudiantDansCours(int idCours, string codePermanent)
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
        public ActionResult<IEnumerable<Etudiant>> ModifResultatEtudiantDansUnCours(int resultat, string codePermanent, int idCours)
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
    }
}
