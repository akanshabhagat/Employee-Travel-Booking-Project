
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ClassModel;

namespace ClassLibrary_DataAccessLayer
{
    public class EmpDataManager : IEmpDataManager
    {

        public List<Employee> lstemployees = new List<Employee>()
        {
            new Employee() { Emp_Id=1,Emp_Name="Akansha",Emp_Salary=60000,Emp_Address="Pune",Emp_Contact="9156576787",Emp_Dob=DateTime.Parse("07-05-1990")},
            new Employee() { Emp_Id=2,Emp_Name="Nikhil",Emp_Salary=50000,Emp_Address="Noida",Emp_Contact="9174567867",Emp_Dob=DateTime.Parse("09-02-2000")},
            new Employee() { Emp_Id=3,Emp_Name="Priya",Emp_Salary=60000,Emp_Address="Hyderabad",Emp_Contact="9172444399",Emp_Dob=DateTime.Parse("01-05-2002")},
            new Employee() { Emp_Id=4,Emp_Name="Shrushti",Emp_Salary=80000,Emp_Address="Pune",Emp_Contact="9167877667",Emp_Dob=DateTime.Parse("03-04-2001")},
            new Employee() { Emp_Id=5,Emp_Name="Janvi",Emp_Salary=20000,Emp_Address="Chennai",Emp_Contact="9156745678",Emp_Dob=DateTime.Parse("04-07-1999")},
            new Employee() { Emp_Id=6,Emp_Name="Riya",Emp_Salary=40000,Emp_Address="Noida",Emp_Contact="9145786723",Emp_Dob=DateTime.Parse("02-05-2000")},
            new Employee() { Emp_Id=7,Emp_Name="Sita",Emp_Salary=30000,Emp_Address="Pune",Emp_Contact="9167834567",Emp_Dob=DateTime.Parse("01-09-2001")}
        };



        public int AddEmployee_DAL(int e_Id, string e_Name,int e_salary, string e_Address, string e_Contact, DateTime e_Dob)
        {
            //create a new Employee Class
            //Employee emp = new Employee(e_Id, e_Name, e_salary, e_Address, e_Contact, e_Dob);


            foreach (Employee employee in lstemployees)
            {
                if(employee.Emp_Id == e_Id)
                {
                    Console.WriteLine("\nEmployee Id already exists please enter new or correct Employee Id!!!");
                    return 0;
                }      
            }

            lstemployees.Add(new Employee() { Emp_Id = e_Id, Emp_Name = e_Name, Emp_Salary = e_salary, Emp_Address = e_Address, Emp_Contact = e_Contact, Emp_Dob = e_Dob });
            Console.WriteLine("You entered {0}, {1}, {2}, {3}, {4}, {5}", e_Id, e_Name, e_salary, e_Address, e_Contact, e_Dob);

            //lstemployees.Add(new Employee() { Emp_Id=e_Id,Emp_Name=e_Name,Emp_Salary=e_salary,Emp_Address=e_Address,Emp_Contact=e_Contact,Emp_Dob=e_Dob});

            // In memory data


            //Console.WriteLine(emp.ToString());
            return 1;
      
        }



        public int EditEmployee_DAL(Employee employee_to_Change)
        {
            Console.WriteLine("In Edit - DAL");
            // Indexer - array

            // loop to search if id match of modified to old
            // if id match then update the modified obj to old lst
            // lst can access by array

            /*for(int i = 0;i < lstemployees.Count;i++)
            {
                if (lstemployees[i].Emp_Id == employee.Emp_Id)
                {
                    lstemployees[i]. = employee.Emp_Name;
                }
            }*/


            Employee emp_Main = lstemployees.FirstOrDefault(X => X.Emp_Id == employee_to_Change.Emp_Id);

            //int EmpId = querymethodedit.Emp_Id;

           int index = lstemployees.IndexOf(emp_Main);

            //if (querymethodedit != null)
            //{
                //lstemployees[index].Emp_Id = employee.Emp_Id;
                lstemployees[index].Emp_Name = employee_to_Change.Emp_Name;
                lstemployees[index].Emp_Salary = employee_to_Change.Emp_Salary;
                lstemployees[index].Emp_Address = employee_to_Change.Emp_Address;
                lstemployees[index].Emp_Contact = employee_to_Change.Emp_Contact;
                lstemployees[index].Emp_Dob = employee_to_Change.Emp_Dob;
            //}

            ViewAllEmployee_DAL();

            return 1;
        }

        public int DeleteEmployee_DAL(int e_Id)
        {
            Console.WriteLine("In Delete - DAL");

            var querymethoddelete = lstemployees.Remove(lstemployees.FirstOrDefault(emp=>emp.Emp_Id == e_Id));

            Console.WriteLine("Employee with Id {0} is deleted!!!",e_Id);

            ViewAllEmployee_DAL();


            return 1;
        }

        public int ViewAllEmployee_DAL()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                          View All Employees");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|{0,-12}|{1,-10}|{2,-10} |{3,-17}|{4,-20}|{5,-20}|", "Emp Id", "Name", "Salary", "Address", "Contact", "DOB");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------");

            foreach (Employee employee in lstemployees)
            {
                Console.WriteLine(employee.ToString());
                
            }
            return 1;

        }

       // getempbyid

        public Employee GetEmployeeById_DAL(int id)
        {
            Employee employee = lstemployees.FirstOrDefault(emp => emp.Emp_Id == id);

            if(employee != null)
            {
                return employee;
            }
            
            return null;
            
            
        }



    }
}
