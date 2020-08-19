using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHit : MonoBehaviour {

    public GameObject FireM;
    private GameObject FireS;
    public GameObject FireStarter;
    private bool Rx;
    float r;

    // Use this for initialization
    void Start () {
        //gameObject.GetComponent<Renderer>().enabled = false;
        r = gameObject.GetComponent<SphereCollider>().radius;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 dir = gameObject.GetComponent<Rigidbody>().velocity;
        if (collision.transform.tag == "Flamable")
        {
            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
           // Debug.Log(pos);
            //FireS = Instantiate(FireM, pos, rot) as GameObject;
            //FireS.transform.LookAt(FireStarter.transform.position);
            //FireS.transform.Rotate(new Vector3(0, 90, 0));

            if(r > 0.05f)
            {
                Rx = true;
                Debug.Log(Rx);
            }
            else if(r < 0.05f)
            {
                Rx = false;
                Debug.Log(Rx);
            }
            SetFire(pos);
        }
    }
    
    void SetFire(Vector3 pos)
    {
		float x, y;
        for(int i = 1; i <=8; i++)
        {
			y = Random.Range (-0.2f, 0.4f);
			x = Random.Range(-0.2f,0.2f);
            if (r == 0.05f)
            {
                GameObject Target = Instantiate(FireM, new Vector3(pos.x+x, pos.y, pos.z+x), Quaternion.identity) as GameObject;
                Target.transform.Rotate(new Vector3(90, 0, 0));
            }
            else
            {
                
                if (Rx)
                {
					GameObject Target = Instantiate(FireM, new Vector3(pos.x, pos.y + y, pos.z=x), Quaternion.identity) as GameObject;

                    if (r == 0.07f)
                    {
						
                        Target.transform.Rotate(new Vector3(0, 90, 0));
                    }
                    else
                    {
						
                        Target.transform.Rotate(new Vector3(0, -90, 0));
                    }
                }
                else
                {
					GameObject Target = Instantiate(FireM, new Vector3(pos.x+x, pos.y + y, pos.z), Quaternion.identity) as GameObject;
					Debug.Log("FIRE");
                    if (r == 0.03f)
                    {
                        Target.transform.Rotate(new Vector3(180, 0, 0));
                    }
                }
            }
            //if(!Rx)
            //{
            //    Target.transform.Rotate(new Vector3(0, , 0));
            //}
        }
    }

}
