using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MomentumRegistrationApi.Dtos;
using Repository.Implementations;
using MomentumRegistrationApi.Extensions;
using Microsoft.AspNetCore.Http;
using Entities;

namespace Controllers
{    
    [ApiController]
    [Route("[controller]")]
    public class LcLookUpController :ControllerBase
    {
        private readonly ILogger<LcLookUpController> _logger;
        private readonly ILcLookUpRepository lookupRepository;

        public LcLookUpController(ILcLookUpRepository lookupRepository, ILogger<LcLookUpController> logger)
        {
            _logger = logger;
            this.lookupRepository = lookupRepository;
        }
                
        [HttpGet("{code}")]
        public async Task<ActionResult<LcLookUp>> LookUpLc(string code)
        {
            var item = await lookupRepository.ValidateCode(code);
            if (item == null)
                return StatusCode(StatusCodes.Status404NotFound, "Code Not Found");
            return StatusCode(StatusCodes.Status200OK, item);
        }
        // [HttpPost]
        // public async Task<ActionResult<long>> InsertMerch(MerchandiseRequestDto item)
        // {
        //     var insertedSequence = await lookupRepository.InsertAsync(item);
        //     if (insertedSequence < 1)
        //         return StatusCode(StatusCodes.Status406NotAcceptable);
        //     return StatusCode(StatusCodes.Status201Created, insertedSequence);
        // }
       
    }
}