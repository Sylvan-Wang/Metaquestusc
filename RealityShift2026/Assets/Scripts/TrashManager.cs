using UnityEngine;

public class TrashManager : MonoBehaviour
{
    public static TrashManager Instance;

    private int totalTrash;
    private bool completed = false;

    void Awake()
    {
        Instance = this;
    }

    public void RegisterTrash()
    {
        totalTrash++;
    }

    public void TrashRemoved()
    {
        totalTrash = Mathf.Max(0, totalTrash - 1);

        Debug.Log("Trash left: " + totalTrash);

        if (totalTrash == 0 && !completed)
        {
            completed = true;

            Debug.Log("All trash cleaned!");

            ChecklistManager manager = FindObjectOfType<ChecklistManager>();
            if (manager != null)
            {
                manager.CompleteTask("Clean trash");
            }

            SecondMonthGameplayManager gameplay = FindObjectOfType<SecondMonthGameplayManager>();
            if (gameplay != null)
            {
                gameplay.AddItemDisposed();
            }
        }
    }
}