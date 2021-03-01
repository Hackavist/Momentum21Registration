using System;
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

namespace MomentumRegistrationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly ILogger<RegistrationController> _logger;
        private readonly IAttendeeRepository attendeeRepository;

        public RegistrationController(IAttendeeRepository attendeeRepository, ILogger<RegistrationController> logger)
        {
            _logger = logger;
            this.attendeeRepository = attendeeRepository;
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AttendeeRegistrationResponseDto>>> GetAllAttendees()
        {
            var allItems = await attendeeRepository.GetAllAsync();
            if (allItems == null)
                return StatusCode(StatusCodes.Status404NotFound, "No Attendees Found");
            return StatusCode(StatusCodes.Status200OK, allItems.Select(item => item.AsResponseDto()));
        }
        // [Authorize]
        [HttpGet("{Id}")]
        public async Task<ActionResult<AttendeeRegistrationResponseDto>> GetAttendeesById(Guid Id)
        {
            var item = await attendeeRepository.GetAsync(Id);
            if (item == null)
                return StatusCode(StatusCodes.Status404NotFound, "Item Not Found");
            return StatusCode(StatusCodes.Status200OK, item.AsResponseDto());
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<long>> InsertAttendees(AttendeeRegistrationRequestDto item)
        {
            var insertedSequence = await attendeeRepository.InsertAsync(item.AsAttnedee());
            if (insertedSequence < 1)
                return StatusCode(StatusCodes.Status406NotAcceptable);
            return StatusCode(StatusCodes.Status201Created, insertedSequence);
        }
        // [HttpPost("/many")]
        // public async Task<ActionResult<IEnumerable<long>>> InsertManyAttendees(IEnumerable<AttendeeRegistrationRequestDto> items)
        // {
        //     var insertedSequenceNumbers = await attendeeRepository.InsertManyAsync(items.Select(x => x.AsAttnedee()));
        //     if (insertedSequenceNumbers == null)
        //         return StatusCode(StatusCodes.Status300MultipleChoices);
        //     return StatusCode(StatusCodes.Status201Created, insertedSequenceNumbers);
        // }
        // [HttpPut("{id}")]
        // public async Task<IActionResult> UpdateAttendees([FromRoute] Guid id, [FromBody] AttendeeRegistrationRequestDto item)
        // {
        //     var oldItem = await attendeeRepository.GetAsync(id);
        //     var newItem = oldItem with
        //     {
        //         Price = item.Price,
        //         ImageBase64 = item.ImageBase64,
        //         Type = item.Type
        //     };
        //     var updateResult = await attendeeRepository.UpdateAsync(newItem);
        //     if (updateResult.IsAcknowledged)
        //         return StatusCode(StatusCodes.Status204NoContent);
        //     return StatusCode(StatusCodes.Status406NotAcceptable);
        // }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendees(Guid id)
        {
            var deleteResult = await attendeeRepository.DeleteAsync(id);
            if (deleteResult.IsAcknowledged)
                return StatusCode(StatusCodes.Status204NoContent);
            return StatusCode(StatusCodes.Status406NotAcceptable);
        }

    }
}