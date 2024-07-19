using loginAuth.DTO;

namespace loginAuth
{
    public interface IRequestService
    {
        IEnumerable<string> GetAssignedRequests();
        void ApproveRequest(RequestApprovalDto dto);
        void DisapproveRequest(RequestApprovalDto dto);
        void ReturnRequest(RequestApprovalDto dto);
        string GetRequestStatus(string requestId);
        void UpdateComments(RequestCommentsDto dto);
    }
}

