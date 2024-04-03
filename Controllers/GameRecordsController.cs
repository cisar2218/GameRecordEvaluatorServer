using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EvaluatorServer.Models;

namespace EvaluatorServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameRecordsController : ControllerBase
    {
        private readonly GameRecordContext _context;

        public GameRecordsController(GameRecordContext context)
        {
            _context = context;
        }

        // GET: api/GameRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameRecord>>> GetGameRecords()
        {
            return await _context.GameRecords.ToListAsync();
        }

        // GET: api/GameRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameRecord>> GetGameRecord(int id)
        {
            var gameRecord = await _context.GameRecords.FindAsync(id);

            if (gameRecord == null)
            {
                return NotFound();
            }

            return gameRecord;
        }

        // PUT: api/GameRecords/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGameRecord(int id, GameRecord gameRecord)
        {
            if (id != gameRecord.Id)
            {
                return BadRequest();
            }

            _context.Entry(gameRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameRecordExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/GameRecords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GameRecord>> PostGameRecord(GameRecord gameRecord)
        {
            _context.GameRecords.Add(gameRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGameRecord", new { id = gameRecord.Id }, gameRecord);
        }

        // DELETE: api/GameRecords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameRecord(int id)
        {
            var gameRecord = await _context.GameRecords.FindAsync(id);
            if (gameRecord == null)
            {
                return NotFound();
            }

            _context.GameRecords.Remove(gameRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GameRecordExists(int id)
        {
            return _context.GameRecords.Any(e => e.Id == id);
        }
    }
}
