using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VRStandardAssets.Utils;

public class SceneChangeVR : MonoBehaviour {


	[SerializeField] private VRCameraFade m_CameraFade; 

	int mSceneIndex = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.A)) {
		
			mSceneIndex = 1;
			StartCoroutine (ActivateButton ());

		}

		if (Input.GetKeyDown (KeyCode.B)) {

			mSceneIndex = 1;
			StartCoroutine (ActivateButton ());

		}
	}

	public void GetIndexAndLoadScene(int index){
		mSceneIndex = index;
		StartCoroutine (ActivateButton ());
	}

	private IEnumerator ActivateButton()
	{
		// If the camera is already fading, ignore.
		if (m_CameraFade.IsFading)
			yield break;

		// Wait for the camera to fade out.
		yield return StartCoroutine (m_CameraFade.BeginFadeOut (true));

		SceneManager.LoadScene ("MainScene" + mSceneIndex.ToString (), LoadSceneMode.Single);

	}
}
