using Microsoft.AspNetCore.Mvc;
using QuizApp.Models;

[ApiController]
[Route("api/[controller]")]
public class QuizController : ControllerBase
{
    private static List<Quiz> Quizzes = new List<Quiz>
    {
        new Quiz
        {
            Id = 1,
            Title = "Sample Quiz",
            Questions = new List<Question>
            {
                new MultipleChoiceQuestion
                {
                    Id = 1,
                    QuestionText = "What is the capital of France?",
                    Type = Question.QuestionType.MultipleChoice,
                    Choices = new List<MultipleChoiceQuestion.Choice>
                    {
                        new MultipleChoiceQuestion.Choice { Id = 1, Text = "Berlin" },
                        new MultipleChoiceQuestion.Choice { Id = 2, Text = "Madrid" },
                        new MultipleChoiceQuestion.Choice { Id = 3, Text = "Paris" }
                    },
                    CorrectChoiceId = 3
                },
                new TrueFalseQuestion
                {
                    Id = 2,
                    QuestionText = "The Earth is flat.",
                    Type = Question.QuestionType.TrueFalse,
                    CorrectAnswer = false
                },
                new PictureQuestion
                {
                    Id = 3,
                    QuestionText = "What animal is this?",
                    Type = Question.QuestionType.Picture,
                    ImageUrl = "https://example.com/dog.jpg",
                    AltText = "A cute dog",
                    CorrectAnswer = "Dog"
                }
            }
        }
    };

    [HttpGet("{quizId}")]
    public IActionResult GetQuiz(int quizId)
    {
        var quiz = Quizzes.FirstOrDefault(q => q.Id == quizId);
        if (quiz == null)
        {
            return NotFound();
        }
        return Ok(quiz);
    }
}
