using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test02 : MonoBehaviour {

    private Vector3 Vel;
    private Plane Plane;
    public bool DirX;
    public bool DirZ;
    public GameObject Ball;
    private Vector3 LastPos;
    private Vector3 CurPos;
    private float lastTime;
    private float curTime;

    // Use this for initialization
    void Start () {
        LastPos = gameObject.transform.position;
        lastTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        curTime = Time.time;
        curTime = Time.time;
        if (curTime - lastTime >= 0.3)
        {
            CurPos = gameObject.transform.position;
            Vel = CurPos - LastPos;
            lastTime = curTime;
            LastPos = CurPos;
            //Vel = gameObject.GetComponent<Rigidbody>().velocity;
            Plane = new Plane(gameObject.transform.position, Vel);
            //Debug.Log("V" + Vel);
            //Debug.Log("CPos" + CurPos);
            //Debug.Log("LPos" + LastPos);
            if (Vel.y >= 0.01 || Vel.y <= -0.01)
            {
                Debug.Log("Going Up or Down");
            }
            else
            {
                if(Vel.x > Vel.z)
                {
					DirX = true;
					DirZ = false;
                    Debug.Log("X>Z");
                }
                else
                {
					DirX = false;
					DirZ = true;
                    Debug.Log("Z>X");
                }
                Shoot();
            }
        }
        
	}

    private void Shoot()
    {
        Vector3 position = gameObject.transform.position;
        GameObject Target = Instantiate(Ball, new Vector3(position.x, position.y + gameObject.GetComponent<SphereCollider>().radius, position.z), Quaternion.identity) as GameObject;
        if (DirX)
        {
            Target.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1);
            Target.GetComponent<SphereCollider>().radius -= 0.02f;
            Target = Instantiate(Ball, new Vector3(position.x, position.y + gameObject.GetComponent<SphereCollider>().radius, position.z), Quaternion.identity) as GameObject;
            Target.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1);
            Target.GetComponent<SphereCollider>().radius -= 0.01f;
        }
        if (DirZ)
        {
            Target.GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 0);
            Target.GetComponent<SphereCollider>().radius += 0.01f;
            Target = Instantiate(Ball, new Vector3(position.x - 1, position.y + gameObject.GetComponent<SphereCollider>().radius, position.z), Quaternion.identity) as GameObject;
            Target.GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, 0);
            Target.GetComponent<SphereCollider>().radius += 0.02f;
        }
        Target = Instantiate(Ball, new Vector3(position.x, position.y + 2*gameObject.GetComponent<SphereCollider>().radius, position.z), Quaternion.identity) as GameObject;
        Target.GetComponent<Rigidbody>().velocity = new Vector3(0, 1, 0);
    }
        //获取物体速度方向
        //生成与速度方向垂直的平面
        //在平面上生成向量发射小球
        //根据速度方向调整火焰位置

}
