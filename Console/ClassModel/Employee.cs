using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassModel
{
    public class Employee
    {
        public int Emp_Id { get; set; }
        public string Emp_Name { get; set; }
        public int Emp_Salary {  get; set; }
        public string Emp_Address {  get; set; }
        public string Emp_Contact {  get; set; }
        public DateTime Emp_Dob { get; set; }


        /* public Employee(int id, string name,int salary, string Address, string Contact, DateTime Dob)
           { 
             Emp_Id = id;
             Emp_Name = name;
             Emp_Salary = salary;
             Emp_Address = Address;
             Emp_Contact = Contact;
             Emp_Dob = Dob;

           }*/

        public override string ToString()
        {

            /*Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-10} {4,-10} {5,-10}", "Emp Id", "Name", "Salary", "Address", "Contact", "DOB");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------");

            Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-10} {4,-10} {5,-10}", Emp_Id, Emp_Name, Emp_Salary, Emp_Address, Emp_Contact, Emp_Dob);
            Console.WriteLine();*/

            return string.Format("{0,-0}| {1,-10}| {2,-10}| {3,-10}| {4,-15}| {5,-20}| {6,-20}|",
                "", Emp_Id, Emp_Name, Emp_Salary, Emp_Address, Emp_Contact, Emp_Dob);
                
            
        }

        /*public Object this[int index]
        {

            get
            {
                if (index == 0)
                    return Emp_Id;
                else if (index == 1)
                    return Emp_Name;
                else if (index == 2)
                    return Emp_Salary;
                else if (index == 3)
                    return Emp_Address;
                else if (index == 4)
                    return Emp_Contact;
                else if (index == 5)
                    return Emp_Dob;
                return null;

            }
            set
            {
                if (index == 0)
                    Emp_Id = (int)value;
                else if (index == 1)
                    Emp_Name = (string)value;
                else if (index == 2)
                    Emp_Salary = (int)value;
                else if (index == 3)
                    Emp_Address = (string)value;
                else if (index == 4)
                    Emp_Contact = (string)value;
                else if (index == 5)
                   Emp_Dob = (DateTime)value;
            }
        }*/

    }
}
