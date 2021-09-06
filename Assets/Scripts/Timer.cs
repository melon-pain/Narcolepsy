using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private float minSeconds = 0;
    [SerializeField] private float maxSeconds = 60;
    private float seconds = 0;
    public UnityEvent<float> OnTimerUpdate = new UnityEvent<float>();
    public UnityEvent OnTimerEnd = new UnityEvent();
    
    private void Start()
    {
        seconds = Random.Range(minSeconds, maxSeconds);

        OnTimerUpdate.Invoke(seconds);
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        while (seconds > 0)
        {
            seconds -= 0.01f;
            OnTimerUpdate.Invoke(seconds);
            yield return new WaitForSeconds(0.01f);
        }
        OnTimerEnd.Invoke();
        yield break;
    }
}
