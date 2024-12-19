using Backend.Models;
using Backend.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RealisateursController : ControllerBase
    {
        private readonly IRealisateurRepository _realisateurRepository;

        public RealisateursController(IRealisateurRepository realisateurRepository)
        {
            _realisateurRepository = realisateurRepository;
        }

        // GET: api/Realisateurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Realisateurs>>> GetRealisateurs()
        {
            var realisateurs = await _realisateurRepository.GetAllRealisateursAsync();
            return Ok(realisateurs);
        }

        // GET: api/Realisateurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Realisateurs>> GetRealisateur(int id)
        {
            var realisateur = await _realisateurRepository.GetRealisateurByIdAsync(id);
            if (realisateur == null)
            {
                return NotFound($"Realisateur with ID {id} not found.");
            }
            return Ok(realisateur);
        }

        // PUT: api/Realisateurs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRealisateur(int id, Realisateurs realisateur)
        {
            if (id != realisateur.RealisateursID)
            {
                return BadRequest("ID mismatch.");
            }

            try
            {
                await _realisateurRepository.UpdateRealisateurAsync(realisateur);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            return NoContent();
        }

        // POST: api/Realisateurs
        [HttpPost]
        public async Task<ActionResult<Realisateurs>> PostRealisateur(Realisateurs realisateur)
        {
            if (realisateur == null)
            {
                return BadRequest("Realisateur data is null.");
            }

            try
            {
                var createdRealisateur = await _realisateurRepository.AddRealisateurAsync(realisateur);
                return CreatedAtAction(nameof(GetRealisateur), new { id = createdRealisateur.RealisateursID }, createdRealisateur);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/Realisateurs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Realisateurs>> DeleteRealisateur(int id)
        {
            try
            {
                var realisateur = await _realisateurRepository.GetRealisateurByIdAsync(id);
                if (realisateur == null)
                {
                    return NotFound($"Realisateur with ID {id} not found.");
                }

                await _realisateurRepository.DeleteRealisateurAsync(id);
                return Ok(realisateur);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
