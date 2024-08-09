using UnityEngine;

public class AnswerObject : MonoBehaviour
{
    private bool isCorrectAnswer;

    public void SetAnswer(string answerText, bool isCorrect)
    {
        isCorrectAnswer = isCorrect;
       
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
        
    }

    void WrongAnswer()
    {
        Debug.Log("Wrong!");
        
    }
}
