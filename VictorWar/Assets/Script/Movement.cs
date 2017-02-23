using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    // attribute
    public string charClass;
    private double attack;
    private double defence;
    private double friction;
	// Use this for initialization
	void Start () {
        // assign each character's value
		switch(charClass)
        {
            case "king":
                attack = 4;
                defence = 5;
                friction = 0.3;
                break;
            case "quardian":
                attack = 2;
                defence = 3;
                friction = 0.15;
                break;
            case "dogface":
                attack = 1;
                defence = 1.5;
                friction = 0.075;
                break;
        }
	}	
	// Update is called once per frame
	void Update () {
		
	}

    //function
    public void move(double velocity, double directionAngle)
    {
        // movement calculation code
    }
    public void getHit(double velocity, double directionAngle)
    {
        // code and calculation when get hit by other chess
    }

    // Get and Set
    public double getAtk()
    {
        return attack;
    }
    public double getDef()
    {
        return defence;
    }
    public double getFric()
    {
        return friction;
    }
    public void setAtk(double newAtk)
    {
        attack = newAtk;
    }
    public void setDef(double newDef)
    {
        defence = newDef;
    }
}
