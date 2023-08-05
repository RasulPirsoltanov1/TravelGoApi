using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelGoApi.DAL.Context;
using TravelGoApi.DAL.Entities;

namespace TravelGoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        private readonly AppDbContext _context = new AppDbContext();

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _context.Visitors.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Add(Visitor visitor)
        {
            await _context.Visitors.AddAsync(visitor);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Visitor visitor = await _context.Visitors.FindAsync(id);
            if(visitor== null)
            {
                return NotFound();
            }
            return Ok(visitor);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Visitor? visitor = await _context.Visitors.FindAsync(id);
            if (visitor == null)
            {
                return NotFound();
            }
            _context.Remove(visitor);
            await _context.SaveChangesAsync();
            return Ok(visitor);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Visitor visitor)
        {
            _context.Visitors.Update(visitor);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
