using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MomentumRegistrationApi.Dtos;
using MomentumRegistrationApi.Entities;
using MongoDB.Driver;
using Repository.Implementations;
using MomentumRegistrationApi.Extensions;

namespace Controllers
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
        public ActionResult<IEnumerable<MerchandiseResponseDto>> GetAllMerch()
        {
            return StatusCode(200, merchandiseRepository.GetAll().Select(item => item.AsResponseDto()));
        }
        [HttpGet("{Id}")]
        public ActionResult<MerchandiseResponseDto> GetMerchById(Guid Id)
        {
            return StatusCode(200, merchandiseRepository.Get(Id).AsResponseDto());
        }

        [HttpGet("/TshirtSizes")]
        public ActionResult<IEnumerable<string>> GetSizes()
        {
            return StatusCode(200, merchandiseRepository.GetTshirtSizes());
        }
        [HttpPost]
        public ActionResult<long> InsertMerch(MerchandiseRequestDto item)
        {

            return StatusCode(200, merchandiseRepository.Insert(item.AsMerchItem()));
        }
        [HttpPost("/many")]
        public ActionResult<IEnumerable<long>> InsertManyMerch(IEnumerable<MerchandiseRequestDto> items)
        {
            return StatusCode(200, merchandiseRepository.InsertMany(items.Select(x => x.AsMerchItem())));
        }
        [HttpPut("{id}")]
        public IActionResult UpdateMerch([FromRoute] Guid id, [FromBody] MerchandiseRequestDto item)
        {
            var oldItem = merchandiseRepository.Get(id);
            var newItem = oldItem with
            {
                Price = item.Price,
                ImageBase64 = item.ImageBase64,
                Type = item.Type
            };
            if (merchandiseRepository.Update(newItem).IsAcknowledged)
                return StatusCode(204);
            else
                return StatusCode(400);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMerch(Guid id)
        {
            if (merchandiseRepository.Delete(id).IsAcknowledged)
                return StatusCode(204);
            else
                return StatusCode(400);
        }
    }
}