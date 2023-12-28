namespace PokemonReviewApp.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string ReviewerName { get; set; }
        public string Content { get; set; }
        public int PokemonId { get; set; }
        public Pokemon Pokemon { get; set; }
    }
}
