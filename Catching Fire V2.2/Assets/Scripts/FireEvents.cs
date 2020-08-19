using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FireEvents : MonoBehaviour {

	public bool isOver = false;
	private float letterPause = 0.1f;
	public GameObject objL;
	public GameObject objR;
	public GameObject hudCanvas;
	public Text text;
	public AudioSource playerAudio;
	public Image hudImage;
	public SceneChangeVR script;

	public ParticleSystem cube1;
	public ParticleSystem cube2;
	public ParticleSystem cube3;
	public ParticleSystem cube4;

	SteamVR_TrackedObject trackedL;
	SteamVR_TrackedObject trackedR;

	private int startParam = 0;
	private int endParam = 0;
	private string word;
	private string moveOn = "\n按下任意键继续_";
	private bool anyButtonPressed;
	private bool triggerClicked;
	private bool win = false;



	void Start(){
		trackedL = objL.GetComponent<SteamVR_TrackedObject> ();
		trackedR = objR.GetComponent<SteamVR_TrackedObject> ();
		hudImage.enabled = true;

		word = "欢迎来到FireRun！" + moveOn;
		StartCoroutine(TypeText());
		startParam++;
	}


	void FixedUpdate(){
		var deviceLeft = SteamVR_Controller.Input ((int)trackedL.index);
		var deviceRight = SteamVR_Controller.Input ((int)trackedR.index);

		anyButtonPressed = 
			   deviceLeft.GetPressDown (SteamVR_Controller.ButtonMask.Trigger)
			|| deviceLeft.GetPressDown (SteamVR_Controller.ButtonMask.ApplicationMenu)
			|| deviceLeft.GetPressDown (SteamVR_Controller.ButtonMask.Touchpad)
			|| deviceLeft.GetPressDown (SteamVR_Controller.ButtonMask.Grip)
			|| deviceRight.GetPressDown (SteamVR_Controller.ButtonMask.Trigger)
			|| deviceRight.GetPressDown (SteamVR_Controller.ButtonMask.ApplicationMenu)
			|| deviceRight.GetPressDown (SteamVR_Controller.ButtonMask.Touchpad)
			|| deviceRight.GetPressDown (SteamVR_Controller.ButtonMask.Grip);
		triggerClicked = 
			   deviceLeft.GetPressDown (SteamVR_Controller.ButtonMask.Trigger)
			|| deviceRight.GetPressDown (SteamVR_Controller.ButtonMask.Trigger);
	}





	void Update(){
		
		if (anyButtonPressed && startParam <= 6) {
			GameIn ();
		}

		else if (cube1.isStopped && cube2.isStopped && cube3.isStopped && cube4.isStopped) {
			if (endParam==0) {
				GameOut ();
				word = "恭喜你！完成了任务！" + moveOn;
				ShowText ();
				endParam++;
			}
			else if (anyButtonPressed && endParam >0) {
				End ();
			}
		}	
	}






	private void GameIn(){
		switch (startParam) {
			case 1:
				word = "这是一个灭火器使用教程" + moveOn;
				ShowText ();
				startParam++;
				break;
		
			case 2:
				
				word = "你需要正确操控灭火器将木块上的火扑灭" + moveOn;
				ShowText ();
				startParam++;
				break;
		
			case 3:
				word = "先抓住灭火器，拔掉插销" + moveOn;
				ShowText ();
				startParam++;
				break;

			case 4:
				word = "然后将喷头对准火焰根部喷射"+moveOn;
				ShowText ();
				startParam++;
				break;

			case 5:
				word = "准备好了吗？\n马上开始！\n按下任意Trigger进入游戏";
				ShowText ();
				startParam++;
				break;
		
			case 6:
				text.text = "";
				hudCanvas.SetActive (false);
			    playerAudio.Play();
				startParam++;
				break;

		default:
			break;
		}
	}
		

	private void End (){
		switch (endParam) {
		case 1:
			word = "相信你已经学会使用灭火器了！" + moveOn;
			ShowText ();
			endParam++;
			break;

		case 2:
			word = "希望你能将此应用到生活中" + moveOn;
			ShowText ();
			endParam++;
			break;

		case 3:
			word = "欢迎回来！\n按下任意键退出游戏_";
			ShowText ();
			endParam++;
			break;

		case 4:
			script.GetIndexAndLoadScene (1);
			break;

		default:
			break;
		}
	}

	public void GameOut (){

		hudCanvas.SetActive(true); 	
		playerAudio.Stop();
		hudImage.enabled = true;
		text.color = Color.white;
		hudImage.color = Color.Lerp (Color.black, Color.clear, 3f * Time.deltaTime);
	}


	private IEnumerator TypeText()
	{
		text.text = "";
		foreach (char letter in word.ToCharArray())
		{
			text.text += letter;
			yield return new WaitForSeconds(letterPause);
		}
	}


	private void ShowText(){
		StopAllCoroutines ();
		StartCoroutine(TypeText());
		return;
	}
}