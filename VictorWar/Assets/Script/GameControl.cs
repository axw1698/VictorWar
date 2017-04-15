using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {
    public Camera[] cameras;
    private int gameRound;
    private int blueRemain;
    private int redRemain; // zero and lost
    private bool gameEnd;
    private int currentTeam; // 0 //0-red/1-blue
    // Use this for initialization
    void Start () {
        gameRound = 0;
        blueRemain = 14;
        redRemain = 14;
        gameEnd = false;
        currentTeam = 1;
        cameras[0].gameObject.SetActive(false);
        cameras[1].gameObject.SetActive(false);

        cameras[currentTeam].gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update () {



    }

    public int GetTeamId()
    {
        return currentTeam;
    }
    public void changeTeam()
    {
        print("Change Team");
        if(currentTeam == 1)
        {
            currentTeam = 0;
        }else if(currentTeam == 0)
        {
            currentTeam = 1;
        }

        // reset camera due to the team
        cameras[0].gameObject.SetActive(false);
        cameras[1].gameObject.SetActive(false);
        cameras[currentTeam].gameObject.SetActive(true);

        this.GetComponent<ControlID>().canSelect = true;
    }
}
