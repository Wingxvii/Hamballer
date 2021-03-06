﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    public Vector2 controllerDir;
    public Vector2 mouseDir;
    public GameObject arrow;
    public SpriteRenderer selfRenderer;
    public Rigidbody2D selfRigid;
    public float offsetGrapple;

    public Transform hamster;
    public float retractTime;
    public bool inFlight;
    public float arrowOffset;
    public float ShootingForce;
    public float ropeLength;

    public LineRenderer line;

    public int playerNumber = 1;


    // Start is called before the first frame update
    void Start()
    {
        controllerDir = new Vector2(0, 0);
        arrow.SetActive(false);
        selfRenderer = this.GetComponent<SpriteRenderer>();
        selfRigid = this.GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        if ((transform.position - hamster.position).magnitude > ropeLength && inFlight)
        {
            Retract();
        }
        if (Input.GetMouseButtonUp(0) && !inFlight)
        {
            ShootMouse();
        }



        if (playerNumber == 1)
        {
            if (Input.GetButtonDown("Fire1") && !inFlight && !(controllerDir.x == 0 && controllerDir.y == 0))
            {
                Shoot();
            }
            else if (Input.GetButtonDown("Fire1") && inFlight)
            {
                Retract();
            }
        }
        else {


            if (Input.GetButtonDown("Fire2") && !inFlight && !(controllerDir.x == 0 && controllerDir.y == 0))
            {
                Shoot();
            }
            else if (Input.GetButtonDown("Fire2") && inFlight)
            {
                Retract();
            }
        }

        if (Input.GetMouseButton(0))
        {
            mouseDir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
            mouseDir.Normalize();
        }

        //calculate line and physics
        if (inFlight)
        {
            line.SetPosition(0, new Vector3(transform.position.x, transform.position.y));
            line.SetPosition(1, new Vector3(hamster.position.x, hamster.position.y));

        }
        else
        {
            line.SetPosition(0, new Vector3(0, 0, 0));
            line.SetPosition(1, new Vector3(0, 0, 0));
            transform.position = hamster.position + (hamster.up * offsetGrapple);
            transform.rotation = hamster.rotation;
        }

    }

    private void FixedUpdate()
    {

        if (playerNumber == 1)
        {

            controllerDir = new Vector2(Input.GetAxis("Horizontal"), -Input.GetAxis("Vertical"));
            controllerDir.Normalize();
            if (!inFlight && !(controllerDir.x == 0 && controllerDir.y == 0))
            {
                arrow.SetActive(true);
                arrow.transform.position = new Vector3(this.transform.position.x + (controllerDir.x * arrowOffset), this.transform.position.y + (controllerDir.y * arrowOffset), 0);
                arrow.transform.up = controllerDir;
            }
            else
            {
                arrow.SetActive(false);
            }
        }
        else
        {
            controllerDir = new Vector2(Input.GetAxis("Horizontal2"), -Input.GetAxis("Vertical2"));
            controllerDir.Normalize();
            if (!inFlight && !(controllerDir.x == 0 && controllerDir.y == 0))
            {
                arrow.SetActive(true);
                arrow.transform.position = new Vector3(this.transform.position.x + (controllerDir.x * arrowOffset), this.transform.position.y + (controllerDir.y * arrowOffset), 0);
                arrow.transform.up = controllerDir;
            }
            else
            {
                arrow.SetActive(false);
            }
        }

    }

    public void Shoot() {
        inFlight = true;
        this.selfRigid.velocity = (ShootingForce * controllerDir) + hamster.gameObject.GetComponent<Rigidbody2D>().velocity;
        GetComponent<AudioSource>().Play();
    }

    void ShootMouse()
    {
        inFlight = true;
        this.selfRigid.velocity = (ShootingForce * mouseDir) + hamster.gameObject.GetComponent<Rigidbody2D>().velocity;

    }

    public void Retract() {
        selfRigid.velocity = new Vector2(0, 0);
        inFlight = false;
        StartCoroutine("RetractLerp");
    }

    IEnumerator RetractLerp()
    {
        float elapsedTime = 0;

        while (elapsedTime < retractTime)
        {
            transform.localPosition = Vector2.Lerp(transform.localPosition, hamster.position + (hamster.up * offsetGrapple), (elapsedTime / retractTime));
            transform.localRotation = Quaternion.Lerp(transform.localRotation, hamster.rotation, (elapsedTime / retractTime));
            elapsedTime += Time.deltaTime;

            // Yield here
            yield return null;
        }
        // Make sure we got there
        transform.localPosition = hamster.position + (hamster.up * offsetGrapple);
        transform.localRotation = hamster.rotation;
        yield return null;

    }

}
