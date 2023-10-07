using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PAII_TP_Final.Controllers;

[ApiController]
[Route("[controller]")]
public class AlumnosController: ControllerBase
{
    private readonly PAIIDbContext _paIIDbContext;
    public AlumnosController(PAIIDbContext paIIDbContext)
    {
        _paIIDbContext = paIIDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var alumnos = await _paIIDbContext.Alumnos.ToListAsync();        
        return Ok(alumnos);
    }
}