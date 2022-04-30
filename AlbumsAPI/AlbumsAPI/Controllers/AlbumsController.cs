using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlbumsAPI.Models;

namespace AlbumsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly AlbumContext _context;

        public AlbumsController(AlbumContext context)
        {
            _context = context;
        }

        // GET: api/Albums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlbumDTO>>> GetAlbums()
        {
            return await _context.Albums
                                    .Select(x => ConvertToAlbumDTO(x))
                                    .ToListAsync();
        }

        // GET: api/Albums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AlbumDTO>> GetAlbum(long id)
        {
            var album = await _context.Albums.FindAsync(id);

            if (album == null)
            {
                return NotFound();
            }

            return ConvertToAlbumDTO(album);
        }

        // PUT: api/Albums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAlbum(long id, AlbumDTO albumDTO)
        {
            if (id != albumDTO.Id)
            {
                return BadRequest();
            }

            var album = await _context.Albums.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }

            album.Title = albumDTO.Title;
            album.Artist = albumDTO.Artist;
            album.ReleaseYear = albumDTO.ReleaseYear;
            album.Genre = albumDTO.Genre;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!AlbumExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Albums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AlbumDTO>> CreateAlbum(AlbumDTO albumDTO)
        {
            var newAlbum = new Album
            {
                Title = albumDTO.Title,
                Artist = albumDTO.Artist,
                ReleaseYear = albumDTO.ReleaseYear,
                Genre = albumDTO.Genre
            };

            _context.Albums.Add(newAlbum);
            await _context.SaveChangesAsync();

            // return CreatedAtAction("GetAlbum", new { id = album.Id }, album);
            return CreatedAtAction(
                nameof(GetAlbum),
                new { id = albumDTO.Id },
                ConvertToAlbumDTO(newAlbum));
        }

        // DELETE: api/Albums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlbum(long id)
        {
            var album = await _context.Albums.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }

            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlbumExists(long id)
        {
            return _context.Albums.Any(e => e.Id == id);
        }

        private static AlbumDTO ConvertToAlbumDTO(Album album)
        {
            return new AlbumDTO
            {
                Id = album.Id,
                Title = album.Title,
                Artist = album.Artist,
                ReleaseYear = album.ReleaseYear,
                Genre = album.Genre
            };
        }
    }
}
