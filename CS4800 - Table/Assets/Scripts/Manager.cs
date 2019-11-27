using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [SerializeField]
    Camera[] cameras = new Camera[4];
    Camera Cameramain;
    int activeCamera;
    int i = 0;
    int rot = 0;
    [SerializeField]
    GameObject info;
    bool infoUp = true;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            i++;
            if (i > 4)
            {
                i = 0;
            }
            switch (i)
            {
                case 0:
                    Camera.main.transform.position = new Vector3(-1.8f, 9, 35.5f);
                    Camera.main.transform.rotation = Quaternion.Euler(0, 180, 0);
                    break;
                case 1:
                    Camera.main.transform.position = new Vector3(-51, 9, 1.5f);
                    Camera.main.transform.rotation = Quaternion.Euler(0, 90, 0);
                    break;
                case 2:
                    Camera.main.transform.position = new Vector3(55, 9, 1.5f);
                    Camera.main.transform.rotation = Quaternion.Euler(0, -90, 0);
                    break;
                case 3:
                    Camera.main.transform.position = new Vector3(0, 9, -50);
                    Camera.main.transform.rotation = Quaternion.Euler(0, 0, 0);
                    break;
                case 4:
                    Camera.main.transform.position = new Vector3(-2.5f, 215, -1.3f);
                    Camera.main.transform.rotation = Quaternion.Euler(90, 0, 0);
                    break;
            }


            //cameras[activeCamera].enabled = true;
            //ActivateCamera(activeCamera);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            if (infoUp)
            {
                info.SetActive(false);
                infoUp = false;
            }
            else
            {
                infoUp = true;
                info.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
