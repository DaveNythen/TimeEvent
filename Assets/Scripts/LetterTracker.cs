using System;
using UnityEngine;

public class LetterTracker : MonoBehaviour
{
    private string abc = "ABCDFGHIJKLMNOPQRSTUVWXYZ";
    private string currentLetter;

    public static Action onSuccess;
    public static Action<string> onLetterChanged;

    private void Start() => ShowNextLetter();

    private void OnEnable() => Timer.onTimeisUp += ShowNextLetter;

    private void OnDisable() => Timer.onTimeisUp -= ShowNextLetter;

    private void ShowNextLetter()
    {
        currentLetter = abc[UnityEngine.Random.Range(0, abc.Length)].ToString();
        onLetterChanged?.Invoke(currentLetter);
    }


    void Update()
    {
        foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(keyCode))
            {
                Debug.Log($"Key {keyCode.ToString()} was pressed.");
                if (keyCode.ToString().Equals(currentLetter))
                {
                    ShowNextLetter();
                    onSuccess?.Invoke();
                }
            }
        }
    }

}
