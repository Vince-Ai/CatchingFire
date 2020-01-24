using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TheEventManager : MonoBehaviour {

	public float letterPause = 0.1f;
	public bool isOver;
	public GameObject objL;
	public GameObject objR;
	public GameObject hudCanvas;
	public GameObject timeCanvas;
	public GameObject hudCollider;
	public GameObject sphere;
	public GameObject[] fires;
	public PlayerMovement pmL;
	public PlayerMovement pmR;
	public PlayerHealth playerhealth;
	public Text text;
	public Timer timer;
	public AudioSource playerAudio;
	public SceneChangeVR script;

	SteamVR_TrackedObject trackedL;
	SteamVR_TrackedObject trackedR;

	private int startParam = 0;
	private int endParam = 0;
	private string word;
	private string moveOn;  
	private bool anyButtonPressed;
	private bool triggerClicked;
	private bool win = false;
	private Image hudImage;


	private string[,] words = { 
		{  
			"\n按下任意键继续",
		//start string
			"这是一个火灾逃生演练游戏\n你需要在最短的时间内\n按照逃生路线离开着火区" ,
			"当你进入火堆后血条值会下降\n降到零就会死亡",
			"你的手上有两个手柄，他们的\n按键分别具有不同的功能" ,
			"按下圆盘移动，按下Trigger开门",
			"请记住：逃生时一定要弯腰！",
			"准备好了吗？\n马上开始！\n按下任意Trigger进入游戏",
		//end string
			"在真正的火灾中\n请一定要保持镇定！" ,
			"重视火灾教育，从我做起！",
			"欢迎回来！\n按下任意键退出游戏_"
		},
		{  
			"\nPress any button to move on",
		//start string
			"In this level you will try to \nescape from fire scenes",
			"When you run into fire you will get hurt.",
			"You now have two triggers with you ",
			"Press Pad to move and Trigger to open doors",
			"Remember to bend down will escaping.",
			"Are you ready? \n Press any button to move on_",
		//end string
			"REember to remain calm\n in real fire hazard",
			"Hoe you have learn the basic skills of escaping",
			"REmember to come back!\nPress any btton to exit"
		}
	};


	void Awake(){
		trackedL = objL.GetComponent<SteamVR_TrackedObject> ();
		trackedR = objR.GetComponent<SteamVR_TrackedObject> ();
		hudCanvas = GameObject.Find ("HUDCanvas");
		hudImage = hudCanvas.GetComponent<Image> ();
		timer = GameObject.Find ("Time").GetComponent<Timer> ();
		pmL = objL.GetComponent<PlayerMovement> ();
		pmR = objR.GetComponent<PlayerMovement> ();
		playerhealth = GetComponent<PlayerHealth> ();
		playerAudio = GetComponent<AudioSource> ();
		hudCollider = GameObject.Find ("_CurvedUIColliders");
	}


	void Start(){
		sphere.SetActive (false);
		pmL.enabled = false;
		pmR.enabled = false;
		isOver = false;
		timer.timeContinuing = false;
		hudImage.enabled = true;
		moveOn = words [1, 0];
		word = "Welcome to Level 1！" + moveOn; 
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
		if (anyButtonPressed && startParam <= 7) {
			GameIn ();
		}

		else if (win) {
			if (endParam==0) {
				GameOut ();
				word = "Congratulations! You used\n" + timer.time + "\nto get out" + moveOn;
				ShowText ();
				endParam++;
			}
			else if (anyButtonPressed && endParam >0) {
				End ();
			}
		}

		else if (isOver) {
			if (endParam==0) {
				GameOut ();

				word = "You died after\n" + timer.time + "\n！" + moveOn;
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
				word = words [1, 1] + moveOn;
				ShowText ();
				startParam++;
				break;
		
			case 2:				
				word = words [1, 2] + moveOn;
				ShowText ();
				startParam++;
				break;
		
			case 3:
				word = words[1 , 3] + moveOn;
				ShowText ();
				startParam++;
				break;

			case 4:
				word = words[1 , 4] + moveOn;
				ShowText ();
				startParam++;
				break;

			case 5:
				word =words[1 , 5] + moveOn;
				ShowText ();
				startParam++;
				break;
		
			case 6:
				word = words [1, 6];
				ShowText();
				startParam++;
				break;

			case 7:
				text.text = "";
				hudCanvas.SetActive (false);
				hudCanvas.GetComponent<Image> ().enabled = false;
				hudImage.color = Color.black;
				pmL.enabled = true;
				pmR.enabled = true;
				timer.timeContinuing = true;
				sphere.SetActive (true);
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
			word = words [1, 7] + moveOn;
			ShowText ();
			endParam++;
			break;

		case 2:
			word = words [1, 8] + moveOn;
			ShowText ();
			endParam++;
			break;

		case 3:
			word = words [1, 9];
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
		
	//	this.GetComponent<CapsuleCollider> ().center.y = 0;
		sphere.SetActive(false);
		hudCanvas.SetActive(true); 	
		pmL.enabled = false;
		pmR.enabled = false;
		playerhealth.damageImage.enabled = false;
		timer.timeContinuing = false;
		playerAudio.Stop();
		hudImage.enabled = true;
		text.color = Color.white;
		hudImage.color = Color.Lerp (Color.black, Color.clear, 3f * Time.deltaTime);

		fires = GameObject.FindGameObjectsWithTag ("Fire");
		foreach (var gameObject in fires) {
			Destroy (gameObject);
		}
	}
		

	private void OnCollisionStay(Collision other){
		if (other.gameObject.tag=="Fire") {
			playerhealth.damaged = true;
		}
		else if (other.gameObject.tag=="Finish") {
			win = true;
		}
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