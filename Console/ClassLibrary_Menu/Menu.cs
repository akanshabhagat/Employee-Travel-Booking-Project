using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_BAL;
using ClassModel;

namespace ClassLibrary_Menu
{
    public class Menu
    {
         private static readonly EmployeeBAL _empManager = new EmployeeBAL();
         private static readonly TravelReqBAL _travelreqManager = new TravelReqBAL();

        public static void ShowMenu()
        {
            int choice;
           // EmployeeBAL employeeBAL = new EmployeeBAL();

            Console.WriteLine("\n********************* Welcome to the Travel Booking System ***********************\n");
            //Console.WriteLine("-----------------------------------");
            //Console.WriteLine("           Main Menu");
            //Console.WriteLine("-----------------------------------");

            try
            {
                do
                {
                    Console.WriteLine("\n-----------------------------------");
                    Console.WriteLine("           Main Menu");
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine(" 1. Manage Employee\n 2. Manage Travel Request\n 3. Exit");
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Select Choice 1 to 3\n");

                    choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            ShowEmployeeMgmt();
                            break;

                        case 2:
                            ShowTravelMgmt();
                            break;

                        case 3:
                            Console.WriteLine("\nThank You For using this application!!");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Please Enter Correct Choice!!!\n");
                            break;

                    }
                }while(choice != 3); 
            }

            catch(Exception ex)
            {
                Console.WriteLine("Please Select Correct Choice!!");
                Console.WriteLine(ex.Message);
            }

        }

        
        
      public static void ShowEmployeeMgmt()
        {

            //Console.WriteLine("\n-----------------------------------");
            //Console.WriteLine("   Welcome to Manage Employee");
            //Console.WriteLine("-----------------------------------");
            int choice1;

            try
            {
                do
                {
                    Console.WriteLine("\n-----------------------------------");
                    Console.WriteLine("   Welcome to Manage Employee");
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine(" 1. Add Employee\n 2. View Employee\n 3. Edit Employee\n 4. Delete Employee\n 5. Go Back\n 6. Exit");
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Select any option from 1 to 6:");
                    choice1 = int.Parse(Console.ReadLine());
                    switch (choice1)
                    {
                        case 1:
                            Console.WriteLine("Add Employee");
                            ShowAddEmployee();
                            break;
                        case 2:
                            Console.WriteLine("View Employee");
                            ShowViewEmployee();
                            break;
                        case 3:
                            Console.WriteLine("Edit Employee");
                            ShowEditEmployee();
                            break;
                        case 4:
                            Console.WriteLine("Delete Employee");
                            ShowDeleteEmployee();
                            break;
                        case 5:
                            Console.WriteLine("Go Back");
                            ShowMenu();
                            //ShowEmployeeMgmt();
                            break;
                        case 6:
                            //Console.WriteLine("Exit");
                            Console.WriteLine("\nThank You For using this application!!");
                            break;
                    }
                }while (choice1 != 6);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please Select Correct Choice!!");
                Console.WriteLine(ex.Message);
            }

        }

