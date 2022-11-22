using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTimeController : MonoBehaviour
{
    float time;

    const float secondsInDay = 86400f;

    [SerializeField] Color nightLightColor;
    [SerializeField] AnimationCurve nightTimeCurve;
    [SerializeField] Color dayLightColor = Color.white;
}
