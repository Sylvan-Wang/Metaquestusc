using UnityEngine;
using UnityEngine.Events;

public class FirstMonthGameplayManager : MonoBehaviour
{
    [Header("Configurations")]
    [SerializeField] private int itemsPlacedThreshold;

    [Header("Timer")]
    [SerializeField] private float timeLimit = 60f; // seconds

    [Header("Event Triggers")]
    [SerializeField] private UnityEvent onThresholdReached;

    private bool thresholdReached = false;
    private int itemsPlaced = 0;
    private float timer = 0f;

    void Update()
    {
        if (thresholdReached) return;

        timer += Time.deltaTime;

        if (timer >= timeLimit)
        {
            Debug.Log("[Gameplay] Time ran out!");
            TriggerCompletion();
        }
    }

    public void AddItemPlaced()
    {
        if (thresholdReached) return;

        itemsPlaced += 1;

        if (itemsPlaced >= itemsPlacedThreshold)
        {
            Debug.Log("[Gameplay] Completed First Month Scenario");
            TriggerCompletion();
        }
    }

    public void RemoveItemPlaced()
    {
        if (itemsPlaced > 0)
        {
            itemsPlaced -= 1;
        }
    }

    void TriggerCompletion()
    {
        if (thresholdReached) return;

        thresholdReached = true;

        onThresholdReached.Invoke();
    }
}