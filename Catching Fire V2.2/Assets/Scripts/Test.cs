using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    public GameObject Wall;
    public GameObject fire;
	// Use this for initialization
	void Start () {
        //gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 10, 0);
	}
	
	// Update is called once per frame
	void Update () {
        Plane plane = new Plane();
        plane.SetNormalAndPosition(gameObject.GetComponent<Rigidbody>().velocity, gameObject.transform.position);
    }
    private void OnCollisionEnter(Collision collision)
    {
        //if(collision.transform.tag == "Flamable")
        //{
        //    Vector3 ObjPos = gameObject.transform.position;
        //    ContactPoint contact = collision.contacts[0];
        //    Vector3 Pos = contact.point;
        //    Vector3 PosX = new Vector3(Pos.x + 1, Pos.y, Pos.z);
        //    Vector3 PosY = new Vector3(Pos.x, Pos.y + 1, Pos.z);
        //    Vector3 PosZ = new Vector3(Pos.x, Pos.y, Pos.z + 1);
        //    Plane plane = new Plane(Wall.transform.up, Pos);
        //    Debug.Log("X"+ plane.SameSide(Pos, PosX));
        //    Debug.Log("Y" + plane.SameSide(Pos, PosY));
        //    Debug.Log("Z" + plane.SameSide(Pos, PosZ));
        //    float distance = plane.GetDistanceToPoint(Pos);
        //    Debug.Log("Distance:" + distance);
        //    Debug.Log("Pos" + (Pos-ObjPos));
        //    Debug.Log("PosX" + (PosX - ObjPos));
        //    Debug.Log("PosY" + (PosY - ObjPos));
        //    Debug.Log("PosZ" + (PosZ - ObjPos));
        //    Debug.Log("X:" + plane.GetDistanceToPoint(PosX));
        //    Debug.Log("Y:" + plane.GetDistanceToPoint(PosY));
        //    Debug.Log("Z:" + plane.GetDistanceToPoint(PosZ));
        //    Instantiate(fire, Pos, Quaternion.identity);
        //}
        foreach (ContactPoint contact in collision.contacts)
        {
            Vector3 Up = contact.normal;
            Debug.Log(Up);
            if (Up.x == 1.0f)
            {
                print("碰到右边");
            }
            if (Up.y == 1.0f)
            {
                print("碰到上边");
            }
            GameObject Target = Instantiate(fire, contact.point, Quaternion.identity) as GameObject;
            Target.transform.up = Up;
        }
    }
}
