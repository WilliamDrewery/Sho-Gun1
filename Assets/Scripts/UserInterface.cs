using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserInterface : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    public float time;



    void Update()
    {
        time += Time.deltaTime;
        timerText.text=time.ToString("F2");
        //the time is updated constantly in seconds to 2 decimal places

    }
   
}
