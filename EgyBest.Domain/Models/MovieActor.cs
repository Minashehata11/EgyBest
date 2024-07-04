namespace EgyBest.Domain.Models
{
    public class MovieActor
    {
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
        public Actor Actor { get; set; }
        public int ActorId { get; set; }
    }
}
