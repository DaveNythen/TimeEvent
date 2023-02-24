using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Action onTimeisUp;

    public float timeToWait = 2;
    private float timeCounter;

    private void Start() => timeCounter = timeToWait;
    
    private void FixedUpdate()
    {
        timeCounter -= Time.deltaTime;
        if (timeCounter <= 0)
        {
            onTimeisUp?.Invoke();
            ResetTimer();
        }
    }

    private void OnEnable() => LetterTracker.onSuccess += ResetTimer;

    private void OnDisable() => LetterTracker.onSuccess -= ResetTimer;

    private void ResetTimer() => timeCounter = timeToWait;
}
