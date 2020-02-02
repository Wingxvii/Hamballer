using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class MoveHamsterWithGyro : MonoBehaviour
{

    public float Speed;
    public float Jump;
    public Rigidbody2D hamsterRigid;
    public Transform hamsterBall;
    public Grapple grapple;

    private float currentSpeed = 0;

    void Awake()
    {
        hamsterRigid = GetComponent<Rigidbody2D>();
        AirConsole.instance.onMessage += OnMessage;
    }
    void OnMessage(int from, JToken data)
    {
        //Debug.Log(data.ToString());
        if(data["action"] != null)
        {
            switch (data["action"].ToString())
            {
                case "motion":
                    if (data["motion_data"] != null)
                    {

                        if (data["motion_data"]["x"].ToString() != "")
                        {
                            //Debug.Log(data["motion_data"]["x"].ToString());
                            //hamsterRigid.velocity = new Vector2(hamsterRigid.velocity.x - (((float) data["motion_data"]["x"]/10) * Speed), hamsterRigid.velocity.y);
                            currentSpeed = (((float)data["motion_data"]["x"] / 10) * Speed);
                        }
                    }
                    break;
                case "jump":
                    hamsterRigid.velocity += new Vector2(hamsterBall.position.x - transform.position.x, hamsterBall.position.y - transform.position.y) * Jump;
                    break;
                case "position":
                    //Debug.Log("position recived");
                    grapple.Shoot();
                    break;
                default:
                    Debug.Log(data);
                    break;
            }
        }
        if(data["joystick_left"] != null)
        {
            if(data["joystick_left"]["position"] != null)
            {
                grapple.controllerDir = new Vector2((float)data["joystick_left"]["position"]["x"], -(float)data["joystick_left"]["position"]["y"]);
                grapple.Shoot();
            }
        }
    }
    void OnDestroy()
    {
        if (AirConsole.instance != null)
        {
            AirConsole.instance.onMessage -= OnMessage;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        hamsterRigid.velocity = new Vector2(hamsterRigid.velocity.x - currentSpeed, hamsterRigid.velocity.y);
    }
}
