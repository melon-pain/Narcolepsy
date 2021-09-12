using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private bool isOpen = false;
    public void OnInteract()
    {
        isOpen = !isOpen;
        animator.SetBool("IsOpen", isOpen);
    }
}
