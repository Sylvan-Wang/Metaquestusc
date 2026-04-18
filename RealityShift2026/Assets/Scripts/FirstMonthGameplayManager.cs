using UnityEngine;
using UnityEngine.Events;

public class FirstMonthGameplayManager : MonoBehaviour
{
    [SerializeField] private int itemsPlacedThreshold;
    [SerializeField] private UnityEvent onThresholdReached;
    private bool thresholdReached = false;
    private int itemsPlaced = 0;

    public void addItemPlaced()
    {
        itemsPlaced += 1;
        if (thresholdReached == false && itemsPlaced >= itemsPlacedThreshold)
        {
            thresholdReached = true;
            print("[Gameplay] Completed First Month Scenario");
            onThresholdReached.Invoke();
        }
    }

    public void removeItemPlaced()
    {
        if (itemsPlaced >= 0)
        {
            itemsPlaced -= 1;
        }
    }
}
