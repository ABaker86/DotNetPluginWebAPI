using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Plugin.Example1.Models;

namespace Plugin.Example1;

[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{
    [HttpGet(Name = "GetClientAddresses")]
    public IActionResult GetAll(
        [FromServices] ILogger<AddressController> logger,
        [FromServices] IStandardRepository repo
    )
    {
        logger.LogInformation("Getting client address info from {controller}.", new []{nameof(AddressController) });

        return Ok( repo.GetAll());
    }

    [HttpGet(template: "{id:int}", Name = "GetClientAddressById")]
    public IActionResult GetById(
        [FromServices] ILogger<AddressController> logger,
        [FromServices] IStandardRepository repo,
        [FromQuery] int id
    )
    {
        logger.LogInformation("Getting client address info from {controller}.", new[] { nameof(AddressController) });

        return Ok(repo.GetById(id));
    }

    [HttpPut(Name = "UpdateClientAddress")]
    public IActionResult Update(
        [FromServices] ILogger<AddressController> logger,
        [FromServices] IStandardRepository repo,
        [FromBody] ClientAddress address
    )
    {
        logger.LogInformation("Updating client address into to repository.");
        
        return Ok( repo.Update(address));
    }

    [HttpDelete(Name = "DeleteClientAddress")]
    public IActionResult Delete(
        [FromServices] ILogger<AddressController> logger,
        [FromServices] IStandardRepository repo,
        [FromBody] ClientAddress address
    )
    {
        logger.LogInformation("Deleting client address from repository.");

        return Ok(repo.Delete(address));
    }

    [HttpPost(Name = "InsertClientAddress")]
    public IActionResult Insert(
        [FromServices] ILogger<AddressController> logger,
        [FromServices] IStandardRepository repo,
        [FromBody] IEnumerable<ClientAddress> addresses
    )
    {
        logger.LogInformation("Updating client address into to repository.");
        if(addresses == null || addresses == Enumerable.Empty<ClientAddress>())
            return BadRequest();

        return Ok(repo.Insert(addresses));
    }
}
