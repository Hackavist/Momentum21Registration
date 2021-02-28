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

namespace MomentumRegistrationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MerchandiseController : ControllerBase
    {
        private readonly ILogger<MerchandiseController> _logger;
        private readonly IMerchandiseRepository merchandiseRepository;

        public MerchandiseController(IMerchandiseRepository merchandiseRepository, ILogger<MerchandiseController> logger)
        {
            _logger = logger;
            this.merchandiseRepository = merchandiseRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MerchandiseResponseDto>>> GetAllMerch()
        {
            var allItems = await merchandiseRepository.GetAllAsync();
            if (allItems == null)
                return StatusCode(StatusCodes.Status404NotFound, "No Merch Found");
            return StatusCode(StatusCodes.Status200OK, allItems.Select(item => item.AsResponseDto()));
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<MerchandiseResponseDto>> GetMerchById(Guid Id)
        {
            var item = await merchandiseRepository.GetAsync(Id);
            if (item == null)
                return StatusCode(StatusCodes.Status404NotFound, "Item Not Found");
            return StatusCode(StatusCodes.Status200OK, item.AsResponseDto());
        }
        [HttpPost]
        public async Task<ActionResult<long>> InsertMerch(MerchandiseRequestDto item)
        {
            var insertedSequence = await merchandiseRepository.InsertAsync(item.AsMerchItem());
            if (insertedSequence < 1)
                return StatusCode(StatusCodes.Status406NotAcceptable);
            return StatusCode(StatusCodes.Status201Created, insertedSequence);
        }
        [HttpPost("/many")]
        public async Task<ActionResult<IEnumerable<long>>> InsertManyMerch(IEnumerable<MerchandiseRequestDto> items)
        {
            var insertedSequenceNumbers = await merchandiseRepository.InsertManyAsync(items.Select(x => x.AsMerchItem()));
            if (insertedSequenceNumbers == null)
                return StatusCode(StatusCodes.Status300MultipleChoices);
            return StatusCode(StatusCodes.Status201Created, insertedSequenceNumbers);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMerch([FromRoute] Guid id, [FromBody] MerchandiseRequestDto item)
        {
            var oldItem = await merchandiseRepository.GetAsync(id);
            var newItem = oldItem with
            {
                Price = item.Price,
                ImageBase64 = item.ImageBase64,
                Type = item.Type
            };
            var updateResult = await merchandiseRepository.UpdateAsync(newItem);
            if (updateResult.IsAcknowledged)
                return StatusCode(StatusCodes.Status204NoContent);
            return StatusCode(StatusCodes.Status406NotAcceptable);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMerch(Guid id)
        {
            var deleteResult = await merchandiseRepository.DeleteAsync(id);
            if (deleteResult.IsAcknowledged)
                return StatusCode(StatusCodes.Status204NoContent);
            return StatusCode(StatusCodes.Status406NotAcceptable);
        }

    }
}