using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{

    public float endX;


    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(( -2.5f - ((transform.position.x - endX) / endX) * 5), 2.1f,15.0f);
    }
}
