using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestions = 30f;
    [SerializeField] float timeToShowCorrectAnswer = 10f;

    public bool loadNextQuestion;
    public bool isAnsweringQuestion = false;
    public float fillFraction;
    float timerValue;
    void Update()
    {
        UpdateTimer();
        
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }
    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if(isAnsweringQuestion)
        {
            if(timerValue > 0)
            {
                fillFraction = timerValue / timeToCompleteQuestions; //0/10 = 0

            }
            else
            {
                isAnsweringQuestion = false;
                timerValue = timeToShowCorrectAnswer;
            }
        }
        else
        {

            if(timerValue > 0)
            {
                fillFraction = timerValue / timeToShowCorrectAnswer; //0/10 = 0
            }
            else
            {
                isAnsweringQuestion = true;
                timerValue = timeToCompleteQuestions;
                loadNextQuestion = true;
            }
        }
    
        //Debug.Log(isAnsweringQuestion + ":" + timerValue + "=" + fillFraction);
    }
}
