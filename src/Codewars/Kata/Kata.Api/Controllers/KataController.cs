using Kata.Domain;
using Kata.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kata.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KataController : ControllerBase
    {
        private readonly IKatas _katas;

        public KataController(IKatas katas)
        {
            _katas = katas;
        }
        [HttpGet()]
        public ActionResult Index()
        {
            return Ok("It works!");
        }

        [HttpGet("to_camel_case/{strToConvert}")]
        public ActionResult ToCamelCase(string strToConvert)
        {
            var res = new CamelCaseResponse()
            {
                Result = _katas.ToCamelCase(strToConvert)
            };
            return Ok(res);
        }

        [HttpGet("duplicate_encode/{strToEncode}")]
        public ActionResult DuplicateEncode(string strToEncode)
        {
            var res = new DuplicateEncodeResponse()
            {
                Result = _katas.DuplicateEncode(strToEncode)
            };
            return Ok(res);
        }

        [HttpGet("narcissistic/{number:int}")]
        public ActionResult Narcissistic(int number)
        {
            var res = new NarcissisticResponse()
            {
                Result = _katas.Narcissistic(number)
            };
            return Ok(res);
        }
    }
}

