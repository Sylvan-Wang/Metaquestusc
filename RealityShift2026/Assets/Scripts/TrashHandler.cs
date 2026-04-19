using UnityEngine;
using UnityEngine.Events;

public class TrashHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent OnTrashBagTriggerEnter;

    void Start()
    {
        if (TrashManager.Instance != null)
            TrashManager.Instance.RegisterTrash();
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.TryGetComponent<TrashBagHandler>(out TrashBagHandler trashBag))
        {
            OnTrashBagTriggerEnter.Invoke();

            if (TrashManager.Instance != null)
                TrashManager.Instance.TrashRemoved();

            Destroy(gameObject);
        }
    }
}