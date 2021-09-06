using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    RaycastHit[] hits;

    private void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            hits = Physics.SphereCastAll(this.transform.position + Vector3.up, 1.0f, Vector3.forward, 1.0f);
            foreach (RaycastHit hit in hits)
            {
                if(hit.collider.tag == "Interactable")
                {
                    Debug.Log("Interact");
                    break;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position + Vector3.up, 1.0f);
    }
}
