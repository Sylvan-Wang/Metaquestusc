using UnityEngine;
using UnityEngine.Events;

public class TrashHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent OnTrashBagTriggerEnter;

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.TryGetComponent<TrashBagHandler>(out TrashBagHandler trashBag))
        {
            OnTrashBagTriggerEnter.Invoke();
            Destroy(gameObject);
        }
    }
}