using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Zadatak_1.Models
{
    class Users
    {
        /// <summary>
        /// This methods finds employee based on forwarded username and password.
        /// </summary>
        /// <param name="username">Employee username.</param>
        /// <param name="password">Employee password.</param>
        /// <returns>Employee.</returns>
        public vwEmployee FindEmployee(string username, string password)
        {
            try
            {
                using (HotelEntities context = new HotelEntities())
                {
                    return context.vwEmployees.Where(x => x.Username == username && x.Password == password).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
        /// <summary>
        /// This methods finds manager based on forwarded username and password.
        /// </summary>
        /// <param name="username">Manager username.</param>
        /// <param name="password">Manager password.</param>
        /// <returns>Manager.</returns>
        public vwManager FindManager(string username, string password)
        {
            try
            {
                using (HotelEntities context = new HotelEntities())
                {
                    return context.vwManagers.Where(x => x.Username == username && x.Password == password).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
        /// <summary>
        /// This method created list of genders.
        /// </summary>
        /// <returns>List of genders.</returns>
        public List<string> GetGenders()
        {
            return new List<string> { "F", "M", "X" };
        }
        /// <summary>
        /// This method created list of employee's engagement.
        /// </summary>
        /// <returns>List of engagement.</returns>
        public List<string> GetEngagements()
        {
            return new List<string> { "cleaning", "cooking", "monitoring", "reporting" };
        }
        /// <summary>
        /// This method created collection of levels of proffesional qualifications.
        /// </summary>
        /// <returns>List of engagement.</returns>
        public List<string> GetLevelsPQ()
        {
            var levels = CreateLevelOfPQ();
            return levels.Keys.ToList();
        }
        public Dictionary<string, int> CreateLevelOfPQ()
        {
            Dictionary<string, int> levels = new Dictionary<string, int>();
            levels.Add("I", 1);
            levels.Add("II", 2);
            levels.Add("III", 3);
            levels.Add("IV", 4);
            levels.Add("V", 5);
            levels.Add("VI", 6);
            levels.Add("VII", 7);
            return levels;
        }
        /// <summary>
        /// This method creates a list of data from view of all users.
        /// </summary>
        /// <returns>List of users.</returns>
        public List<tblUser> GetAllUsers()
        {
            try
            {
                using (HotelEntities context = new HotelEntities())
                {
                    return context.tblUsers.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
    }
}