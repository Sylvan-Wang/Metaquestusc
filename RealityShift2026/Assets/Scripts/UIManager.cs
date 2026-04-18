using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI checklistText;

    void Awake()
    {
        Instance = this;
    }

    public void UpdateChecklistUI(List<Task> tasks)
    {
        string text = "";

        foreach (var task in tasks)
        {
            string status = task.isCompleted ? "[X]" : "[ ]";
            text += status + " " + task.taskName + "\n";
        }

        checklistText.text = text;
    }
}