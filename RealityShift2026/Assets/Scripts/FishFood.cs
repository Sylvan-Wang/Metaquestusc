using UnityEngine;

public class FishFood : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            Debug.Log("Triggered with: " + other.name);

            ChecklistManager manager = FindObjectOfType<ChecklistManager>();
            if (manager != null)
            {
                manager.CompleteTask("Feed fish");
            }

            Destroy(gameObject);
        }
    }
}
