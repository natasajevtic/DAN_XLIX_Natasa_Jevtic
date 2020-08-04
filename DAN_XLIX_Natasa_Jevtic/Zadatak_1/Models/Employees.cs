﻿using System;
using System.Diagnostics;
using System.Linq;

namespace Zadatak_1.Models
{
    class Employees
    {
        /// <summary>
        /// This method adds employees to DbSet and then save changes to database.
        /// </summary>
        /// <param name="employeeToAdd">Employee.</param>
        /// <returns>True if added, false if not.</returns>
        public bool AddEmployee(vwEmployee employeeToAdd)
        {
            try
            {
                using (HotelEntities context = new HotelEntities())
                {
                    tblUser user = new tblUser
                    {
                        DateOfBirth = employeeToAdd.DateOfBirth,
                        Email = employeeToAdd.Email,
                        Name = employeeToAdd.Name,
                        Password = employeeToAdd.Password,
                        Surname = employeeToAdd.Surname,
                        Username = employeeToAdd.Username
                    };
                    context.tblUsers.Add(user);
                    context.SaveChanges();
                    employeeToAdd.UserId = user.UserId;
                    tblEmployee employee = new tblEmployee
                    {
                        UserId = user.UserId,
                        Citizenship = employeeToAdd.Citizenship,
                        Engagement = employeeToAdd.Engagement,
                        Gender = employeeToAdd.Gender,
                        HotelFloor = employeeToAdd.HotelFloor,
                        Salary = null
                    };
                    context.tblEmployees.Add(employee);
                    context.SaveChanges();
                    employeeToAdd.EmployeeId = employee.EmployeeId;
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }
        /// <summary>
        /// This method checks if employee can be created.
        /// </summary>        /// 
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool CanCreate(vwEmployee employee)
        {
            try
            {
                using (HotelEntities context = new HotelEntities())
                {
                    //checks if exists competent manager for the floor
                    var managers = context.vwManagers.Where(x => x.HotelFloor == employee.HotelFloor).FirstOrDefault();
                    if (managers != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }
    }
}