using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroy : MonoBehaviour {

    private float CurTime;
    private float LastTime;

	// Use this for initialization
	void Start () {
        LastTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        CurTime = Time.time;
        if (CurTime - LastTime >= 10)
        {
            LastTime = CurTime;
            Destroy(gameObject);
        }
    }
}
