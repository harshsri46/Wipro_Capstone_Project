using loginAuth.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace loginAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IRequestService _requestService; // Assume you have a service for request handling

        public ManagerController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpGet("assigned-requests")]
        public IActionResult GetAssignedRequests()
        {
            var requests = _requestService.GetAssignedRequests();
            return Ok(requests);
        }

        [HttpPost("approve")]
        public IActionResult ApproveRequest([FromBody] RequestApprovalDto dto)
        {
            _requestService.ApproveRequest(dto);
            return Ok();

        }

        [HttpPost("disapprove")]
        public IActionResult DisapproveRequest([FromBody] RequestApprovalDto dto)
        {
            _requestService.DisapproveRequest(dto);
            return Ok();
        }

            [HttpPost("return")]
        public IActionResult ReturnRequest([FromBody] RequestApprovalDto dto)
        {
            _requestService.ReturnRequest(dto);
            return Ok();

        }

        [HttpGet("status/{requestId}")]
        public IActionResult GetRequestStatus(string requestId)
        {
            var status = _requestService.GetRequestStatus(requestId);
            return Ok(status);
        }

        [HttpPost("update-comments")]
        public IActionResult UpdateComments([FromBody] RequestCommentsDto dto)
        {
            _requestService.UpdateComments(dto);
            return Ok();
        }

    }
}