        public static void ShowTravelMgmt()
        {
            //Console.WriteLine("\n-------------------------------------");
            //Console.WriteLine(" Welcome to Manage Travel Booking");
            //Console.WriteLine("-------------------------------------");
            int choice2;

            try
            {
                do
                {
                    Console.WriteLine("\n-------------------------------------");
                    Console.WriteLine(" Welcome to Manage Travel Booking");
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine(" 1.  Raise Travel Request\n 2.  View Travel Request\n 3.  Edit Travel Request\n 4.  Delete Travel Request\n 5.  Approve Status\n 6.  Confirm Status\n 7.  View All Approved\n 8.  View Travel Req By Month\n 9.  View Travel Req By From Location\n 10. View Travel Req By To Location\n 11. Go Back\n 12. Exit");
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine("Select any option from 1 to 12:");
                    choice2 = int.Parse(Console.ReadLine());
                    switch (choice2)
                    {
                        case 1:
                            Console.WriteLine("Raise Travel Request");
                            ShowRaiseTravelRequest();
                            break;
                        case 2:
                            Console.WriteLine("View Travel Request");
                            ShowViewAllTravelRequest();
                            break;
                        case 3:
                            Console.WriteLine("Edit Travel Request");
                            ShowEditTravelRequest();
                            break;
                        case 4:
                            Console.WriteLine("Delete Travel Request");
                            ShowDeleteTravelRequest();
                            break;
                        case 5:
                            Console.WriteLine("Approve Travel Request");
                            ShowApprovedTravelRequest();
                            break;
                        case 6:
                            Console.WriteLine("Confirm Travel Request");
                            ShowConfirmBooking();
                            break;
                        case 7:
                            Console.WriteLine("View Approved Request");
                            ShowApprovedTravelRequest();
                            break;
                        case 8:
                            Console.WriteLine("View Request By Month");
                            //ShowApprovedTravelRequest();
                            ShowAllRequestByMonth();
                            break;
                        case 9:
                            Console.WriteLine("View Request By From Location");
                            ShowAllRequestByFromLoc();
                            break;
                        case 10:
                            Console.WriteLine("View Request By To Location");
                            ShowAllRequestByToLoc();
                            break;
                        case 11:
                            Console.WriteLine("Go Back");
                            //ShowTravelMgmt();
                            ShowMenu();
                            break;
                        case 12:
                            //Console.WriteLine("Exit");
                            Console.WriteLine("\nThank You For using this application!!");
                            break;
                    }
                } while (choice2 != 12);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Please Select Correct Choice!!");
                Console.WriteLine(ex.Message);
            }
        }

        
        public static void ShowAddEmployee()
        {
            int EmpID;
            String Emp_Name, Address, Contact;
            int Salary;
            DateTime DOB;

            Console.WriteLine("------------------------------");
            Console.WriteLine("        Add Employee");
            Console.WriteLine("------------------------------");

            Console.WriteLine("Enter Employee ID: \n");
            EmpID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Name: \n");
            Emp_Name = Console.ReadLine();

            Console.WriteLine("Enter Salary: \n");
            Salary = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Address: \n");
            Address = Console.ReadLine();

            Console.WriteLine("Enter Contact: \n");
            Contact = Console.ReadLine();

            Console.WriteLine("Enter DOB: \n");
            DOB = DateTime.Parse(Console.ReadLine());

            //EmployeeBAL employeeBALL = new EmployeeBAL();

            _empManager.AddEmployee_BAL(EmpID,Emp_Name,Salary,Address,Contact,DOB);

            //Console.WriteLine("You entered {0}, {1}, {2}, {3}, {4}, {5}", EmpID, Emp_Name, Salary, Address, Contact, DOB);

            _empManager.ViewAllEmployee_BAL();
        }

