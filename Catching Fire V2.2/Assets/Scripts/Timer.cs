using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.UI;

public class Timer : MonoBehaviour {

    int hour;
    int minute;
    int second;
    int millisecond;
	public bool timeContinuing = true;
	public string time;
    // 已经花费的时间  
    float timeSpend = 0.0f;

    // 显示时间区域的文本  
    public Text text_timeSpend;

    // Use this for initialization  
    void Start()
    {
        text_timeSpend = GetComponent<Text>();
    }

    // Update is called once per frame  
    void Update()
    {
		if (timeContinuing) {
			timeKeeping ();
		}

		time =Convert.ToString(minute)+" 分 "+Convert.ToString(second)+" 秒 "+Convert.ToString(millisecond)+" 毫秒";
		text_timeSpend.text = string.Format("{0:D2}:{1:D2}.{2:D3}", minute, second, millisecond);;
    }

	void timeKeeping(){
		timeSpend += Time.deltaTime;
		float timeSpent = timeSpend;

		hour = (int)timeSpend / 3600;
		minute = ((int)timeSpend - hour * 3600) / 60;
		second = (int)timeSpend - hour * 3600 - minute * 60;
		millisecond = (int)((timeSpend - (int)timeSpend) * 1000);

	}
}
