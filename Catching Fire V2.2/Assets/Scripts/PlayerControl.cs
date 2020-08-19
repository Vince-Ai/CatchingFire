using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            print("w");
            transform.Translate(Vector3.up * Time.deltaTime * 1);
        }

        //向下运动——S  
        if (Input.GetKey(KeyCode.S))
        {
            print("s");
            transform.Translate(Vector3.down * Time.deltaTime * 1);
        }

        //向左运动——A  
        if (Input.GetKey(KeyCode.A))
        {
            print("a");
            transform.Translate(Vector3.left * Time.deltaTime * 1);
        }

        //向右运动——D  
        if (Input.GetKey(KeyCode.D))
        {
            print("d");
            transform.Translate(Vector3.right * Time.deltaTime * 1);
        }
    }
}
