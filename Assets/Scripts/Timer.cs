using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private int seconds = 0;
    public UnityEvent OnTimerEnd = new UnityEvent();
    private void Start()
    {
        
    }

    private IEnumerator Countdown()
    {
        while (seconds > 0)
        {
            seconds--;
            yield return new WaitForSeconds(1);
        }
        OnTimerEnd.Invoke();
    }
}
