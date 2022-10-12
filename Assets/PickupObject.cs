using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IInteractable i;
        if (collision.TryGetComponent<IInteractable>(out i))
        {
            i.Interact();
        }
    }
}

public interface IInteractable
{
    public void Interact();
}
