using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MomentumRegistrationApi.Entities;
using MongoDB.Driver;
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
        public IEnumerable<MerchItem> GetAllMerch()
        {
            return merchandiseRepository.GetAll();
        }
        [HttpGet("/GetById{Id}")]
        public MerchItem GetMerchById(Guid Id)
        {
            return merchandiseRepository.Get(Id);
        }
        
        [HttpGet("/TshirtSizes")]
        public IEnumerable<string> GetSizes()
        {
            return merchandiseRepository.GetTshirtSizes();
        }
        [HttpPost]
        public long InsertMerch(MerchItem item)
        {
            return merchandiseRepository.Insert(item);
        }
        [HttpPost("/many")]
        public IEnumerable<long> InsertManyMerch(IEnumerable<MerchItem> items)
        {
            return merchandiseRepository.InsertMany(items);
        }
        [HttpPut]
        public IActionResult UpdateMerch(MerchItem item)
        {
            //return 
            if(merchandiseRepository.Update(item).IsAcknowledged)
                return StatusCode(204); 
            else
                return StatusCode(400);
        }
        [HttpDelete]
        public IActionResult DeleteMerch(Guid id)
        {
            if(merchandiseRepository.Delete(id).IsAcknowledged)
                return StatusCode(204); 
            else
                return StatusCode(400);
        }
    }
}