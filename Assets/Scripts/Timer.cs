using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

  public static float timerValue = 0;

  public Text timerText;

  void Start()
  {
    timerText.text = timerValue.ToString();
  }
  void FixedUpdate()
  {
    timerValue += Time.deltaTime;
    timerText.text = "Time: " +timerValue.ToString();

  }
}
