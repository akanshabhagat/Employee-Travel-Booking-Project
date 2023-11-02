using ClassModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_DataAccessLayer
{
    public interface IReqDataManager
    {
        int RaiseRequest_DAL(int Req_Id,int Emp_Id, DateTime Req_Date, string From_Location, string To_Location);

        int EditRequest_DAL(TravelRequest travelRequest);

        int DeleteRequest_DAL(int Req_Id);

        int ApproveRequest_DAL(int Travel_Id,ApproveStatus appstatus);

        int ConfirmRequest_DAL(int Travel_Id, BookingStatus bookstatus);

        int ViewAllRequest_DAL();

        int ViewJoinReqTable_DAL();

        int ViewAllApprovedRequest_DAL();

        int ViewAllPendingRequest_DAL();

        int ViewAllRequestByMonth_DAL(int month);


        int ViewAllRequestByFromLoc_DAL(string FromLoc);

        int ViewAllRequestByToLoc_DAL(string ToLoc);

    }
}
