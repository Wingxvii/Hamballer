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

    public bool canMove;
    public int player = 1;

    public SmoothFollow2DCamera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        hamsterRigid = GetComponent<Rigidbody2D>();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == 1)
        {
            if (Input.GetButtonDown("Jump") && canJump && canMove)
            {
                //Jump
                hamsterRigid.velocity += new Vector2(hamsterBall.position.x - transform.position.x, hamsterBall.position.y - transform.position.y) * Jump;
                canJump = false;
            }
        }
        else {
            if (Input.GetButtonDown("Jump2") && canJump && canMove)
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
        if (Input.GetKey(KeyCode.W) && canMove) {
            //Move Forward
            hamsterRigid.velocity = new Vector2(hamsterRigid.velocity.x + Speed, hamsterRigid.velocity.y);
        }
        if (Input.GetKey(KeyCode.S) && canMove) {
            //Move Backward
            hamsterRigid.velocity = new Vector2(hamsterRigid.velocity.x - Speed, hamsterRigid.velocity.y);
        }

        if (player == 1)
        {
            //movement using controller
            float movement = Input.GetAxis("Movement") * Speed;
            if (movement != 0.0f && canMove)
            {
                hamsterRigid.velocity = new Vector2(hamsterRigid.velocity.x + movement, hamsterRigid.velocity.y);

            }
        }
        else {
            //movement using controller
            float movement = Input.GetAxis("Movement2") * Speed;
            if (movement != 0.0f && canMove)
            {
                hamsterRigid.velocity = new Vector2(hamsterRigid.velocity.x + movement, hamsterRigid.velocity.y);

            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball") {
            Debug.Log("End");
            StartCoroutine("EndGame");
        }
    }


    IEnumerator EndGame()
    {
        float elapsedTime = 0;
        canMove = false;
        mainCamera.target = this.transform;
        //DEAD SPRITE HERE

        while (elapsedTime < 3.0f)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        GameController.Instance.EndGameLoss();
        yield return null;

    }



}
