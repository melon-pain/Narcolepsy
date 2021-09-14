using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterInteraction : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject interactText;
    private RaycastHit[] hits;

    private void Update()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Running"))
        {
            interactText.SetActive(false);
            return;
        }
        hits = Physics.SphereCastAll(this.transform.position + Vector3.up, 1.0f, Vector3.forward, 1.0f);
        foreach (RaycastHit hit in hits)
        {
            interactText.SetActive(false);
            if (hit.collider.tag == "Interactable")
            {
                interactText.GetComponent<TMP_Text>().text = "[F] " + hit.collider.GetComponent<Interactable>().interactionText;
                interactText.SetActive(true);
                if (Input.GetButtonDown("Interact"))
                {
                    hit.collider.GetComponent<Interactable>().OnInteract.Invoke();
                }
                return;
            }
        }
    }
}
