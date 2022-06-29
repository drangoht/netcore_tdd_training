using Kata.Domain;
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
        [HttpGet]
        public ActionResult Index()
        {
            return Ok("It works!");
        }

        [HttpGet("to_camel_case/{strToConvert}")]
        public ActionResult ToCamelCase(string strToConvert)
        {
            return Ok(_katas.ToCamelCase(strToConvert));
        }

        [HttpGet("duplicate_encode/{strToEncode}")]
        public ActionResult DuplicateEncode(string strToEncode)
        {
            return Ok(_katas.DuplicateEncode(strToEncode));
        }

        [HttpGet("narcissistic/{number:int}")]
        public ActionResult Narcissistic(int number)
        {
            return Ok(_katas.Narcissistic(number));
        }
    }
}

