using UnityEngine;

public enum AnswerType
{
    Button,
    GameObject,
    Collider
}

[CreateAssetMenu(fileName = "New Question", menuName = "Question")]
public class Question : ScriptableObject
{
    public string questionText;
    public string[] answers;
    public string correctAnswer;
    public AnswerType[] answerTypes;
    public GameObject[] answerObjects;
}
