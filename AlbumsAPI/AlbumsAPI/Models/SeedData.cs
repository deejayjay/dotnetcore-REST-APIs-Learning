using Microsoft.EntityFrameworkCore;

namespace AlbumsAPI.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AlbumContext(serviceProvider.GetRequiredService<DbContextOptions<AlbumContext>>()))
            {
                if (context == null || context.Albums == null)
                {
                    throw new ArgumentNullException("Null AlbumContext");
                }

                // Look for any albums.
                if (context.Albums.Any())
                {
                    return;   // DB has been seeded
                }

                context.Albums.AddRange(
                    new Album
                    {
                        Title = "Hybrid Theory",
                        Artist = "Linkin Park",
                        ReleaseYear = 2006,
                        Genre = "Alternate Rock",
                        Secret = "Album 1 Secret"
                    },

                    new Album
                    {
                        Title = "Metallica",
                        Artist = "Metallica",
                        ReleaseYear = 1989,
                        Genre = "Thrash Metal",
                        Secret = "Album 2 Secret"
                    },

                    new Album
                    {
                        Title = "Thriller",
                        Artist = "Michael Jackson",
                        ReleaseYear = 1998,
                        Genre = "Pop",
                        Secret = "Album 3 Secret"
                    },

                    new Album
                    {
                        Title = "21",
                        Artist = "Adele",
                        ReleaseYear = 2010,
                        Genre = "Pop",
                        Secret = "Album 4 Secret"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
