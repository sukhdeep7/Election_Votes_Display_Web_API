using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Election_Votes_Display_Web_API.Business;
using Election_Votes_Display_Web_API.Models;

namespace Election_Votes_Display_Web_API.Controllers
{
    //Api controller for votes 
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateVotesController : ControllerBase
    {
        private readonly Election_Votes_Display_Web_APIContext _context;

        public CandidateVotesController(Election_Votes_Display_Web_APIContext context)
        {
            _context = context;
        }

        // GET: api/CandidateVotes
        //Gets all candidate votes uisng  linq qiery
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CandidateVote>>> GetCandidateVote()
        {
            return await (from candidate in _context.CandidateVote select candidate).ToListAsync();
        }

        // GET: api/CandidateVotes/5
        //Get candidate vote details
        [HttpGet("{id}")]
        public async Task<ActionResult<CandidateVote>> GetCandidateVote(int id)
        {
            var candidateVote = await _context.CandidateVote.FindAsync(id);

            if (candidateVote == null)
            {
                return NotFound();
            }

            return candidateVote;
        }

        // PUT: api/CandidateVotes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //Update candidate vote
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidateVote(int id, CandidateVote candidateVote)
        {
            if (id != candidateVote.Id)
            {
                return BadRequest();
            }

            _context.Entry(candidateVote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidateVoteExists(id))
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

        // POST: api/CandidateVotes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //Add candidate vote
        [HttpPost]
        public async Task<ActionResult<CandidateVote>> PostCandidateVote(CandidateVote candidateVote)
        {
            _context.CandidateVote.Add(candidateVote);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCandidateVote", new { id = candidateVote.Id }, candidateVote);
        }

        // DELETE: api/CandidateVotes/5
        //Delete candidate vote
        [HttpDelete("{id}")]
        public async Task<ActionResult<CandidateVote>> DeleteCandidateVote(int id)
        {
            var candidateVote = await _context.CandidateVote.FindAsync(id);
            if (candidateVote == null)
            {
                return NotFound();
            }

            _context.CandidateVote.Remove(candidateVote);
            await _context.SaveChangesAsync();

            return candidateVote;
        }

        //Checks candidate vote exists using a lamda query
        private bool CandidateVoteExists(int id)
        {
            return _context.CandidateVote.Any(e => e.Id == id);
        }
    }
}
