using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class ManagerViewModel : BaseViewModel
    {
        ManagerView managerView;
        Managers managers = new Managers();

        private vwManager manager;

        public vwManager Manager
        {
            get
            {
                return manager;
            }
            set
            {
                manager = value;
            }
        }

        private vwEmployee employee;

        public vwEmployee Employee
        {
            get
            {
                return employee;
            }
            set
            {
                employee = value;
                OnPropertyChanged("Employee");
            }
        }

        private List<vwEmployee> employeeList;

        public List<vwEmployee> EmployeeList
        {
            get
            {
                return employeeList;
            }
            set
            {
                employeeList = value;
                OnPropertyChanged("EmployeeList");
            }
        }

        private Visibility isVisibleEmployeeData = Visibility.Collapsed;
        public Visibility IsVisibleEmployeeData
        {
            get
            {
                return isVisibleEmployeeData;
            }
            set
            {
                isVisibleEmployeeData = value;
                OnPropertyChanged("IsVisibleEmployeeData");
            }
        }

        private ICommand viewAllEmployees;

        public ICommand ViewAllEmployees
        {
            get
            {
                if (viewAllEmployees == null)
                {
                    viewAllEmployees = new RelayCommand(param => ViewAllEmployeesExecute(), param => CanViewAllEmployeesExecute());
                }
                return viewAllEmployees;
            }
        }

        public ManagerViewModel(ManagerView managerView, vwManager manager)
        {
            this.managerView = managerView;
            this.manager = manager;
        }

        public void ViewAllEmployeesExecute()
        {
            IsVisibleEmployeeData = Visibility.Visible;
            EmployeeList = managers.GetEmployees(manager);
        }
        public bool CanViewAllEmployeesExecute()
        {
            return true;
        }
    }
}