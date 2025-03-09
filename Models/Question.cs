namespace QuizApp.Models
{
    public abstract class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public QuestionType Type { get; set; } // Enum to distinguish question types

        public enum QuestionType
        {
            MultipleChoice,
            TrueFalse,
            Picture
        }
    }
}