using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoGameApi.Data;

namespace VideoGameApi.Controllers
{
    [Route("api/[controller]")] //Định tuyến đến Api
    [ApiController] //Tự động validate model
    public class VideoGameController : ControllerBase
    {
        private readonly VideoGameDbContext _context; //Để truy cập vào database

        //Constructor để inject DbContext
        public VideoGameController(VideoGameDbContext context)
        {
            _context = context;
        }

        [HttpGet] //Định nghĩa route GET /api/VideoGame
        public async Task<ActionResult<IEnumerable<VideoGame>>> GetVideoGames()
        {
            //Lấy tất cả VideoGame từ database
            return await _context.VideoGames.ToListAsync();
        }

        [HttpGet("{id}")] //Định nghĩa route GET /api/VideoGame/{id}
        public async Task<ActionResult<VideoGame>> GetVideoGameById(int id)
        {
            //Lấy VideoGame theo id từ database
            var videoGame = await _context.VideoGames.FindAsync(id);

            //Nếu không tìm thấy thì trả về NotFound
            if (videoGame == null)
            {
                return NotFound();
            }

            //Nếu tìm thấy thì trả về VideoGame
            return Ok(videoGame);
        }

        [HttpPost] //Định nghĩa route POST /api/VideoGame
        public async Task<ActionResult<VideoGame>> CreateVideoGame(VideoGame videoGame)
        {
            //Nếu model không hợp lệ thì trả về BadRequest
            if (videoGame == null)
            {
                return BadRequest();
            }

            //Thêm VideoGame vào database
            _context.VideoGames.Add(videoGame);

            //Lưu thay đổi vào database
            await _context.SaveChangesAsync();

            //Trả về 201 Created và VideoGame vừa tạo
            return CreatedAtAction("GetVideoGameById", new { id = videoGame.Id }, videoGame);
        }

        [HttpPut("{id}")] //Định nghĩa route PUT /api/VideoGame/{id}
        public async Task<ActionResult<VideoGame>> UpdateVideoGame(int id, VideoGame videoGame)
        {
            //Tìm VideoGame theo id
            var game = await _context.VideoGames.FindAsync(id);

            //Nếu không tìm thấy thì trả về NotFound
            if (game == null)
            {
                return NotFound();
            }

            //Cập nhật thông tin VideoGame
            game.Title = videoGame.Title;
            game.Platform = videoGame.Platform;
            game.Developer = videoGame.Developer;
            game.ReleaseYear = videoGame.ReleaseYear;

            //Lưu thay đổi vào database
            _context.Entry(game).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            //Trả về VideoGame vừa cập nhật
            return NoContent();
        }

        [HttpDelete("{id}")] //Định nghĩa route DELETE /api/VideoGame/{id}
        public async Task<ActionResult> DeleteVideoGame(int id)
        {
            //Tìm VideoGame theo id
            var videoGame = await _context.VideoGames.FindAsync(id);

            //Nếu không tìm thấy thì trả về NotFound
            if (videoGame == null)
            {
                return NotFound();
            }

            //Xóa VideoGame
            _context.VideoGames.Remove(videoGame);

            //Lưu thay đổi vào database
            await _context.SaveChangesAsync();

            //Trả về 204 NoContent
            return NoContent();
        }
    }
}
