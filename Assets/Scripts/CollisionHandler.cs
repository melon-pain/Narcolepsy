using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionHandler : MonoBehaviour
{
    public UnityEvent OnCollision = new UnityEvent();

    private void Start()
    {
     
    }

    private void OnTriggerEnter(Collider other)
    {
        OnCollision.Invoke();
    }
}
