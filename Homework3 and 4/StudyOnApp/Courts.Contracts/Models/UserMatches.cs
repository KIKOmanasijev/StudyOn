namespace Court.Contracts.Models
{
    public partial class UserMatches
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string MatchId { get; set; }

        public virtual Matches Match { get; set; }
        public virtual Users User { get; set; }
    }
}
