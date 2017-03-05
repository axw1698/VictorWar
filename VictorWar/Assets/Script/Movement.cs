using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Movement : MonoBehaviour {

    // attribute
    public string charClass;
    private float attack;
    private float defence;
    private float friction;
    private float velocity;
    Vector3 destination;
    bool ifMove;
    Vector3 target;
	// Use this for initialization
	void Start () {
        // assign each character's value
		switch(charClass)
        {
            case "king":
                attack = 40.0f;
                defence = 50.0f;
                friction = 0.5f;    //Need to change to make better logic
                break;
            case "quardian":
                attack = 20.0f;
                defence = 30.0f;
                friction = 1.5f;
                break;
            case "dogface":
                attack = 10.0f;
                defence = 15.0f;
                friction = 0.75f;
                break;
        }
        velocity = attack;
        ifMove = false;
    }
    // Update is called once per frame
    void Update () {
		if(Input.GetKeyDown(KeyCode.M))
        {
            destination = this.transform.position + (this.transform.forward * attack);

            ifMove = true;
            Debug.Log("Start to move");

        }
        if (ifMove == true)
        {

                //velocity -= friction;
                print("Velocity: " + velocity + " Attack: " + attack + " Distination: " + destination);

                transform.position = Vector3.MoveTowards(this.transform.position, destination, velocity *Time.deltaTime);

                //transform.Translate(Vector3.forward * Time.deltaTime * velocity);
            
            //transform.position = Vector3.MoveTowards(transform.position, target, velocity * Time.deltaTime);
        }


    }

    //function
    public void initMove(float atk)
    {
        Debug.Log("Call move init");

        // movement calculation code
        //float directionAngleRadian = Mathf.PI * directionAngle / 180.0f;
        //Vector3 destination;
       // destination.x = atk * Mathf.Sin(directionAngleRadian);
        //destination.z = atk * Mathf.Cos(directionAngleRadian);
        //Vector3 target = new Vector3(this.transform.position.x - destination.x,
        //                                  0,
        //                                 this.transform.position.z - destination.z);
        // change direction

        transform.Translate(Vector3.forward * Time.deltaTime);

    }

    public void getHit(float vel, float directionAngle)
    {
        // code and calculation when get hit by other chess
    }
    public bool ifStop(Vector3 target)
    {
        // if Reached target
        if (this.transform.position.x >= target.x && this.transform.position.y >= target.y)
        {
            
            return true;
        }
        else
        {
            return false;
        }
        // if collide

    }
    // Get and Set
    public float getAtk()
    {
        return attack;
    }
    public float getDef()
    {
        return defence;
    }
    public float getFric()
    {
        return friction;
    }
    public void setAtk(float newAtk)
    {
        attack = newAtk;
    }
    public void setDef(float newDef)
    {
        defence = newDef;
    }
}
