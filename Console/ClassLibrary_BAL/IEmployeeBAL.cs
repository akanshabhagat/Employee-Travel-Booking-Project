using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassModel;

namespace ClassLibrary_BAL
{
    public interface IEmployeeBAL
    {
        int AddEmployee_BAL(int e_Id, string e_Name, int salary, string e_Address, string e_Contact, DateTime e_Dob);

        int EditEmployee_BAL(Employee employee);

        int DeleteEmployee_BAL(int e_Id);

        int ViewAllEmployee_BAL();

        Employee GetEmployeeById_BAL(int id);
    }
}
