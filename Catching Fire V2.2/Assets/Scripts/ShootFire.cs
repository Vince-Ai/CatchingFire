using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFire : MonoBehaviour {

    public GameObject Ball;
    private GameObject Target;
    private float lastTime;
    private float curTime;
    private Vector3 Plane;

    // Use this for initialization
    void Start () {
        lastTime = Time.time;
        //gameObject.GetComponent<Renderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (gameObject.name);
        curTime = Time.time;
        if (curTime - lastTime >= 1)
        {
            Debug.Log("Shoot!");
            lastTime = curTime;
            //InvokeRepeating("Shoot", 1, 3);
            //GetPlane(gameObject.GetComponent<Rigidbody>().velocity);
            Shoot();
        }
        if(curTime >5)
        {
            //Destroy(gameObject);
        }
    }

    void Shoot()
    {
        float x, y, z;
        int num = 0;
        Vector3 foward = gameObject.GetComponent<Rigidbody>().velocity;
        Vector3 position = gameObject.transform.position;
        while (num <= 1)
        {
			x = UnityEngine.Random.Range(-5.0f, 5.0f);
			z = UnityEngine.Random.Range(-5.0f, 5.0f);
			y =UnityEngine.Random.Range(0.0f, 5.0f);
            if ((x * x + y * y + z * z) >= 3)
            {
                Target = Instantiate(Ball, new Vector3(position.x, position.y + gameObject.GetComponent<SphereCollider>().radius, position.z), Quaternion.identity);
                //Debug.Log(Target.transform.position);
                Target.GetComponent<Rigidbody>().velocity = new Vector3(x, y, z);
                //Target.GetComponent<Rigidbody>().AddForce(0, 10, 0);
				Debug.Log(Target.GetComponent<Rigidbody>().velocity );
                num++;
            }
        }
        //Vector3 position = gameObject.transform.position;
        //Target = Instantiate(Ball, new Vector3(position.x, position.y + 2 * gameObject.GetComponent<SphereCollider>().radius, position.z), Quaternion.identity);
        //Target.GetComponent<Rigidbody>().velocity = 5 * Plane;
        //Debug.Log(Plane);
    }

    void GetPlane(Vector3 foward)
    {
        Plane plane = new Plane(gameObject.GetComponent<Rigidbody>().velocity, gameObject.transform.position);
            //plane.SetNormalAndPosition();
    }
}
