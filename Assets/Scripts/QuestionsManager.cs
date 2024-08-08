using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using ArabicSupport;

public class QuestionManager : MonoBehaviour
{
    public Text questionText;
    public Button[] answerButtons;
    public QuestionDatabase questionDatabase;
    private Question currentQuestion;
    private int currentQuestionIndex;
    public float letterPause = 0.05f;

    void Start()
    {
        LoadNewQuestion();
    }

    void LoadNewQuestion()
    {
        currentQuestionIndex = Random.Range(0, questionDatabase.questions.Length);
        currentQuestion = questionDatabase.questions[currentQuestionIndex];


        // Deactivate all answer buttons initially
        foreach (Button button in answerButtons)
        {
            button.gameObject.SetActive(false);
        }

        // Deactivate all answer objects initially
        foreach (var obj in currentQuestion.answerObjects)
        {
            obj.SetActive(false);
        }

        StartCoroutine(DisplayQuestionLetterByLetter(currentQuestion));
    }

    IEnumerator DisplayQuestionLetterByLetter(Question question)
    {
        questionText.text = "";
        string fixedQuest = ArabicFixer.Fix(question.questionText);
        foreach (char letter in fixedQuest.ToCharArray())
        {
            questionText.text += letter;
            yield return new WaitForSeconds(letterPause);
        }

        DisplayAnswers(question);
    }

    void DisplayAnswers(Question question)
    {
        for (int i = 0; i < question.answers.Length; i++)
        {
            switch (question.answerTypes[i])
            {
                case AnswerType.Button:
                    answerButtons[i].GetComponentInChildren<Text>().text = ArabicFixer.Fix(question.answers[i]);
                    answerButtons[i].onClick.RemoveAllListeners();
                    if (question.answers[i] == question.correctAnswer)
                    {
                        answerButtons[i].onClick.AddListener(CorrectAnswer);
                    }
                    else
                    {
                        answerButtons[i].onClick.AddListener(WrongAnswer);
                    }
                    answerButtons[i].gameObject.SetActive(true);
                    break;

                case AnswerType.GameObject:
                    GameObject answerObject = question.answerObjects[i];
                    answerObject.SetActive(true);
                    answerObject.GetComponent<AnswerObject>().SetAnswer(question.answers[i], question.answers[i] == question.correctAnswer);
                    break;

                case AnswerType.Collider:
                    // Implement collider logic here
                    GameObject colliderObject = question.answerObjects[i];
                    colliderObject.SetActive(true);
                    colliderObject.GetComponent<AnswerCollider>().SetAnswer(question.answers[i], question.answers[i] == question.correctAnswer);
                    break;
            }
        }
    }

    void CorrectAnswer()
    {
        Debug.Log("Correct!");
        // Code to unlock the next part of the level
    }

    void WrongAnswer()
    {
        Debug.Log("Wrong!");
        GameManager.Instance.RestartGame();

    }
}
