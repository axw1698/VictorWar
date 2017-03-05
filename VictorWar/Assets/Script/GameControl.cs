using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {
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
        currentTeam = 0;
	}
	
	// Update is called once per frame
	void Update () {
		while(gameEnd == false)
        {
            // select movement//

        }
	}
}
