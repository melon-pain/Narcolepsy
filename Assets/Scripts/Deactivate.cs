using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    private void Start()
    {
        
    }

    public void DeactivateAfterTimer(float seconds)
    {
        StartCoroutine(Timer(seconds));
    }

    private IEnumerator Timer(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        this.gameObject.SetActive(false);
        yield break;
    }
}
