using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class DayTimeController : MonoBehaviour
{
    //---------------------------hasta aqui es para poder regular el tiempo------------------------------
    float time;
    [SerializeField] Text text;
    [SerializeField] float timeScale = 60f;
    private int days;


    const float secondsInDay = 86400f;
    float Hours
    {
        get { return time / 3600f; }//con esto cambio el contador de segundo a que muestre horas
    }

    float Minutes
    {
        get { return time % 3600f / 60f; }//cambiamos los molestos decimales del contador a solo 2
    } 
    
    //----------------------------Esto es para oscurecer un poco las cosas-------------------------------------
    [SerializeField] Color nightLightColor;
    [SerializeField] AnimationCurve nightTimeCurve;
    [SerializeField] Color dayLightColor = Color.white;
    [SerializeField] Light2D globalLight;

    private void Update()
    {
        int mm = (int)Minutes;
        int hh = (int)Hours;

        time += Time.deltaTime * timeScale;//con esto regulo el tiempo para que sea mas rapido
        text.text = hh.ToString("00")+ ":" + mm.ToString("00");//nos quitamos los molestos decimales de la hora



        float v = nightTimeCurve.Evaluate(Hours);//variable que se usa para el tiempo en horas, simplemente para tener una variable libre
        Color c = Color.Lerp(dayLightColor, nightLightColor, v);//Lerp sirve para cambiar el colo A y el color B en un intervalo de tiempo
        globalLight.color = c;

        if (time > secondsInDay)
        {
            NextDay();
        }
    }

    private void NextDay()
    {
        time = 0;
        days += 1;
    }

}
