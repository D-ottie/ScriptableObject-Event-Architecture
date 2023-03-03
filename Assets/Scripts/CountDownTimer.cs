using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
public class CountDownTimer : MonoBehaviour
{
    public float timeLeft;
    private float timeInterval = 1;
    public IntEvent onTimeOver;
    public TextMeshProUGUI timerText; 
    public FloatEvent onCountdownUpdateValue;

    void Start()
    {
        //onTimeOver.AddListener(onGameOver);
        StartCoroutine(StartCountDown());
        
    }
    IEnumerator StartCountDown()
    {
        timeLeft = 10f;
        while( timeLeft >= 0)
        {
          yield return new WaitForSeconds(timeInterval);
          onCountdownUpdateValue.Raise(timeInterval);
          timeLeft -= 1;
        }
        //onTimeOver.Invoke();
        onTimeOver.Raise(1);
        Debug.Log("TimeUp");
    }

    public void UpdateText()
    {
       timerText.text = (timeLeft).ToString() + " : 00";
    }
    public void RestartTimer()
    {
        timeLeft = 10;
    }


}