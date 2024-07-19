using loginAuth.DTO;

namespace loginAuth
{
    public class RequestService:IRequestService
    {
        // Example data store
        private readonly Dictionary<string, string> _requestStatuses = new Dictionary<string, string>
        {
            {"REQ001", "Pending"},
            {"REQ002", "Approved"},
            {"REQ003", "Disapproved"}
        };

        public IEnumerable<string> GetAssignedRequests()
        {
            // Example: return a list of request IDs
            return _requestStatuses.Keys.ToList();
        }

        public void ApproveRequest(RequestApprovalDto dto)
        {
            // Example: Approve the request and update the status
            _requestStatuses[dto.RequestId] = "Approved";
            // Add logic to notify HR Travel Admin, save comments, etc.
        }

        public void DisapproveRequest(RequestApprovalDto dto)
        {
            // Example: Disapprove the request and update the status
            _requestStatuses[dto.RequestId] = "Disapproved";
            // Add logic to notify HR Travel Admin, save comments, etc.
        }

        public void ReturnRequest(RequestApprovalDto dto)
        {
            // Example: Return the request to the employee
            _requestStatuses[dto.RequestId] = "Returned";
            // Add logic to notify HR Travel Admin, save comments, etc.
        }

        public string GetRequestStatus(string requestId)
        {
            // Example: Get the status of the request
            return _requestStatuses.TryGetValue(requestId, out var status) ? status : "Unknown";
        }

        public void UpdateComments(RequestCommentsDto dto)
        {
            // Example: Update comments for the request
            // Add logic to save comments, etc.
        }
    }
}
