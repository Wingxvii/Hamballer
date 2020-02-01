using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallWallBreakage : MonoBehaviour
{
    public bool broken;
    public BoxCollider2D ballCollider;
    public Vector2 innitialLocation;
    public Quaternion innitialRotation;
    public float repairTime;
    public float collisionBreakThreshold;
    //impact force multiplier
    public float impactForce;
    public float impactTorque;


    [Header("Debuging Buttons")]
    public bool breakThis;
    public bool repairThis;


    // Start is called before the first frame update
    void Start()
    {
        ballCollider = GetComponent<BoxCollider2D>();
        innitialLocation = this.transform.localPosition;
        innitialRotation = this.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (breakThis == true)
        {
            Break();
            breakThis = false;
        }
        if (repairThis == true)
        {
            Repair();
            repairThis = false;
        }

    }

    //breaks the wall piece
    public void Break()
    {
        if (!broken)
        {
            this.gameObject.AddComponent(typeof(Rigidbody2D));
            //this.GetComponent<BoxCollider2D>().isTrigger = true;

            this.GetComponent<Rigidbody2D>().AddForce(-(this.transform.localPosition * impactForce));
            this.GetComponent<Rigidbody2D>().AddTorque(impactTorque);

            broken = true;
        }
        else
        {
            Debug.LogWarning("Already Broken!");
        }
    }

    public void Repair()
    {
        if (broken)
        {
            Destroy(gameObject.GetComponent<Rigidbody2D>());
            StartCoroutine(RepairLerp());
            broken = false;
        }
        else
        {
            Debug.LogWarning("Already Repaired!");
        }

    }


    IEnumerator RepairLerp()
    {
        float elapsedTime = 0;

        while (elapsedTime < repairTime)
        {
            transform.localPosition = Vector2.Lerp(transform.localPosition, innitialLocation, (elapsedTime / repairTime));
            transform.localRotation = Quaternion.Lerp(transform.localRotation, innitialRotation, (elapsedTime / repairTime));
            elapsedTime += Time.deltaTime;

            // Yield here
            yield return null;
        }
        // Make sure we got there
        transform.localPosition = innitialLocation;
        transform.localRotation = innitialRotation;

        yield return null;

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hazard" && !broken) {

            Destroy(collision.gameObject);
            this.Break();
        }

        if (collision.gameObject.tag == "Ground" && !broken) {
            if (collision.relativeVelocity.y > collisionBreakThreshold) {
                this.Break();
            }
        }

        if (collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<HamsterMovement>().canJump = true;
        }
    }
}
