using UnityEngine;

public class AnswerObject : MonoBehaviour
{
    private bool isCorrectAnswer;

    public void SetAnswer(string answerText, bool isCorrect)
    {
        isCorrectAnswer = isCorrect;
        // Set any additional properties or visuals based on answerText
    }

    void OnMouseDown()
    {
        if (isCorrectAnswer)
        {
            CorrectAnswer();
        }
        else
        {
            WrongAnswer();
        }
    }

    void CorrectAnswer()
    {
        Debug.Log("Correct!");
        // Implement correct answer logic
    }

    void WrongAnswer()
    {
        Debug.Log("Wrong!");
        // Implement wrong answer logic
    }
}
