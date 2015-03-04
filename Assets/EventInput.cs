using UnityEngine;
using System.Collections;

public class EventInput : MonoBehaviour {

	// Use this for initialization
    public Input input;
	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
        GameObject bille = GameObject.Find("BilleBlanche");
        if (Input.GetKeyDown("space")) {

            GameObject canne = GameObject.Find("canne");
            canne.SendMessage("Hit");
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            bille.rigidbody.position = new Vector3(95f, 78.3f, -7.8f);
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            GameObject canne = GameObject.Find("canne");
            canne.SendMessage("RotateLeft");
          
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            GameObject canne = GameObject.Find("canne");
            canne.SendMessage("RotateRight");

        }
	}
}
