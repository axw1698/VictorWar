using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlID : MonoBehaviour {
    private int currentId;
    public string currentClassName;
    public int currentTeamId; //0-red/1-blue
    GameObject objClicked;
    public bool canSelect;

    // Use this for initialization
    void Start () {
        objClicked = null;
        currentTeamId = this.GetComponent<GameControl>().GetTeamId();
    }
	
	// Update is called once per frame
	void Update () {
        // check what clicked
        currentTeamId = this.GetComponent<GameControl>().GetTeamId();

        if (objClicked != null && canSelect == true && currentTeamId == objClicked.GetComponent<Movement>().team)
        {
            objClicked.GetComponent<SelectTarget>().startSelectBool = true;
            objClicked.GetComponent<Movement>().attackActivate = true;
            canSelect = false;
            // Need to find a way turn off others after clicked
        }
        // check team
        // change Camera

        // check class
        // change skill

        // check id
        //start movement

    }
    public void GetClickedGameObject(GameObject clickedGO)
    {
        Debug.Log("Clicked: " + clickedGO.name);

        objClicked = clickedGO;
    }
    void OnMouseOver()
    {
        //Debug.Log("Mouse Over");
        //// was clicked do something
        //if (Input.GetMouseButton(0))
        //{
        //    Destroy(this.gameObject);
        //}
    }
}
