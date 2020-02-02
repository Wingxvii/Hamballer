using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{

    public float endX;


    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(( -2 - ((transform.position.x - endX) / endX) * 4), 2.1f,15.0f);
    }
}
