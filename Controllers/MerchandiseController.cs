using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MomentumRegistrationApi.Entities;
using Repository.Implementations;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MerchandiseController : ControllerBase
    {
        private readonly ILogger<MerchandiseController> _logger;
        private readonly IMerchandiseRepository merchandiseRepository;

        public MerchandiseController(IMerchandiseRepository merchandiseRepository,ILogger<MerchandiseController> logger)
        {
            _logger = logger;
            this.merchandiseRepository = merchandiseRepository;
        }
        
        [HttpGet]
        public IEnumerable<string> GetSizes()
        {
            return merchandiseRepository.GetTshirtSizes();
        }
    }
}