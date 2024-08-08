using UnityEngine;

[CreateAssetMenu(fileName = "Question Database", menuName = "Question Database")]
public class QuestionDatabase : ScriptableObject
{
    public Question[] questions;
}
