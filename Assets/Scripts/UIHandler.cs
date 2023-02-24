using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] TMP_Text letter;
    [SerializeField] Image imageTimer;
    [SerializeField] TMP_Text points;

    private int currentPoints;

    private void Start()
    {
        letter.text = "";
        currentPoints = 0;
        points.text = currentPoints.ToString();
        StartTimer();
    }

    private void OnEnable()
    {
        LetterTracker.onLetterChanged += UpdateLetter;
        LetterTracker.onSuccess += UpdatePoints;
        Timer.onTimeisUp += StartTimer;
    }

    private void OnDisable()
    {
        LetterTracker.onLetterChanged -= UpdateLetter;
        LetterTracker.onSuccess -= UpdatePoints;
        Timer.onTimeisUp -= StartTimer;
    }

    private void UpdateLetter(string currentLetter) => letter.text = currentLetter;

    private void StartTimer()
    {
        imageTimer.DOKill();
        imageTimer.fillAmount = 1;
        imageTimer.DOFillAmount(0, 2).SetLoops(-1).SetEase(Ease.Linear);
    }

    private void UpdatePoints()
    {
        currentPoints ++;
        points.text = currentPoints.ToString();
        StartTimer();
    }
}
