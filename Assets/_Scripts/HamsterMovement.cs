using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterMovement : MonoBehaviour
{

    public float Speed;
    public float Jump;
    public Rigidbody2D hamsterRigid;
    public Transform hamsterBall;
    public bool outOfBall;
    public bool canJump;

    public int player = 1;

    // Start is called before the first frame update
    void Start()
    {
        hamsterRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == 1)
        {
            if (Input.GetButtonDown("Jump") && canJump)
            {
                //Jump
                hamsterRigid.velocity += new Vector2(hamsterBall.position.x - transform.position.x, hamsterBall.position.y - transform.position.y) * Jump;
                canJump = false;
            }
        }
        else {
            if (Input.GetButtonDown("Jump2") && canJump)
            {
                //Jump
                hamsterRigid.velocity += new Vector2(hamsterBall.position.x - transform.position.x, hamsterBall.position.y - transform.position.y) * Jump;
                canJump = false;
            }

        }
        if (!outOfBall) {
            transform.up = new Vector3(hamsterBall.position.x - transform.position.x, hamsterBall.position.y - transform.position.y, 0);
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

        if (player == 1)
        {
            //movement using controller
            float movement = Input.GetAxis("Movement") * Speed;
            if (movement != 0.0f)
            {
                hamsterRigid.velocity = new Vector2(hamsterRigid.velocity.x + movement, hamsterRigid.velocity.y);

            }
        }
        else {
            //movement using controller
            float movement = Input.GetAxis("Movement2") * Speed;
            if (movement != 0.0f)
            {
                hamsterRigid.velocity = new Vector2(hamsterRigid.velocity.x + movement, hamsterRigid.velocity.y);

            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball") {
            Debug.Log("End");
            GameController.Instance.EndGameLoss();
        }
    }

}
