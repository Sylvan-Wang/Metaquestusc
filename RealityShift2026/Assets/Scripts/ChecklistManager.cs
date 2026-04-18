using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChecklistManager : MonoBehaviour
{
    public List<Task> tasks = new List<Task>();

    void Start()
    {
        UIManager.Instance.UpdateChecklistUI(tasks);
        StartCoroutine(AutoCompleteTasks());
    }

    IEnumerator AutoCompleteTasks()
    {
        foreach (var task in tasks)
        {
            yield return new WaitForSeconds(5f);

            task.isCompleted = true;
            UIManager.Instance.UpdateChecklistUI(tasks);

            Debug.Log("Auto completed: " + task.taskName);
        }
    }

    public void CompleteTask(string taskName)
    {
        foreach (var task in tasks)
        {
            if (task.taskName == taskName && !task.isCompleted)
            {
                task.isCompleted = true;

                UIManager.Instance.UpdateChecklistUI(tasks);
                Debug.Log("Completed: " + taskName);
                return;
            }
        }
    }
}