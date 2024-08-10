using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using ArabicSupport;
using UnityEngine.SceneManagement;

public class QuestionManager : MonoBehaviour
{
    public Text questionText;
    public Text[] answers;
    public GameObject[] answerObjects;
    public Button[] answerButtons;
    public QuestionDatabase questionDatabase;
    private Question currentQuestion;
    private int currentQuestionIndex;
    public float letterPause = 0.05f;
    private int questionsAnswered;

    public static QuestionManager instance;

    private void Awake()
    {
        instance = this;
    }

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
                    GameObject colliderObject = answerObjects[i];
                    answers[i].text = ArabicFixer.Fix(question.answers[i]);
                    colliderObject.SetActive(true);
                    colliderObject.GetComponent<AnswerCollider>().SetAnswer(question.answers[i], question.answers[i] == question.correctAnswer);
                    break;
            }
        }
    }

    public void CorrectAnswer()
    {
        Debug.Log("Correct Answer!");
        questionsAnswered++;
        for (int i = 0; i < answerObjects.Length; i++)
        {
            answerObjects[i].SetActive(false);
            //answers[i].enabled = false;
        }
        if (questionsAnswered >=5)
        {
            GameManager.Instance.keysGained++;
            GameManager.Instance.challenge1complete = true;
            SceneManager.LoadScene("MainGame");
        }
        Debug.Log("This function finished");
        LoadNewQuestion();

    }

    public void WrongAnswer()
    {
        Debug.Log("Wrong!");
        GameManager.Instance.RestartGame();

    }
}
