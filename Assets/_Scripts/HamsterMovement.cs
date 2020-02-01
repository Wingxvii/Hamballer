using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterMovement : MonoBehaviour
{

    public float Speed;
    public float Jump;
    public Rigidbody2D hamsterRigid;


    // Start is called before the first frame update
    void Start()
    {
        hamsterRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            //Jump
            hamsterRigid.velocity = new Vector2(hamsterRigid.velocity.x, hamsterRigid.velocity.y + Jump);

        }
    }

    // Fixed update
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W)) {
            //Move Forward
            hamsterRigid.velocity = new Vector2(hamsterRigid.velocity.x + Speed, hamsterRigid.velocity.y);


        }
        if (Input.GetKey(KeyCode.S)) {
            //Move Backward
            hamsterRigid.velocity = new Vector2(hamsterRigid.velocity.x - Speed, hamsterRigid.velocity.y);

        }
    }
}
