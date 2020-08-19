using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestSceneChange : MonoBehaviour {


    [HideInInspector]
    public int levelIndex;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

	void Update () {
		
	}

    public void Test()
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
