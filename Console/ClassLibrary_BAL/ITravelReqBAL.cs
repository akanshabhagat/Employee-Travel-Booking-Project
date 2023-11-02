using ClassModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_BAL
{
    public interface ITravelReqBAL
    {
        int RaiseRequest_BAL(int Req_Id, int Emp_Id, DateTime Req_Date, string From_Location, string To_Location);

        int EditRequest_BAL(TravelRequest travelRequest);

        int DeleteRequest_BAL(int Req_Id);

        int ApproveRequest_BAL(int Travel_Id, ApproveStatus appstatus);

        int ConfirmRequest_BAL(int Travel_Id, BookingStatus bookstatus);

        int ViewAllRequest_BAL();

        int ViewJoinReqTable_BAL();

        int ViewAllApprovedRequest_BAL();

        int ViewAllPendingRequest_BAL();

       int  ViewAllRequestByMonth_BAL(int month);

        int ViewAllRequestByFromLoc_BAL(string FromLoc);

        int ViewAllRequestByToLoc_BAL(string ToLoc);
    }
}
