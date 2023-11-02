using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassModel;


namespace ClassLibrary_DataAccessLayer
{
    public interface IEmpDataManager
    {
        int AddEmployee_DAL(int e_Id, string e_Name,int salary, string e_Address, string e_Contact, DateTime e_Dob);

        int EditEmployee_DAL(Employee employee);

        int DeleteEmployee_DAL(int e_Id);

        int ViewAllEmployee_DAL();

        Employee GetEmployeeById_DAL(int id);
       

    }
}
