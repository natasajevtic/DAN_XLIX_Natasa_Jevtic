using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Zadatak_1.Models;

namespace Zadatak_1.Validations
{
    class Validation
    {
        /// <summary>
        /// This method checks if forwarded username unique.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool UniqueUsername(string username)
        {
            Users users = new Users();
            List<tblUser> userList = users.GetAllUsers();
            var list = userList.Where(x => x.Username == username).ToList();
            //if exists employee with forwarded username, return false
            if (list.Count() > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// This method checks if email adress is valid.
        /// </summary>
        /// <param name="email">Email to check.</param>
        /// <returns>True if valid, false if not.</returns>
        public bool ValidationForEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }
        /// <summary>
        /// This method checks if forwarded email unique.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool UniqueEmail(string email)
        {
            Users users = new Users();
            List<tblUser> userList = users.GetAllUsers();
            var list = userList.Where(x => x.Email == email).ToList();
            //if exists employee with forwarded email, return false
            if (list.Count() > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}