using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutController : MonoBehaviour
{
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject image4;
    public GameObject image5;
    public GameObject image6;
    public GameObject image7;

    public int state = 0;

    private void Start()
    {
        ResetAll();
        image1.SetActive(true);

    }

    public void next() {
        state++;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            state++;
        }
        if (Input.GetButtonDown("Fire1") && state > 0 && !Input.GetMouseButton(0))
        {
            state--;
        }

        switch (state) {
            case 0:
                ResetAll();
                image1.SetActive(true);
                break;
            case 1:
                ResetAll();
                image2.SetActive(true);
                break;
            case 2:
                ResetAll();
                image3.SetActive(true);
                break;
            case 3:
                ResetAll();
                image4.SetActive(true);
                break;
            case 4:
                ResetAll();
                image5.SetActive(true);
                break;
            case 5:
                ResetAll();
                image6.SetActive(true);
                break;
            case 6:
                ResetAll();
                image7.SetActive(true);
                break;
            case 7:
                ResetAll();
                SceneManager.LoadScene(2);
                break;
        }
    }


    void ResetAll()
    {
        image1.SetActive(false);
        image2.SetActive(false);
        image3.SetActive(false);
        image4.SetActive(false);
        image5.SetActive(false);
        image6.SetActive(false);
        image7.SetActive(false);

    }


}
