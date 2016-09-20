using UnityEngine;
using System.Collections;

public class countdownTimer : MonoBehaviour {

	public float min = 0;//Time.time/60;
	public float sec = 59;//Time.time%60;
	public GUIText timer;

	void Start () {

	}

	void Update () {
		if (sec <= 0) {
			sec = 59;
			if (min >= 1) {
				min --;
			} else {
				min = 0;
				sec = 0;
				 timer.text = (min.ToString ("f0") + ":" + sec.ToString ("f0"));
			}
		} 
		else 
		{
			sec -= Time.deltaTime;
		}
		if (Mathf.Round (sec) <= 9) {
			timer.text = (min.ToString ("f0") + ":0" + sec.ToString ("f0"));
		}
		else 
		{
			timer.text = (min.ToString ("f0") + ":" + sec.ToString ("f0"));
		}
	}
}
