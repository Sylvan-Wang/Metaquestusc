using UnityEngine;
using UnityEngine.Events;

public class FirstMonthGameplayManager : MonoBehaviour
{
    [Header("Configurations")]
    [SerializeField] private int itemsPlacedThreshold;

    [Header("Event Triggers")]
    [SerializeField] private UnityEvent onThresholdReached;

    private bool thresholdReached = false;
    private int itemsPlaced = 0;

    public void AddItemPlaced()
    {
        itemsPlaced += 1;
        if (thresholdReached == false && itemsPlaced >= itemsPlacedThreshold)
        {
            thresholdReached = true;
            print("[Gameplay] Completed First Month Scenario");
            onThresholdReached.Invoke();
        }
    }

    public void RemoveItemPlaced()
    {
        if (itemsPlaced >= 0)
        {
            itemsPlaced -= 1;
        }
    }
}
