namespace QuizzProject.Models
{
    public class Player
    {
        public Player()
        {
            Score = 0;
            NrOfPlayedQuizzes = 0;
        }
        public string? Name { get; set; }
        public int Score { get; set; }
        public int NrOfPlayedQuizzes { get; set; }
    }
}
