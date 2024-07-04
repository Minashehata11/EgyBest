namespace EgyBest.Domain.Models
{
    public class BasePerson:BaseEntity
    {
        public string Nationality { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
