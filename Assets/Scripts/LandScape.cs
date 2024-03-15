using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandScape : MonoBehaviour
{
    [SerializeField] float size;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Landscape").GetComponent<Rigidbody2D>().AddForce(new Vector2(-100, 0));
        //GameObject.Find("Landscape_1").GetComponent<Rigidbody2D>().AddForce(new Vector2(-100, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Landscape").transform.position.x < -size)
        {
            GameObject.Find("Landscape").transform.position += new Vector3(size, 0, 0);
        }
    }
}
