using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("/error")]
public class ErrorsController : ControllerBase
{
    public IActionResult Error()
    {
        return Problem();
    }
}
