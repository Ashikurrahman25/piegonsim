using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputHandle : MonoBehaviour
{
    private PlayerMovement Player;

    public float Horizontal;
    public float Vertical;
    public float maximumHeight;
    public float minimumHeight;
    public float autoFlightHeight;

    public bool Jump;
    public bool JumpHold;

    public bool Accelerate;

    public bool LB;
    public bool RB;

    public bool Fly;
    public bool acceptJoystick;

    public Joystick joystick;
    public Flight flight;
    public BirdType type;

    public Rigidbody rigid;
    public TMP_Text flyText;
    public PlayerMovement player;

    private void Start()
    {
        
        Player = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        if(type == BirdType.Player)
        {
            if (acceptJoystick && flight.isFlyig)
            {

                Horizontal = joystick.Horizontal;
                Vertical = joystick.Vertical;
            }
            else
            {
                Horizontal = Input.GetAxis("Horizontal");
                Vertical = Input.GetAxis("Vertical");

                Jump = Input.GetButtonDown("Jump");
                JumpHold = Input.GetButton("Jump");
                Fly = JumpHold;
            }

            if (rigid.transform.position.y >= autoFlightHeight  && !flight.shouldLand)
            {
                Fly = true;
                JumpHold = true;
                Jump = true;
                //Vertical = 0;
                flight.autoFlight = true; 
            }


            if (flight.autoFlight)
            {
                if (rigid.transform.position.y >= maximumHeight)
                    rigid.transform.position = new Vector3(rigid.position.x, maximumHeight, rigid.position.z);

                if (rigid.transform.position.y <= minimumHeight)
                    rigid.transform.position = new Vector3(rigid.position.x, minimumHeight, rigid.position.z);
            }

            flyText.text = $"You are flying {rigid.transform.position.y.ToString("00")}M height";
        }

        else if (type == BirdType.AI)
        {
            if(player!= null && player.GetComponent<InputHandle>().Fly)
            {
                if (rigid.transform.position.y >= 90f)
                {
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                    Vertical = 0;
                }
                else
                {
                    Fly = true;
                    JumpHold = true;
                    Jump = true;
                    Vertical = -.1f;
                }
        
            }

           

            //flight.autoFlight = true;
        }
        //RB = Input.GetButton("RightTilt");
        //LB = Input.GetButton("LeftTilt");

    }
}

public enum BirdType
{
    Player,
    AI
}
