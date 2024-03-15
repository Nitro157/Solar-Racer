using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPress : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Solar Racer").GetComponent<PlayerController>().gameState == false)
        {

            GameObject.Find("ButtonReset").transform.position = new Vector3(1300.0f, 670.0f, 0.0f);
            GameObject.Find("ButtonMain").transform.position = new Vector3(1300.0f, 530.0f, 0.0f);
            GameObject.Find("LoseText").transform.position = new Vector3(1300.0f, 810.0f, 0.0f);
        }


    }

    public void OnPress()
    {
        SceneManager.LoadScene("BaseGame");
    }

    public void OnPress2()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
