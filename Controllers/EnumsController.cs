using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MomentumRegistrationApi.Dtos;
using MomentumRegistrationApi.Enums;
namespace MomentumRegistrationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnumsController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("/LCs")]
        public ActionResult<IEnumerable<EnumResultDto>> GetLocalCommittees()
        {
            var sizes = new List<EnumResultDto>();
            int c = 0;
            foreach (var size in Enum.GetValues(typeof(LocalCommittee)))
            {
                sizes.Add(new EnumResultDto { label = size.ToString(), Id = c });
                c++;
            }
            return Ok(sizes);
        }
        [AllowAnonymous]
        [HttpGet("/Functions")]
        public ActionResult<IEnumerable<EnumResultDto>> GetFunctions()
        {
            var sizes = new List<EnumResultDto>();
            int c = 0;
            foreach (var size in Enum.GetValues(typeof(Function)))
            {
                sizes.Add(new EnumResultDto { label = size.ToString(), Id = c });
                c++;
            }
            return Ok(sizes);
        }
        [AllowAnonymous]
        [HttpGet("/Roles")]
        public ActionResult<IEnumerable<EnumResultDto>> GetRoles()
        {
            var sizes = new List<EnumResultDto>();
            int c = 0;
            foreach (var size in Enum.GetValues(typeof(Role)))
            {
                sizes.Add(new EnumResultDto { label = size.ToString(), Id = c });
                c++;
            }
            return Ok(sizes);
        }
        [AllowAnonymous]
        [HttpGet("/MerchandiseType")]
        public ActionResult<IEnumerable<EnumResultDto>> GetMerchandiseType()
        {
            var sizes = new List<EnumResultDto>();
            int c = 0;
            foreach (var size in Enum.GetValues(typeof(MerchandiseType)))
            {
                sizes.Add(new EnumResultDto { label = size.ToString(), Id = c });
                c++;
            }
            return Ok(sizes);
        }
        [AllowAnonymous]
        [HttpGet("/TshirtSizes")]
        public ActionResult<IEnumerable<EnumResultDto>> GetSizes()
        {
            var sizes = new List<EnumResultDto>();
            int c = 0;
            foreach (var size in Enum.GetValues(typeof(TshirtSize)))
            {
                sizes.Add(new EnumResultDto { label = size.ToString(), Id = c });
                c++;
            }
            return Ok(sizes);
        }
    }
}