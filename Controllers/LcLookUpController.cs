using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MomentumRegistrationApi.Dtos;
using MomentumRegistrationApi.Extensions;
using Microsoft.AspNetCore.Http;
using MomentumRegistrationApi.Repository.Implementations;
using Microsoft.AspNetCore.Authorization;
using System;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LcLookUpController : ControllerBase
    {
        private readonly ILogger<LcLookUpController> _logger;
        private readonly ILcLookUpRepository lookupRepository;

        public LcLookUpController(ILcLookUpRepository lookupRepository, ILogger<LcLookUpController> logger)
        {
            _logger = logger;
            this.lookupRepository = lookupRepository;
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LookUpResponseDto>>> GetAlllookups()
        {
            var allItems = await lookupRepository.GetAllAsync();
            if (allItems == null)
                return StatusCode(StatusCodes.Status404NotFound, "No Lookups Found");
            return StatusCode(StatusCodes.Status200OK, allItems.Select(item => item.AsDto()));
        }
        [AllowAnonymous]
        [HttpGet("{code}")]
        public async Task<ActionResult<LookUpResponseDto>> LookUpLc(string code)
        {
            var lookUp = await lookupRepository.ValidateCode(code);
            if (lookUp == null)
                return StatusCode(StatusCodes.Status404NotFound, "Code Not Found");
            return StatusCode(StatusCodes.Status200OK, lookUp.AsDto());
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<long>> InsertLcLookUp(LookUpRequestDto lookup)
        {
            var insertedSequence = await lookupRepository.InsertAsync(lookup.AsLookUp());
            if (insertedSequence < 1)
                return StatusCode(StatusCodes.Status406NotAcceptable);
            return StatusCode(StatusCodes.Status201Created, insertedSequence);
        }
        [Authorize]
        [HttpPost("/InsertLCCodes")]
        public async Task<ActionResult<IEnumerable<long>>> InsertManyLcLookUps(IEnumerable<LookUpRequestDto> items)
        {
            var insertedSequenceNumbers = await lookupRepository.InsertManyAsync(items.Select(x => x.AsLookUp()));
            if (insertedSequenceNumbers == null)
                return StatusCode(StatusCodes.Status300MultipleChoices);
            return StatusCode(StatusCodes.Status201Created, insertedSequenceNumbers);
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletlookup(Guid id)
        {
            var deleteResult = await lookupRepository.DeleteAsync(id);
            if (deleteResult.IsAcknowledged)
                return StatusCode(StatusCodes.Status204NoContent);
            return StatusCode(StatusCodes.Status406NotAcceptable);
        }
    }
}