using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterBallManager : MonoBehaviour
{
    #region SingletonCode
    private static HamsterBallManager _instance;
    public static HamsterBallManager Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    //single pattern ends here
    #endregion

    public BallWallBreakage[] wallSections;

    //ball transform
    public Transform ball;

    //broken transform
    public Transform brokenPool;

    public void BreakWall(int index, Vector2 impact) {
        if (!wallSections[index].broken) {
            //break it
            wallSections[index].transform.parent = brokenPool;

            Rigidbody2D tempBody = wallSections[index].gameObject.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;
            wallSections[index].GetComponent<BoxCollider2D>().isTrigger = false;

            tempBody.AddForce(impact);
        }
        else {
            Debug.LogWarning("Already Broken!");
        }
    }
}