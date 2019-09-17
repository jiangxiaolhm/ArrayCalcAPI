using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ArrayCalcAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ArrayCalcAPI.Controllers
{
    [Route("api/[controller]")]
    public class ArrayCalcController : Controller
    {

        private ArrayCalcService arrayCalcService = null;

        public ArrayCalcController([FromServices]ArrayCalcService arrayCalcService)
        {
            this.arrayCalcService = arrayCalcService;
        }

        // GET: api/<controller>
        [HttpGet("reverse")]
        public async Task<ActionResult<int[]>> Reverse([FromQuery] int[] productIds)
        {
            try
            {
                var result = await arrayCalcService.Reverse(productIds);
                return result;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet("deletepart")]
        public async Task<ActionResult<int[]>> DeletePart([FromQuery] int position, [FromQuery] int[] productIds)
        {
            if (position <= 0 || position > productIds.Length)
            {
                return BadRequest("The position is out of range.");
            }

            try
            {
                var result = await arrayCalcService.DeletePart(position, productIds);
                return result;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
