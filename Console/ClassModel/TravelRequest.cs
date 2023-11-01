using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassModel
{

    public enum ApproveStatus { Approved, NotApproved, Pending }
   public  enum BookingStatus { Booked, NotAvailable ,Pending}
    public enum CurrentStatus { Open, Close }
    public class TravelRequest
    {

        public int Req_Id { get; set; }
        public DateTime Req_Date { get; set; }
        public string From_Location {  get; set; }

        public string To_Location { get; set; }
        public int Emp_Id {  get; set; }
        public ApproveStatus Approved_Status {  get; set; }
        public BookingStatus Booking_Status { get; set; }
        public CurrentStatus Request_Status { get; set; }


       /* public TravelRequest(int Req_Id, int Emp_Id, DateTime Req_Date, string From_Location, string To_Location)
        {
            this.Req_Id = Req_Id;
            this.Emp_Id = Emp_Id;
            this.Req_Date = Req_Date;
            this.From_Location = From_Location;
            this.To_Location = To_Location;
            Approved_Status = "Pending";
            Request_Status = "Open";

        }*/

        public override string ToString()
        {
            //return string.Format("{0,-0} {1,-10} {2,-10} {3,-10} {4,-10} {5,-20} {6,-20}",
            //   "", Emp_Id, Emp_Name, Emp_Salary, Emp_Address, Emp_Contact, Emp_Dob);

            return string.Format("|{0,-12}|{1,-10}|{2,-10}|{3,-14}|{4,-20}|{5,-15}|{6,-20}|{7,20}| "
                , Req_Id,Emp_Id,From_Location,To_Location,Approved_Status,Request_Status, Req_Date,Booking_Status);
        }


    }
}
