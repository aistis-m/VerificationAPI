using System.Net;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using ValidationWebAPI.Services;
using ValidationWebAPI.Services.Interfaces;

namespace ValidationWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ValidationController : ControllerBase
{

    private readonly ILogger<ValidationController> _logger;
    private readonly IValidationService validationService;

    public ValidationController(ILogger<ValidationController> logger,IValidationService validationService)
    {
        _logger = logger;
        this.validationService = validationService;
    }


    [HttpPost(Name = "validate")]
    public async Task<IActionResult> Upload()
    {
        var httpForm = await Request.ReadFormAsync();
        var file = httpForm.Files.First();

        var stream = file.OpenReadStream();
        var reader = new StreamReader(stream);
        
        var fileContents = await reader.ReadToEndAsync();

        var response = validationService.ValidateAndGenerateResponse(fileContents);

        return Ok(response);
    }
}

