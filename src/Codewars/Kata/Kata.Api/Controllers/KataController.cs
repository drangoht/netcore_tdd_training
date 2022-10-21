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

        [HttpPost("maxsequence")]
        public ActionResult MaxSequence(int[] numbers)
        {
            var res = new MaxSequenceResponse()
            {
                Result = _katas.MaxSequence(numbers)
            };
            return Ok(res);
        }

        [HttpGet("isvalidip/{ipV4}")]
        public ActionResult IsValidIP(string ipV4)
        {
            var res = new IsValidIPResponse()
            {
                Result = _katas.IsValidIP(ipV4)
            };
            return Ok(res);
        }

        [HttpGet("strCount/{str}/{strToSearch}")]
        public ActionResult StrCount(string str, string strToSearch)
        {
            var res = new StrCountResponse()
            {
                Result = _katas.StrCount(str, strToSearch)
            };
            return Ok(res);
        }

        [HttpPost("rangeextraction")]
        public ActionResult RangeExtraction(int[] numbers)
        {
            var res = new RangeExtractionResponse()
            {
                Result = _katas.RangeExtraction(numbers)
            };
            return Ok(res);
        }

        [HttpPost("getpins")]
        public ActionResult GetPins(string number)
        {
            var res = new GetPinsResponse()
            {
                Results = _katas.GetPINs(number)
            };
            return Ok(res);
        }

        [HttpPost("scramble")]
        public ActionResult Scramble(string str, string strToSearch)
        {
            var res = new ScrambleResponse()
            {
                Result = _katas.Scramble(str, strToSearch)
            };
            return Ok(res);
        }
    }
}