        public static void ShowEditEmployee()
        {
            //int EmpID;
            String Emp_Name, Address, Contact;
            int Salary;
            DateTime DOB;

            int choice1;

            Employee emp_to_Change = new Employee();


            //EmployeeBAL employeeBAL = new EmployeeBAL();
            //_empManager.ViewAllEmployee_BAL();

            try
            {
                do
                {
                    _empManager.ViewAllEmployee_BAL();


                    Console.WriteLine("------------------------------");
                    Console.WriteLine("       Edit Employee");
                    Console.WriteLine("------------------------------");

                    Console.WriteLine("Enter the Employee Id to Edit or 0 to Go Back\n");
                    int Edit_EmpId = int.Parse(Console.ReadLine());

                    if (Edit_EmpId == 0)
                    {
                        //Environment.Exit(0);
                        ShowEmployeeMgmt();

                    }


                    emp_to_Change = _empManager.GetEmployeeById_BAL(Edit_EmpId);

                    Console.WriteLine(" 1.Edit Name\n 2.Edit Salary\n 3.Edit Address\n 4.Edit Contact\n 5.Edit DOB\n 6. Go Back");
                    Console.WriteLine("Select Choice 1 to 6\n");

                    choice1 = int.Parse(Console.ReadLine());

                    switch (choice1)
                    {

                        case 1:
                            Console.WriteLine("Enter New Employee Name: \n");
                            Emp_Name = Console.ReadLine();
                            emp_to_Change.Emp_Name = Emp_Name;
                            break;

                        case 2:
                            Console.WriteLine("Enter New Employee Salary: \n");
                            Salary = int.Parse(Console.ReadLine());
                            emp_to_Change.Emp_Salary = Salary;
                            break;

                        case 3:
                            Console.WriteLine("Enter New Employee Address: \n");
                            Address = Console.ReadLine();
                            emp_to_Change.Emp_Address = Address;
                            break;

                        case 4:
                            Console.WriteLine("Enter New Employee Contact: \n");
                            Contact = Console.ReadLine();
                            emp_to_Change.Emp_Contact = Contact;
                            break;

                        case 5:
                            Console.WriteLine("Enter New Employee DOB: \n");
                            DOB = DateTime.Parse(Console.ReadLine());
                            emp_to_Change.Emp_Dob = DOB;
                            break;

                        case 6:
                            Environment.Exit(0);
                            Console.WriteLine("Go back");
                            //ShowEmployeeMgmt();
                            break;
                        default:
                            Console.WriteLine("Wrong Choice");
                            break;
                    }

                } while (choice1 != 6);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Please Select Correct Choice!!");
                Console.WriteLine(ex.Message);
            }

            _empManager.EditEmployee_BAL(emp_to_Change);
            //_empManager.ViewAllEmployee_BAL();


        }

        public static void ShowDeleteEmployee()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("   Delete Travel Request");
            Console.WriteLine("------------------------------");


            Console.WriteLine("View All Employee\n");
            EmployeeBAL employeeBALL = new EmployeeBAL();
            employeeBALL.ViewAllEmployee_BAL();

            Console.WriteLine("Select employee to delete\n");
            Console.WriteLine("Enter Emp Id to delete:");
            int delEmp_Id = int.Parse(Console.ReadLine());

