using Microsoft.EntityFrameworkCore;

namespace VideoGameApi.Data
{
    //Tạo DbContext để truy cập vào database
    public class VideoGameDbContext(DbContextOptions<VideoGameDbContext> options) : DbContext(options)
    {
        //Tạo bảng VideoGame trong database
        public DbSet<VideoGame> VideoGames { get; set; }

        //seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VideoGame>().HasData(
                new VideoGame { Id = 1, Title = "The Legend of Zelda: Breath of the Wild", Platform = "Nintendo Switch", Developer = "Nintendo", ReleaseYear = 2017 },
                new VideoGame { Id = 2, Title = "Super Mario Odyssey", Platform = "Nintendo Switch", Developer = "Nintendo", ReleaseYear = 2017 },
                new VideoGame { Id = 3, Title = "The Witcher 3: Wild Hunt", Platform = "PlayStation 4", Developer = "CD Projekt Red", ReleaseYear = 2015 },
                new VideoGame { Id = 4, Title = "Red Dead Redemption 2", Platform = "PlayStation 4", Developer = "Rockstar Games", ReleaseYear = 2018 },
                new VideoGame { Id = 5, Title = "The Last of Us Part II", Platform = "PlayStation 4", Developer = "Naughty Dog", ReleaseYear = 2020 }
                                                                                                      );
        }
    }
}
