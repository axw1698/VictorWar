using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Movement : MonoBehaviour {

    // attribute
    public string charClass;
    public int id;
    public int team;

    public bool attackActivate;
    private float attack;
    private float defence;
    private float friction;
    private float velocity;
    private Vector3 originPos;
    Vector3 destination;
    bool ifMove;
    Vector3 target;
    private float remainAttack;
	// Use this for initialization
	void Start () {
        // assign each character's value
		switch(charClass)
        {
            case "king":
                attack = 40.0f;
                defence = 5.0f;    // change for better result
                friction = 0.5f;    //Need to change to make better logic
                break;
            case "quardian":
                attack = 20.0f;
                defence = 3.0f;
                friction = 1.5f;
                break;
            case "dogface":
                attack = 10.0f;
                defence = 2.0f;
                friction = 0.75f;
                break;
        }
        velocity = attack;
        ifMove = false;
    }
    // Update is called once per frame
    void Update () {
		if(Input.GetKeyDown(KeyCode.M) && attackActivate == true)
        {
            velocity = attack;
            destination = this.transform.position + (this.transform.forward * attack);
            originPos = this.transform.position;
            ifMove = true;
            //Debug.Log("Start to move");
            //attackActivate = false;

        }
        if (ifMove == true)
        {

            //velocity -= friction;
            print(charClass+" : Velocity: " + velocity + " Attack: " + attack + " Distination: " + destination);

            transform.position = Vector3.MoveTowards(this.transform.position, destination, velocity *Time.deltaTime);
            remainAttack = attack-(this.transform.position - originPos).magnitude;
            if(remainAttack <= 0&&attackActivate == true)
            {
                ifMove = false;
                //attackActivate = false;
            }
            if(Vector3.Distance(this.transform.position,destination)<0.1f)
            {
                ifMove = false;

            }
            //transform.Translate(Vector3.forward * Time.deltaTime * velocity);
            print(charClass + " remain Attack: " + remainAttack);
            //transform.position = Vector3.MoveTowards(transform.position, target, velocity * Time.deltaTime);
        }


    }

    //function
    public void initMove()
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

    public void getHit(float atk,GameObject hitObj)
    {
        // code and calculation when get hit by other chess
        // minus instead of division
        velocity = atk - defence;
        print("Get hit Velocity: " + atk);

        if (velocity<=0)
        {
            return;
            // nothing happened
        }
        else
        {
            print("GETTTT HITTTTTT");
            destination = this.transform.position + (hitObj.transform.forward * velocity);
            ifMove = true;
            this.transform.forward = hitObj.transform.forward;
        }
    }
    // if collide
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "board")
        {
            if (attackActivate == true)
            {
                foreach (ContactPoint contact in collision.contacts)
                {
                    print(contact.thisCollider.name + " hit " + contact.otherCollider.name);
                    Debug.DrawRay(contact.point, contact.normal, Color.white);
                }
                Debug.Log("Collide with " + collision.gameObject.name+" Stop moving!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

                ifMove = false;
            }
            if(attackActivate == false)
            {
                Debug.Log("Collide with " + collision.gameObject.name + " Get Hit!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

                getHit(collision.gameObject.GetComponent<Movement>().getAtk(),collision.gameObject);
            }
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject.FindGameObjectWithTag("GC").GetComponent<ControlID>().GetClickedGameObject(this.gameObject);
        }
    }
    // Get and Set
    public float getAtk()
    {
        return remainAttack;
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
