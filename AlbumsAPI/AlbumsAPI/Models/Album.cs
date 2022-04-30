namespace AlbumsAPI.Models
{
    public class Album
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Artist { get; set; }
        public int ReleaseYear { get; set; }
        public string? Genre { get; set; }
        public string? Secret { get; set; }
    }
}
