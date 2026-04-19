using UnityEngine;
using UnityEngine.Events;

public class SecondMonthGameplayManager : MonoBehaviour
{
    [Header("Configurations")]
    [SerializeField] private int itemsDisposedThreshold;
    [SerializeField] private int fishFedThreshold;
    [SerializeField] private int emailsReadThreshold;

    [Header("Event Triggers")]
    [SerializeField] private UnityEvent onItemsDisposedThresholdReached;
    [SerializeField] private UnityEvent onFishFedThresholdReached;
    [SerializeField] private UnityEvent onEmailsReadThresholdReached;
    [SerializeField] private UnityEvent onAllThresholdsReached;

    private int itemsDisposed = 0;
    private int fishFed = 0;
    private int emailsRead = 0;
    
    private bool allThresholdsReached = false;

    private void CheckCompletion()
    {
        if (itemsDisposed >= itemsDisposedThreshold && fishFed >= fishFedThreshold && emailsRead >= emailsReadThreshold)
        {
            if (allThresholdsReached == false)
            {
                allThresholdsReached = true;
                print("[Gameplay] Completed Second Month Scenario");
                onAllThresholdsReached.Invoke();
            }
        }
    }

    public void AddItemDisposed()
    {
        if (itemsDisposed < itemsDisposedThreshold)
        {
            itemsDisposed += 1;
            if (itemsDisposed >= itemsDisposedThreshold)
            {
                onItemsDisposedThresholdReached.Invoke();
            }
        }
    }

    public void AddFishFed()
    {
        if (fishFed < fishFedThreshold)
        {
            fishFed += 1;
            if (fishFed >= fishFedThreshold)
            {
                onFishFedThresholdReached.Invoke();
            }
        }
    }

    public void AddEmailsRead()
    {
        if (emailsRead < emailsReadThreshold)
        {
            emailsRead += 1;
            if (emailsRead >= emailsReadThreshold)
            {
                onEmailsReadThresholdReached.Invoke();
            }
        }
    }
}
