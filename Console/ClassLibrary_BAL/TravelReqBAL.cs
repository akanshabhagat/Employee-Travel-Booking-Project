using ClassLibrary_DataAccessLayer;
using ClassModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_BAL
{
    public class TravelReqBAL
    {
        private readonly ReqDataManager _travelreqData = new ReqDataManager();

        public int RaiseRequest_BAL(int Req_Id, int Emp_Id, DateTime Req_Date, string From_Location, string To_Location)
        {
            _travelreqData.RaiseRequest_DAL(Req_Id,Emp_Id,Req_Date,From_Location,To_Location);
            return 1;
        }



        public int EditRequest_BAL(TravelRequest travelRequest)
        {
            _travelreqData.EditRequest_DAL(travelRequest);
            return 1;
        }

        public int DeleteRequest_BAL(int Req_Id)
        {
            _travelreqData.DeleteRequest_DAL(Req_Id);
            return 1;
        }

        public int ApproveRequest_BAL(int Travel_Id, ApproveStatus appstatus)
        {
            _travelreqData.ApproveRequest_DAL(Travel_Id,appstatus);
            return 1;
        }



        public int ConfirmRequest_BAL(int Travel_Id, BookingStatus bookstatus)
        {
            _travelreqData.ConfirmRequest_DAL(Travel_Id,bookstatus);
            return 1;
        }

        public int ViewAllRequest_BAL()
        {
            _travelreqData.ViewAllRequest_DAL();
            return 1;
        }


        public int ViewJoinReqTable_BAL()
        {
            _travelreqData.ViewJoinReqTable_DAL();
            return 1;
        }

        public TravelRequest GetReqById_BAL(int reqid)
        {
            TravelRequest TravelReq = _travelreqData.GetRequestById_DAL(reqid);

            return TravelReq;
            

        }

        public int ViewAllApprovedRequest_BAL()
        {
            _travelreqData.ViewAllApprovedRequest_DAL();
            return 1;
        }

        public int ViewAllPendingRequest_BAL()
        {
            _travelreqData.ViewAllPendingRequest_DAL();
            return 1;
        }

        public int ViewAllRequestByMonth_BAL(int month)
        {
            _travelreqData.ViewAllRequestByMonth_DAL(month);
            return 1;
        }

        public int ViewAllRequestByFromLoc_BAL(string FromLoc)
        {
            _travelreqData.ViewAllRequestByFromLoc_DAL(FromLoc);
            return 1;

        }

        public int ViewAllRequestByToLoc_BAL(string ToLoc)
        {
            _travelreqData.ViewAllRequestByToLoc_DAL(ToLoc);
            return 1;
        }


    }
}
