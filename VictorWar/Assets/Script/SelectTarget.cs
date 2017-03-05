using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTarget : MonoBehaviour {
    public GameObject arrowPrefab;
    GameObject arrow;

	// Use this for initialization
	void Start () {
        //arrow = this.transform.Find("Arrow").gameObject;
        //arrow.
    }
	
	// Update is called once per frame
	void Update () {
        //print("Angle: " + this.transform.localEulerAngles);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            startSelect();
        }
        // rotate the chess through arrow 
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //print("Rotate arror");

            this.transform.Rotate(0, Time.deltaTime * (-25), 0);

        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Rotate(0, Time.deltaTime * (25), 0);

        }
    }

    void startSelect()
    {
        // appear a selecting arrow 
        // find the forward
        print(this.transform.forward);
        arrow = (GameObject)Instantiate(arrowPrefab,this.transform.position, transform.rotation);
        arrow.transform.parent = this.gameObject.transform;
        arrow.transform.position += transform.forward * 10;


    }
}
