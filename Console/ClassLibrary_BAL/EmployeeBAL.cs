
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_DataAccessLayer;
using ClassModel;

namespace ClassLibrary_BAL
{
    public class EmployeeBAL
    {
        private readonly EmpDataManager _empData = new EmpDataManager();

        //EmpDataManager empDataManager = new EmpDataManager();
        public int AddEmployee_BAL(int e_Id, string e_Name, int salary, string e_Address, string e_Contact, DateTime e_Dob)
        {
            _empData.AddEmployee_DAL(e_Id,e_Name,salary,e_Address,e_Contact,e_Dob);
            return 1;
        }



        public int EditEmployee_BAL(Employee employee_to_Change)
        {
            //empDataManager.GetEmpById(employee.Emp_Id);


            _empData.EditEmployee_DAL(employee_to_Change);
            return 1;
        }

        public int DeleteEmployee_BAL(int e_Id)
        {
            _empData.DeleteEmployee_DAL(e_Id);
            return 1;
        }

        public int ViewAllEmployee_BAL()
        {

            _empData.ViewAllEmployee_DAL();
            return 1;
        }

        public Employee GetEmployeeById_BAL(int id)
        {
            Employee Emp = _empData.GetEmployeeById_DAL(id);

            //if(empDataManager != null)
            //{
                return Emp;
            //}
            
            // return new Employee();
              
        }
    }
}
