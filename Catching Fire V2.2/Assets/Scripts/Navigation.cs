using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigation : MonoBehaviour {

    public Transform TargetObject;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(TargetObject != null)
		{
			gameObject.GetComponent<NavMeshAgent>().destination = TargetObject.position;
		}
	}
}