            _empManager.DeleteEmployee_BAL(delEmp_Id);
            Console.WriteLine("The Employee with Id {0} has been deleted!!",delEmp_Id);
        }

        public static void ShowViewEmployee()
        {
            //Console.WriteLine("------------------------------");
            //Console.WriteLine("     View All Employee");
            //Console.WriteLine("------------------------------");
            //EmployeeBAL employeeBAL = new EmployeeBAL();
            _empManager.ViewAllEmployee_BAL();
        }

        
        public static void ShowRaiseTravelRequest()
        {
            int EmpID, ReqID;
            String FLoc, TLoc;
            DateTime Req_Date;

            
            Console.WriteLine("------------------------------");
            Console.WriteLine("    Raise Travel Request");
            Console.WriteLine("------------------------------");

            //Console.WriteLine("View All Employee\n");
            _empManager.ViewAllEmployee_BAL();
            //Console.WriteLine("View All Travel Request\n");
            _travelreqManager.ViewAllRequest_BAL();
           // _travelreqManager.ViewJoinReqTable_BAL();

            Console.WriteLine("Enter The Employee Id to Raise Travel Request");
             EmpID = int.Parse(Console.ReadLine());

            //Console.WriteLine("Enter Empolyee ID: \n");
            //EmpID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Request ID: \n");
            ReqID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter From Location: \n");
            FLoc = Console.ReadLine();

            Console.WriteLine("Enter To Location: \n");
            TLoc = Console.ReadLine();

            Console.WriteLine("Enter Request Date: \n");
            Req_Date = DateTime.Parse(Console.ReadLine());

           
            _travelreqManager.RaiseRequest_BAL(ReqID,EmpID, Req_Date, FLoc, TLoc);
            //Console.WriteLine("You entered {0}, {1}, {2}, {3}, {4}", ReqID, EmpID, Req_Date, FLoc, TLoc);

           
            _travelreqManager.ViewAllRequest_BAL();
        }

        public static void ShowEditTravelRequest()
        {
            //int EmpId, ReqID;
            String  FLoc, TLoc;
            DateTime Req_Date;
           
            TravelRequest req_to_Change = new TravelRequest();
            int choice2;

            do
            {
                _travelreqManager.ViewAllRequest_BAL();

                Console.WriteLine("------------------------------");
                Console.WriteLine("   Edit Travel Request");
                Console.WriteLine("------------------------------");

                //Console.WriteLine("View All Travel Request");

                Console.WriteLine("Enter the Request Id to Edit  Travel Request or 0 to Go Back\n");
                int Edit_ReqId = int.Parse(Console.ReadLine());

                if (Edit_ReqId == 0)
                {
                    //Environment.Exit(0);
                    ShowTravelMgmt();

                }

                
                req_to_Change = _travelreqManager.GetReqById_BAL(Edit_ReqId);


                Console.WriteLine(" 1.Edit Travel Date\n 2.Edit From Location\n 3.Edit To Location\n 4. Go Back");
                Console.WriteLine("Select Choice 1 to 7\n");

                choice2 = int.Parse(Console.ReadLine());

                switch (choice2)
                {

                    case 1:
                         Console.WriteLine("Enter New Travel Date: \n");
                        Req_Date = DateTime.Parse(Console.ReadLine());
                        req_to_Change.Req_Date = Req_Date;
                        break;
                       

                    case 2:
                        Console.WriteLine("Enter New From Location: \n");
                        FLoc = Console.ReadLine();
                        req_to_Change.From_Location = FLoc;
                        break;


                    case 3:
           
                        Console.WriteLine("Enter New To Location: \n");
                        TLoc = Console.ReadLine();
                        req_to_Change.To_Location = TLoc;
                        break;


                    case 4:
                        Console.WriteLine("Go back");
                        break;

                }
            } while (choice2 != 4);

            _travelreqManager.EditRequest_BAL(req_to_Change);
        }

        public static void ShowViewAllTravelRequest()
        {
            // Console.WriteLine("------------------------------");
            // Console.WriteLine("    View Travel Request");
            // Console.WriteLine("------------------------------");
            //_travelreqManager.ViewAllRequest_BAL();
           
           // _travelreqManager.ViewAllRequest_BAL();
            _travelreqManager.ViewJoinReqTable_BAL();

            //Console.WriteLine("Show Approved");
            
        }

        public static void ShowDeleteTravelRequest()
        {

            
            //Console.WriteLine("View All Travel Request\n");
            _travelreqManager.ViewAllRequest_BAL();

            Console.WriteLine("------------------------------");
            Console.WriteLine("   Delete Travel Request");
            Console.WriteLine("------------------------------");

            Console.WriteLine("Enter Travel Request Id to delete\n");
            int TravelReqId = int.Parse(Console.ReadLine());
            _travelreqManager.DeleteRequest_BAL(TravelReqId);
           
            
            //_travelreqManager.ViewAllRequest_BAL();

        }


        public static void ShowApprovedTravelRequest()
        {
            int choice2;

            _travelreqManager.ViewAllPendingRequest_BAL();
            do
            {
                Console.WriteLine("\n------------------------------");
                Console.WriteLine("  Approved Travel Requests");
                Console.WriteLine("------------------------------");


                //Console.WriteLine("Display all not approved travel requests");
                //_travelreqManager.ViewJoinReqTable_BAL();
                Console.WriteLine("\n Enter the Travel Request Id to Approve Booking or 0 to Goback");
                int Req_Id = int.Parse(Console.ReadLine());

                if(Req_Id ==0)
                {
                    ShowTravelMgmt();
                }

                //Console.WriteLine("\n Change the Approve Booking Status");
                //string approvestatus = Console.ReadLine();
                //Enum approvestatus = Enum.Parse(Console.ReadLine());

                Console.WriteLine("Select any option from 1 to 4:");
                Console.WriteLine(" 1. Approve\n 2. Not Approved\n 3. Go Back\n 4. Exit");
                
                choice2 = int.Parse(Console.ReadLine());
                switch (choice2)
                {
                    case 1:
                        Console.WriteLine("Raise Travel Status changed to Approved");
                        _travelreqManager.ApproveRequest_BAL(Req_Id, ApproveStatus.Approved);
                        break;
                    case 2:
                        Console.WriteLine("Raise Travel Request changed to Not Approved");
                        _travelreqManager.ApproveRequest_BAL(Req_Id, ApproveStatus.NotApproved);
                        break;
                    case 3:
                        Console.WriteLine("Go Back");
                        ShowTravelMgmt();
                        break;
                    case 4:
                        Console.WriteLine("Exit");
                        Environment.Exit(0);
                        break;
                }
                _travelreqManager.ViewJoinReqTable_BAL();
            } while (choice2 != 4);
            
        }

        public static void ShowConfirmBooking()
        {
           
            int choice2;

            try
            {
                do
                {
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("Confirm Booking of Travel Requests");
                    Console.WriteLine("--------------------------------------");
                    //_travelreqManager.ViewJoinReqTable_BAL();
                    _travelreqManager.ViewAllApprovedRequest_BAL();
                    //Console.WriteLine("Display all approved travel requests");
                    Console.WriteLine("\n Enter the Travel Request Id to Confirm Booking  or 0 to go back");
                    int Req_Id = int.Parse(Console.ReadLine());

                    if (Req_Id == 0)
                    {
                        ShowTravelMgmt();
                    }

                    

                    //Console.WriteLine("\n Change the Confirm Booking Status");

                    Console.WriteLine("Select any option from 1 to 4:");
                    Console.WriteLine(" 1. Booked\n 2. Not Available\n 3. Go Back\n 4. Exit");

                    choice2 = int.Parse(Console.ReadLine());
                    switch (choice2)
                    {
                        case 1:
                            
                            _travelreqManager.ConfirmRequest_BAL(Req_Id, BookingStatus.Booked);
                            //Console.WriteLine("Raise Travel Status changed to Booked");
                            break;
                        case 2:
                            Console.WriteLine("Raise Travel Request changed to Not Available");
                            _travelreqManager.ConfirmRequest_BAL(Req_Id, BookingStatus.NotAvailable);
                            break;
                        case 3:
                            Console.WriteLine("Go Back");
                            ShowTravelMgmt();
                            break;
                        case 4:
                            Console.WriteLine("Exit");
                            Environment.Exit(0);
                            break;
                    }
                } while (choice2 != 4);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nPlease Select Correct Choice!!");
                Console.WriteLine("Please Enter Req Id From above table\n");
                Console.WriteLine(ex.Message);
            }
        }

        public static void ShowAllRequests()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("   All Travel Requests");
            Console.WriteLine("------------------------------");
        }

        public static void ShowOpenRequest()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("    Open Travel Requests");
            Console.WriteLine("------------------------------");

        }

        public static void ShowClosedRequest()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("   Closed Travel Requests");
            Console.WriteLine("------------------------------");
        }

        public static void ShowAllApprovedRequest()
        {
            /*Console.WriteLine("------------------------------");
            Console.WriteLine("    Approved Travel Requests");
            Console.WriteLine("------------------------------");
            _travelreqManager.ViewAllApprovedRequest_BAL();*/

        }

        public static void ShowAllRequestByMonth()
        {
            Console.WriteLine("Enter the month in numeric format: ");
            int month = int.Parse(Console.ReadLine());
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("    All Travel Requests By Month");
            Console.WriteLine("-----------------------------------");
            _travelreqManager.ViewAllRequestByMonth_BAL(month);

        }

        public static void ShowAllRequestByFromLoc()
        {
            Console.WriteLine("\nEnter the From Location: ");
            string FromLoc = Console.ReadLine();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("    All Travel Requests By From Location");
            Console.WriteLine("-------------------------------------------");
            _travelreqManager.ViewAllRequestByFromLoc_BAL(FromLoc);

        }

        public static void ShowAllRequestByToLoc()
        {
            Console.WriteLine("\nEnter the To Location: ");
            string ToLoc = Console.ReadLine();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("    All Travel Requests By To Location");
            Console.WriteLine("-------------------------------------------");
            _travelreqManager.ViewAllRequestByToLoc_BAL(ToLoc);

        }




    }
}
