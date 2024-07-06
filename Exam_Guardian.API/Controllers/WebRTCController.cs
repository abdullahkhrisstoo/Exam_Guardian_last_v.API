using Exam_Guardian.core.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;

namespace Exam_Guardian.API.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class WebRTCController : ControllerBase
    {
        private readonly IHubContext<VideoCallHub> _hubContext;

        public WebRTCController(IHubContext<VideoCallHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost("exchange-sdp/{sdpMid}")]
        public async Task<IActionResult> ExchangeSDP(string sdpMid, [FromBody] SDPExchangeModel sdpExchange)
        {
            try
            {
                // Validate sdpExchange if necessary

                await _hubContext.Clients.Group(sdpMid).SendAsync("ReceiveSDP", sdpMid, sdpExchange.SDP);

                return Ok(new { message = "SDP received and broadcasted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("exchange-ice/{sdpMid}")]
        public async Task<IActionResult> ExchangeICE(string sdpMid, [FromBody] ICECandidateModel iceCandidate)
        {
            try
            {
                // Validate iceCandidate if necessary

                await _hubContext.Clients.Group(sdpMid).SendAsync("ReceiveICE", sdpMid, iceCandidate.Candidate, iceCandidate.SdpMLineIndex);

                return Ok(new { message = "ICE candidate received and broadcasted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}