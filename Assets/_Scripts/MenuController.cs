using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public int sceneA;
    public int sceneB;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump")) {
            SceneManager.LoadScene(sceneA);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene(sceneB);
        }

    }
}
