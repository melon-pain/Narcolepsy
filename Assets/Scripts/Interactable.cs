using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public string interactionText = "Interact";
    [Space(4.0f)]
    public UnityEvent OnInteract = new UnityEvent();
    private void Start()
    {

    }
}
