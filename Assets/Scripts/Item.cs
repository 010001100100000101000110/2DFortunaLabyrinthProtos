using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    [SerializeField] GameEvent gameEvent;

    public void Interact()
    {
        gameEvent.Raise();
        gameObject.SetActive(false);
    }
}
