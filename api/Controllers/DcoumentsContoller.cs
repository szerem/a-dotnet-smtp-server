//     using System.Net;
// using System.Net.Mime;
// using Microsoft.AspNetCore.Mvc;

// namespace api.Controllers;

// [ApiController]
// [Route("[controller]")]
// public class DocumentsController : ControllerBase
// {
//     private static readonly string[] Summaries = new[]
//     {
//         "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//     };

//     private readonly ILogger<DocumentsController> _logger;

//     public DocumentsController(ILogger<DocumentsController> logger)
//     {
//         _logger = logger;
//     }



//     [HttpPost()]
//     [Consumes(MediaTypeNames.Application.Json)]
//     public IActionResult Post(Doc doc)
//     {
//         _logger.LogInformation(doc.Body);
//         var product = "oko doki";
//         return product == null ? NotFound() : Ok(product);
//     }

//     public class Doc 
//     {
//         public int Id { get; set; }
//         public Person Author { get; set; }
//         public string Body { get; set; }
//     }
// }

// public class Person
// {
//     public string Name { get; set; }
//     public string Email { get; set; }
// }