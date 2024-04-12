using _2230912_2130331_Lab5Partie2.DataAccessLayer.Factories.Base;
using _2230912_2130331_Lab5Partie2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace _2230912_2130331_Lab5Partie2.DataAccessLayer.Factories
{
    public class ECSGPFactory : FactoryBase
    {
        private Etudiant_coursesessiongroupeprof CreateFromReader(MySqlDataReader mySqlDataReader)
        {
            int id = (int)mySqlDataReader["ecsgp_id"];
            int csgp_id = (int)mySqlDataReader["ecsgp_csgp_id"];
            string etu_codePermanent = mySqlDataReader["ecsgp_etu_codepermanent"].ToString();
            int resultat = (int)mySqlDataReader["ecsgp_resultat"];

            return new Etudiant_coursesessiongroupeprof(id, csgp_id, etu_codePermanent, resultat);

        }
        /// <summary>
        /// Retourner « le bulletin » des cours suivis pour un étudiant donné
        /// </summary>
        /// <param name="codePermanent"></param>
        /// <returns></returns>
        public Etudiant_coursesessiongroupeprof[] GetResultatSelonEtudiant(string codePermanent)
        {
            List<Etudiant_coursesessiongroupeprof> eCSGP = new List<Etudiant_coursesessiongroupeprof>();
            MySqlConnection mySqlCnn = null;
            try
            {
                mySqlCnn = new MySqlConnection(CnnStr);
                mySqlCnn.Open();

                using (MySqlCommand mySqlCmd = mySqlCnn.CreateCommand())
                {
                    mySqlCmd.CommandText = "SELECT ecsgp_resultat FROM tp5_etudiant_courssessiongroupeprof WHERE ecsgp_etu_codepermanent = @codePermanent";
                    mySqlCmd.Parameters.AddWithValue("@codePermanent", codePermanent);

                    using (MySqlDataReader mySqlDataReader = mySqlCmd.ExecuteReader())
                    {
                        if (mySqlDataReader.Read())
                        {
                            eCSGP.Add(CreateFromReader(mySqlDataReader));
                        }

                        mySqlDataReader.Close();
                    }

                }
            }
            finally
            {
                if (mySqlCnn != null)
                {
                    mySqlCnn.Close();
                }
            }

            return eCSGP.ToArray();
        }

        public void ModifResultatEutdiant(int resultat, string codePermanent, int idCours)
        {

            MySqlConnection mySqlCnn = null;
            try
            {
                mySqlCnn = new MySqlConnection(CnnStr);
                mySqlCnn.Open();

                using (MySqlCommand mySqlCmd = mySqlCnn.CreateCommand())
                {
                    mySqlCmd.CommandText = "UPDATE h24_web_transac_2230912.tp5_etudiant_courssessiongroupeprof " +
                        "SET ecsgp_resultat = @Resultat" +
                        "WHERE ecsgp_etu_codepermanent = @codePermanent AND ecsgp_csgp_id = @idCours";

                    mySqlCmd.Parameters.AddWithValue("@Resultat", resultat);
                    mySqlCmd.Parameters.AddWithValue("@codePermanent", codePermanent);
                    mySqlCmd.Parameters.AddWithValue("@idCours", idCours);

                    mySqlCmd.ExecuteNonQuery();

                }
            }
            finally
            {
                if (mySqlCnn != null)
                {
                    mySqlCnn.Close();
                }
            }
        }

        public void SupprEtudiantCours(string codePermanent, int idCours)
        {
            MySqlConnection mySqlCnn = null;
            try
            {
                mySqlCnn = new MySqlConnection(CnnStr);
                mySqlCnn.Open();

                using (MySqlCommand mySqlCmd = mySqlCnn.CreateCommand())
                {
                    mySqlCmd.CommandText = "DELETE FROM h24_web_transac_2230912.tp5_etudiant_courssessiongroupeprof " +
                                            "WHERE ecsgp_etu_codepermanent = @codePermanent " +
                                            "AND ecsgp_csgp_id = @idCours";

                    mySqlCmd.Parameters.AddWithValue("@codePermanent", codePermanent);
                    mySqlCmd.Parameters.AddWithValue("@idCours", idCours);

                    mySqlCmd.ExecuteNonQuery();

                }
            }
            finally
            {
                if (mySqlCnn != null)
                {
                    mySqlCnn.Close();
                }
            }
        }
    }
}
