using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {
	
	public int SceneIndex;
	public SceneChangeVR script;


    private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "MainCamera") {
			Destroy (this.gameObject);
			script.GetIndexAndLoadScene (SceneIndex);
		}
	}
}
