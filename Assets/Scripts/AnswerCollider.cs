using UnityEngine;

public class AnswerCollider : MonoBehaviour
{
    private bool isCorrectAnswer;

    public void SetAnswer(string answerText, bool isCorrect)
    {
        isCorrectAnswer = isCorrect;
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
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
    }

    void CorrectAnswer()
    {
        //if the answer is correct let do something like display "Correct!" or whatever we want
        Debug.Log("Correct!");
        
    }

    void WrongAnswer()
    {
        //We can add whatever we want here
        Debug.Log("Wrong!");
        
    }
}
