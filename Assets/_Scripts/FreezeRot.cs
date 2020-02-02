using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeRot : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(-transform.parent.rotation.eulerAngles + new Vector3(0,0,0));

    }
}
