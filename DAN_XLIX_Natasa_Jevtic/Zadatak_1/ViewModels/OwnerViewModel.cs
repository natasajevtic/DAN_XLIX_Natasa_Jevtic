using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Validations;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class OwnerViewModel : BaseViewModel
    {
        OwnerView ownerView;
        Users users = new Users();
        Validation validation = new Validation();
        Managers managers = new Managers();
        Employees employees = new Employees();

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
                OnPropertyChanged("Manager");
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

        private List<string> levelPQList;

        public List<string> LevelPQList
        {
            get
            {
                return levelPQList;
            }
            set
            {
                levelPQList = value;
                OnPropertyChanged("LevelPQList");
            }
        }

        private List<string> genderList;

        public List<string> GenderList
        {
            get
            {
                return genderList;
            }
            set
            {
                genderList = value;
                OnPropertyChanged("GenderList");
            }
        }

        private List<string> engagementList;

        public List<string> EngagementList
        {
            get
            {
                return engagementList;
            }
            set
            {
                engagementList = value;
                OnPropertyChanged("EngagementList");
            }
        }


        private Visibility isVisibleAddingManager = Visibility.Hidden;
        public Visibility IsVisibleAddingManager
        {
            get
            {
                return isVisibleAddingManager;
            }
            set
            {
                isVisibleAddingManager = value;
                OnPropertyChanged("IsVisibleAddingManager");
            }
        }

        private Visibility isVisibleAddingEmployee = Visibility.Hidden;
        public Visibility IsVisibleAddingEmployee
        {
            get
            {
                return isVisibleAddingEmployee;
            }
            set
            {
                isVisibleAddingEmployee = value;
                OnPropertyChanged("IsVisibleAddingEmployee");
            }
        }

        private ICommand addManager;
        public ICommand AddManager
        {
            get
            {
                if (addManager == null)
                {
                    addManager = new RelayCommand(param => AddManagerExecute(), param => CanAddManagerExecute());
                }
                return addManager;
            }
        }

        private ICommand addEmployee;
        public ICommand AddEmployee
        {
            get
            {
                if (addEmployee == null)
                {
                    addEmployee = new RelayCommand(param => AddEmployeeExecute(), param => CanAddEmployeeExecute());
                }
                return addEmployee;
            }
        }

        private ICommand saveManager;
        public ICommand SaveManager
        {
            get
            {
                if (saveManager == null)
                {
                    saveManager = new RelayCommand(param => SaveManagerExecute(), param => CanSaveManagerExecute());
                }
                return saveManager;
            }
        }

        private ICommand cancelManager;
        public ICommand CancelManager
        {
            get
            {
                if (cancelManager == null)
                {
                    cancelManager = new RelayCommand(param => CancelManagerExecute(), param => CanCancelManagerExecute());
                }
                return cancelManager;
            }
        }

        private ICommand saveEmployee;
        public ICommand SaveEmployee
        {
            get
            {
                if (saveEmployee == null)
                {
                    saveEmployee = new RelayCommand(param => SaveEmployeeExecute(), param => CanSaveEmployeeExecute());
                }
                return saveEmployee;
            }
        }

        private ICommand cancelEmployee;
        public ICommand CancelEmployee
        {
            get
            {
                if (cancelEmployee == null)
                {
                    cancelEmployee = new RelayCommand(param => CancelEmployeeExecute(), param => CanCancelEmployeeExecute());
                }
                return cancelEmployee;
            }
        }

        public OwnerViewModel(OwnerView ownerView)
        {
            this.ownerView = ownerView;
            Manager = new vwManager();
            Employee = new vwEmployee();
            GenderList = users.GetGenders();
            EngagementList = users.GetEngagements();
            LevelPQList = users.GetLevelsPQ();
        }

        public void SaveManagerExecute()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to save the manager?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    bool isCreated = managers.AddManager(manager);
                    if (isCreated == true)
                    {
                        MessageBox.Show("Manager is created.", "Notification", MessageBoxButton.OK);
                        IsVisibleAddingManager = Visibility.Hidden;
                    }
                    else
                    {
                        MessageBox.Show("Manager cannot be created.", "Notification", MessageBoxButton.OK);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public bool CanSaveManagerExecute()
        {
            //checks if user input data valid  
            if (!String.IsNullOrEmpty(Manager.Name) && !String.IsNullOrEmpty(Manager.Surname) && !String.IsNullOrEmpty(Manager.DateOfBirth.ToString()) && !String.IsNullOrEmpty(Manager.Email)
                && !String.IsNullOrEmpty(Manager.Username) && !String.IsNullOrEmpty(manager.Password) && Int32.TryParse(Manager.HotelFloor.ToString(), out int floor) &&
                Int32.TryParse(Manager.ExperienceWorkingInHotels.ToString(), out int year) && year > 0 && !String.IsNullOrEmpty(Manager.ProfessionalQualifications))
            {
                if (validation.UniqueEmail(Manager.Email) == true && validation.UniqueUsername(Manager.Username) == true)
                {
                    if (validation.ValidationForEmail(Manager.Email) == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void CancelManagerExecute()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel creating the manager?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    IsVisibleAddingManager = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool CanCancelManagerExecute()
        {
            return true;
        }

        public void AddManagerExecute()
        {
            try
            {
                IsVisibleAddingEmployee = Visibility.Hidden;
                IsVisibleAddingManager = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool CanAddManagerExecute()
        {
            return true;
        }

        public void AddEmployeeExecute()
        {
            try
            {
                IsVisibleAddingManager = Visibility.Hidden;
                IsVisibleAddingEmployee = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool CanAddEmployeeExecute()
        {
            return true;
        }

        public void SaveEmployeeExecute()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to save the employee?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    bool canCreate = employees.CanCreate(employee);
                    if (canCreate == true)
                    {
                        bool isCreated = employees.AddEmployee(employee);
                        if (isCreated == true)
                        {
                            MessageBox.Show("Employee is created.", "Notification", MessageBoxButton.OK);
                            IsVisibleAddingEmployee = Visibility.Hidden;
                        }
                        else
                        {
                            MessageBox.Show("Employee cannot be created.", "Notification", MessageBoxButton.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Employee cannot be created, because there is no competent manager for this floor.", "Notification", MessageBoxButton.OK);
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public bool CanSaveEmployeeExecute()
        {
            //checks if user input data valid  
            if (!String.IsNullOrEmpty(Employee.Name) && !String.IsNullOrEmpty(Employee.Surname) && !String.IsNullOrEmpty(Employee.DateOfBirth.ToString()) && !String.IsNullOrEmpty(Employee.Email)
                && !String.IsNullOrEmpty(Employee.Username) && !String.IsNullOrEmpty(Employee.Password) && Int32.TryParse(Employee.HotelFloor.ToString(), out int floor)
                 && !String.IsNullOrEmpty(Employee.Engagement) && !String.IsNullOrEmpty(Employee.Gender)
                && !String.IsNullOrEmpty(Employee.Citizenship))
            {
                if (validation.UniqueEmail(Employee.Email) == true && validation.UniqueUsername(Employee.Username) == true)
                {
                    if (validation.ValidationForEmail(Employee.Email) == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void CancelEmployeeExecute()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel creating the employee?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    IsVisibleAddingEmployee = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool CanCancelEmployeeExecute()
        {
            return true;
        }
    }
}