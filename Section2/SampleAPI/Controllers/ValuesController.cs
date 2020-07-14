using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace SampleAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ValuesController : ControllerBase
	{

		private IPaymentService paymentService { get; set; }

		//there should only be one constructor applicable for dependency injection
		public ValuesController(IPaymentService paymentService /*, string[] paymentTypes = new string[] { "1", "2", "3" }*/)
		{

			//You can ONLY pass arguments intro the constructor that are NOT provided by dependency injection IF 
			// > they have a default value provided - as done above.

			this.paymentService = paymentService;

		}

		// injecting  the service ONLY into the 'get' action method
		[HttpGet]
		public ActionResult<string> Get(
			[FromServices]IPaymentService paymentService)
        {
			return paymentService.GetMessage();
        }

		//[HttpPost]
		//public IActionResult Post(/*[FromBody]*/ Request request)
  //      {
		//	// [FromBody] attribute & the model state check is implicit 
		//	// > due to the 'ValueRequest' complex type
  //  //        if (ModelState.IsValid)
  //  //        {
		//		//return BadRequest(ModelState);
  //  //        }

		//	return Ok();
  //      }


	}
}
