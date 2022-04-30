namespace AlbumsAPI.Models
{
    public class AlbumDTO
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Artist { get; set; }
        public int ReleaseYear { get; set; }
        public string? Genre { get; set; }
    }
}
