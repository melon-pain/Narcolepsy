using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    [SerializeField] private GameObject interactText;
    private RaycastHit[] hits;

    private void Update()
    {
        hits = Physics.SphereCastAll(this.transform.position + Vector3.up, 1.0f, Vector3.forward, 1.0f);
        foreach (RaycastHit hit in hits)
        {
            interactText.SetActive(false);
            if (hit.collider.tag == "Interactable")
            {
                interactText.SetActive(true);
                if (Input.GetButtonDown("Interact"))
                {
                    hit.collider.GetComponent<Interactable>().OnInteract.Invoke();
                }
                break;
            }
        }
    }
}
