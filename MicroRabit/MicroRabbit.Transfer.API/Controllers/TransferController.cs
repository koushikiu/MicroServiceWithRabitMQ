using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroRabbit.Transfer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransferController : ControllerBase
    {

        private readonly ITransferService _transferService;
        private readonly ILogger<TransferController> _logger;

        public TransferController(ILogger<TransferController> logger, ITransferService transferService)
        {
            _transferService = transferService;
            _logger = logger;
        }

        //GET Api/transfer
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_transferService.GetTransferLogs());
        }
    }
}
