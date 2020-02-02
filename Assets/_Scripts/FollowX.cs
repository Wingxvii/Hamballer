using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowX : MonoBehaviour
{

    public Transform target;
    public float highFollow;

    float defualtY;

    private void Start()
    {
        defualtY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float yValue = defualtY;
        if (target.position.y > highFollow) {
            yValue = defualtY + (target.position.y - highFollow);
        }

        transform.position = new Vector3(target.position.x, yValue, -100);

    }
}
