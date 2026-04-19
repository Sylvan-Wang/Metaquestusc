using UnityEngine;
using Oculus.Interaction;

public class TrashBagHandler : MonoBehaviour
{
    [SerializeField] private SnapInteractable snapInteractable;

    public void UnselectInteractors()
    {
        if (snapInteractable.SelectingInteractors.Count > 0)
        {
            snapInteractable.enabled = false;
            snapInteractable.enabled = true;
        }
    }
}
