namespace QuizApp.Models
{
    public class MultipleChoiceQuestion : Question
    {
        public List<Choice> Choices { get; set; }
        public int CorrectChoiceId { get; set; }
    }
}