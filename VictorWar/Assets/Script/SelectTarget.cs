using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTarget : MonoBehaviour {
    public GameObject arrowPrefab;
    GameObject arrow;
    public bool startSelectBool;
    bool showArr;
    // Use this for initialization
    void Start () {
        showArr = false;
    }
	
	// Update is called once per frame
	void Update () {
        //print("Angle: " + this.transform.localEulerAngles);

        if (startSelectBool == true)
        {
            if (showArr == false)
            {
                showArrow();
                showArr = true;
            }

            // rotate the chess through arrow 
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //print("Rotate arror");

                this.transform.Rotate(0, Time.deltaTime * (-25), 0);

            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.Rotate(0, Time.deltaTime * (25), 0);

            }
        }
    }
    // Need a reset method
    void showArrow()
    {
        // appear a selecting arrow 
        // find the forward
        print(this.transform.forward);
        arrow = (GameObject)Instantiate(arrowPrefab,this.transform.position, transform.rotation);
        arrow.transform.parent = this.gameObject.transform;
        arrow.transform.position += transform.forward * 10;


    }
}
