using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.7f;

    public int energy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Solar Racer").GetComponent<PlayerController>().gameState == false)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerCar"))
        {
            audioSource.PlayOneShot(clip, volume);
            Destroy(gameObject);
            GameObject.Find("Solar Racer").GetComponent<PlayerController>().energy = GameObject.Find("Solar Racer").GetComponent<PlayerController>().energy + 7;
        }

        if (collision.gameObject.CompareTag("ProjectileErase"))
        {
            Destroy(gameObject);
        }
    }
}


