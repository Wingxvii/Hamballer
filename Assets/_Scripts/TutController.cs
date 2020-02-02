using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutController : MonoBehaviour
{


    public GameObject[] images;
    public int state = 0;
    public int sceneEnd;

    private void Start()
    {
        ResetAll();
        images[0].SetActive(true);

    }

    public void next() {
        state++;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && state < images.Length)
        {
            state++;
        }
        if (Input.GetButtonDown("Fire1") && state > 0 && !Input.GetMouseButton(0))
        {
            state--;
        }

        if (state == images.Length)
        {
            SceneManager.LoadScene(sceneEnd);
        }
        else
        {

            ResetAll();
            images[state].SetActive(true);
        }
    }


    void ResetAll()
    {
        foreach (GameObject image in images) {
            image.SetActive(false);
        }

    }


}
