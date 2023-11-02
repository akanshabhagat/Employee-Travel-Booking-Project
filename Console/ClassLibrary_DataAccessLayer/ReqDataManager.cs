using ClassModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_DataAccessLayer
{
    public class ReqDataManager : IReqDataManager
    {
     
        EmpDataManager empDataManager  =new EmpDataManager();
        //ReqDataManager ReqDManager = new ReqDataManager();

        public enum AllMonths {January = 1,February = 2, March =3,April=4, May=5, June=6, July=7, August=8, September=9,October=10, November=11,December=12 };

        List<TravelRequest> lsttravelRequests = new List<TravelRequest>()
        {
            new TravelRequest(){Req_Id=101,Emp_Id=1,Req_Date=DateTime.Parse("01-02-2020"),From_Location="Pune",To_Location="Hyderabad",Approved_Status=ApproveStatus.Pending,Booking_Status=BookingStatus.Pending,Request_Status=CurrentStatus.Open},
            new TravelRequest(){Req_Id=102,Emp_Id=2,Req_Date=DateTime.Parse("05-04-2021"),From_Location="Pune",To_Location="Chennai",Approved_Status=ApproveStatus.Pending,Booking_Status=BookingStatus.Pending,Request_Status=CurrentStatus.Open},
            new TravelRequest(){Req_Id=103,Emp_Id=3,Req_Date=DateTime.Parse("02-07-2023"),From_Location="Pune",To_Location="Hyderabad",Approved_Status=ApproveStatus.Pending,Booking_Status=BookingStatus.Pending,Request_Status=CurrentStatus.Open},
            new TravelRequest(){Req_Id=104,Emp_Id=4,Req_Date=DateTime.Parse("04-05-2021"),From_Location="Pune",To_Location="Noida",Approved_Status=ApproveStatus.Pending,Booking_Status=BookingStatus.Pending,Request_Status=CurrentStatus.Open},
            new TravelRequest(){Req_Id=105,Emp_Id=5,Req_Date=DateTime.Parse("07-06-2023"),From_Location="Noida",To_Location="Hyderabad",Approved_Status=ApproveStatus.Pending,Booking_Status=BookingStatus.Pending,Request_Status=CurrentStatus.Open},
            new TravelRequest(){Req_Id=106,Emp_Id=6,Req_Date=DateTime.Parse("09-04-2023"),From_Location="Noida",To_Location="Pune",Approved_Status=ApproveStatus.Pending,Booking_Status=BookingStatus.Pending,Request_Status=CurrentStatus.Open}
        };



        public int RaiseRequest_DAL(int Req_Id, int Emp_Id, DateTime Req_Date, string From_Location, string To_Location)
        {
            //TravelRequest TReq = new TravelRequest(Req_Id,Emp_Id,Req_Date,From_Location,To_Location);
            //Console.WriteLine(TReq.ToString());


            foreach (TravelRequest travelreq in lsttravelRequests)
            {
                if (travelreq.Req_Id == Req_Id)
                {
                    Console.WriteLine("\nRequest Id already exists please enter new or correct Request Id!!!");
                    return 0;
                }
            }

            lsttravelRequests.Add(new TravelRequest() { Req_Id=Req_Id,Emp_Id=Emp_Id,Req_Date=Req_Date,From_Location=From_Location,To_Location=To_Location,Approved_Status= ApproveStatus.Pending, Booking_Status = BookingStatus.Pending, Request_Status = CurrentStatus.Open });
            Console.WriteLine("You entered {0}, {1}, {2}, {3}, {4}", Req_Id, Emp_Id, Req_Date, From_Location, To_Location);

            return 1;
        }

        
        public int EditRequest_DAL(TravelRequest travelRequest)
        {
             Console.WriteLine("In Edit - DAL");

            TravelRequest travelreq_Main = lsttravelRequests.FirstOrDefault(X => X.Req_Id == travelRequest.Req_Id);

            int index = lsttravelRequests.IndexOf(travelreq_Main);


            lsttravelRequests[index].Req_Date = travelRequest.Req_Date;
            lsttravelRequests[index].To_Location = travelRequest.To_Location;
            lsttravelRequests[index].From_Location = travelRequest.From_Location;
            lsttravelRequests[index].Approved_Status = travelRequest.Approved_Status;
            lsttravelRequests[index].Request_Status = travelRequest.Request_Status;



           // ViewAllRequest_DAL();

            return 1;
        }

        public int DeleteRequest_DAL(int Req_Id)
        {
             Console.WriteLine("In Delete - DAL");

            var querymethoddelete = lsttravelRequests.Remove(lsttravelRequests.FirstOrDefault(travelreq => travelreq.Req_Id == Req_Id));

            Console.WriteLine("Travel Request with  Request Id {0} is deleted!!!", Req_Id);

            ViewAllRequest_DAL();

            return 1;
        }

        public int ApproveRequest_DAL(int Travel_Id, ApproveStatus appstatus)
        {
              Console.WriteLine("In Approve Request - DAL");
             

            var querymethodapprove = lsttravelRequests.FirstOrDefault(travelreq => travelreq.Req_Id == Travel_Id);
            // set travelreq.Approved_Status = appstatus);
            //var querymethodapprove = lsttravelRequests.FirstOrDefault(travelreq => travelreq.Req_Id == Travel_Id)
            //travelreq.Approved_Status = appstatus;
            //var query = from travelreq in lsttravelRequests where travelreq.Req_Id == Travel_Id;
            
            var query = querymethodapprove.Approved_Status = appstatus;

            if(querymethodapprove.Booking_Status == BookingStatus.NotAvailable && querymethodapprove.Approved_Status == appstatus)
            {
                querymethodapprove.Request_Status = CurrentStatus.Close;
            }
            //var query = querymethodapprove.
            //ViewJoinReqTable_DAL();

            if(querymethodapprove.Approved_Status == ApproveStatus.NotApproved)
            {
                querymethodapprove.Request_Status = CurrentStatus.Close;
            }

            return 1;
        }

        public int ConfirmRequest_DAL(int Travel_Id, BookingStatus bookstatus)
        {
             Console.WriteLine("In Confirm Requeat - DAL");

            var querymethodconfirm = lsttravelRequests.FirstOrDefault(travelreq => travelreq.Req_Id == Travel_Id);



            /*foreach (TravelRequest travelreq in lsttravelRequests)
            {
                if (Travel_Id != travelreq.Req_Id)
                {
                    break;
                }
            Console.WriteLine("Please Enter Req Id From above table");

            }*/


            bool result = querymethodconfirm.Approved_Status == ApproveStatus.Approved;

            if (result == true)
            {
                var query = querymethodconfirm.Booking_Status = bookstatus;
                Console.WriteLine("Raise Travel Status changed to Booked");
                ViewJoinReqTable_DAL();
            }
             else if(querymethodconfirm.Approved_Status == ApproveStatus.Pending)
            {
               Console.WriteLine("\nTravel Request has Not been Approved Yet!!!");
            }


            //CurrentStatus currentStatus =CurrentStatus.Open;


            

             if (querymethodconfirm.Booking_Status == BookingStatus.Booked || querymethodconfirm.Booking_Status == BookingStatus.NotAvailable)
             {
                querymethodconfirm.Request_Status = CurrentStatus.Close;
             }
            

            return 1;
        }



        public int ViewAllRequest_DAL()
        {
            Console.WriteLine("\n-----------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                         View All Travel Requests");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-12} {1,-10} {2,-10} {3,-10} {4,-20} {5,-20} {6,10} {7,30}", "Req Id", "Emp Id", "From Loc", "To Loc", "Approve status", "Current status","Req Date","Request Status");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------");
            foreach ( TravelRequest travelreq in lsttravelRequests)
            {
                Console.WriteLine(travelreq.ToString());
            }

            return 1;
        }


        public int ViewJoinReqTable_DAL()
        {
            Console.WriteLine("\n----------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                         View All Travel Requests");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|{0,-10}|{1,-10}|{2,-10}|{3,-10}|{4,-25}|{5,-10}|{6,-10}|{7,-10}|{8,-10}| {9,-10}|", "Emp Id", "Req Id", "Name", "Salary", "Req Date","From Loc", "To Loc","Approve Status","Booking Status","Current Status");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------");


            var querymethodview = from emp in empDataManager.lstemployees join req in lsttravelRequests
                                  on emp.Emp_Id equals req.Emp_Id
                                  select new
                                  {
                                      EId = emp.Emp_Id,
                                      ReqId = req.Req_Id,
                                      EName = emp.Emp_Name,
                                      ESalary = emp.Emp_Salary,
                                      EAddress = emp.Emp_Address,
                                      EContact = emp.Emp_Contact,
                                      ReqDate = req.Req_Date,
                                      FromLocation = req.From_Location,
                                      ToLocation = req.To_Location,
                                      ApproveStatus = req.Approved_Status,
                                      RequestStatus = req.Request_Status,
                                      CurrentStatus = req.Booking_Status,

    
                                  };

            foreach (var request in querymethodview)
            {
                Console.WriteLine("|{0,-10}|{1,-10}|{2,-10}|{3,-10}|{4,-25}|{5,-10}|{6,-10}|{7,-14}|{8,-15}|{9,-10}|", request.EId, request.ReqId, request.EName, request.ESalary, request.ReqDate, request.FromLocation, request.ToLocation, request.ApproveStatus,request.CurrentStatus, request.RequestStatus);
            }
            return 1;
        }

        public TravelRequest GetRequestById_DAL(int id)
        {
            TravelRequest TravelReq = lsttravelRequests.FirstOrDefault(req => req.Req_Id == id);

            if (TravelReq != null)
            {
                return TravelReq;
            }

            return null;


        }


        public int ViewAllApprovedRequest_DAL()
        {
            Console.WriteLine("\n------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                         View All Approved Travel Requests");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-12} {1,-10} {2,-10} {3,-10} {4,-20} {5,-20} {6,15} {7,10}", "Req Id", "Emp Id", "From Loc", "To Loc", "Approve status", "Current status", "Req Date", "           Request Status");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------");
            foreach (TravelRequest travelreq in lsttravelRequests)
            {
                if(travelreq.Approved_Status == ApproveStatus.Approved && travelreq.Request_Status == CurrentStatus.Open)
                {
                    Console.WriteLine(travelreq.ToString());
                }
            }
            return 1;
        }

        public int ViewAllPendingRequest_DAL()
        {

            Console.WriteLine("\n-----------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                         View All Travel Requests");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-12} {1,-10} {2,-10} {3,-10} {4,-20} {5,-20} {6,-10} {7,30}", "Req Id", "Emp Id", "From Loc", "To Loc", "Approve status", "Current status", "Req Date", "        Request Status");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------");
            foreach (TravelRequest travelreq in lsttravelRequests)
            {
                if (travelreq.Approved_Status == ApproveStatus.Pending && travelreq.Request_Status == CurrentStatus.Open)
                {
                    Console.WriteLine(travelreq.ToString());
                }
            }
            return 1;
            
        }


        public int ViewAllRequestByMonth_DAL(int month)
        {
            Console.WriteLine("\n-----------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                         View All Travel Requests By Month");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-12} {1,-10} {2,-10} {3,-10} {4,-20} {5,-20} {6,-10} {7,30}", "Req Id", "Emp Id", "From Loc", "To Loc", "Approve status", "Current status", "Req Date", "        Request Status");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------");
            
          
           
                
            foreach (TravelRequest travelreq in lsttravelRequests)
            {
                if (travelreq.Req_Date.Month == month)
                {
                    Console.WriteLine(travelreq.ToString());
                }
            }

            return 1;
        }

        public int ViewAllRequestByFromLoc_DAL(string FromLoc)
        {
            Console.WriteLine("\n-----------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                         View All Travel Requests By Month");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-12} {1,-10} {2,-10} {3,-10} {4,-20} {5,-20} {6,-10} {7,30}", "Req Id", "Emp Id", "From Loc", "To Loc", "Approve status", "Current status", "Req Date", "        Request Status");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------");



            foreach (TravelRequest travelreq in lsttravelRequests)
            {
                if (travelreq.From_Location == FromLoc)
                {
                    Console.WriteLine(travelreq.ToString());
                }
            }

            return 1;
        }

        public int ViewAllRequestByToLoc_DAL(string ToLoc)
        {
            Console.WriteLine("\n-----------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                         View All Travel Requests By Month");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-12} {1,-10} {2,-10} {3,-10} {4,-20} {5,-20} {6,-10} {7,30}", "Req Id", "Emp Id", "From Loc", "To Loc", "Approve status", "Current status", "Req Date", "        Request Status");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------");



            foreach (TravelRequest travelreq in lsttravelRequests)
            {
                if (travelreq.To_Location == ToLoc)
                {
                    Console.WriteLine(travelreq.ToString());
                }
            }
            return 1;
        }

    }
}

