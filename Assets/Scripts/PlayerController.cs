using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField] GameObject loseButton;
    public float speedforce = 0.01f;
    public int energy = 100;
    public int energyHolder = 0;
    public int score = 0;
    public int scoreHolder = 0;
    public bool gameState = true;
    public Text EnergyUI;
    public Text ScoreUI;
    public int Button = 0;

    public AudioSource audioSource;
    public AudioClip clip;
    public AudioClip clip2;
    public AudioClip clip3;
    public float volume = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        speedforce = 4f;
        energy = 100;
        energyHolder = 0;
        score = 0;
        scoreHolder = 0;
        gameState = true;
        GameObject.Find("Landscape").GetComponent<Rigidbody2D>().AddForce(new Vector2(-300, 0));
    }

    // Update is called once per frame
    void Update()
    {
        EnergyUI.text = $"Energy: {energy}";
        ScoreUI.text = $"Score: {score}";

        if (gameState == true)
        {

            scoreHolder = scoreHolder + 1;
            energyHolder = energyHolder + 1;

            if (scoreHolder > 20)
            {
                score = score + 1;
                scoreHolder = 0;
            }

            if (energyHolder > 100)
            {
                energy = energy - 1;
                energyHolder = 0;
                if (energy > 100)
                {
                    energy = 100;
                }
            }

            if (energy < 0)
            {
                gameState = false;
                audioSource.PlayOneShot(clip3, 0.1f);
            }
        }

        float posx = transform.position.x;
        float posy = transform.position.y;

        if (Input.GetKey(KeyCode.A))
            posx -= speedforce * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            posx += speedforce * Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
            posy += speedforce * Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
            posy -= speedforce * Time.deltaTime;

        transform.position = new Vector3(posx, posy, (transform.position.z));

        if (posy > 4)
        {
            posy = 3.9f;
            transform.position = new Vector3(posx, posy, (transform.position.z));
        }
        if (posy < -4)
        {
            posy = -3.9f;
            transform.position = new Vector3(posx, posy, (transform.position.z));
        }
        if (posx > 7)
        {
            posx = 6.9f;
            transform.position = new Vector3(posx, posy, (transform.position.z));
        }
        if (posx < -7)
        {
            posx = -6.9f;
            transform.position = new Vector3(posx, posy, (transform.position.z));
        }

        transform.position = new Vector3(posx, posy, (transform.position.z));

        if (gameState == false)
        {
            energy = 0;

            if (Button > 1)
            {
                Button = Button + 1;
                ButtonCreate();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            audioSource.PlayOneShot(clip, volume);
        }

        if (collision.gameObject.CompareTag("Hazard"))
        {
            audioSource.PlayOneShot(clip2, 0.1f);
        }
    }

    void ButtonCreate()
    {
        GameObject.Find("ButtonReset").transform.position = new Vector3(1.0f, 1.0f, 1.0f);
    }
}
