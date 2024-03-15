using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningScript : MonoBehaviour
{
    [SerializeField] GameObject hazard;
    [SerializeField] GameObject projectile;

    public int Hazard_Num;
    [SerializeField] public GameObject[] Hazard_Select;

    // Start is called before the first frame update
    void Start()
    {
        Hazard_Num = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 1000) < 2)
        {
            SpawnHazard();
        }

        if (Random.Range(0, 1000) < 3)
        {
            SpawnProjectile();
        }

    }

    private void SpawnHazard()
    {
        if (GameObject.Find("Solar Racer").GetComponent<PlayerController>().gameState == true)
        {
            GameObject newhazard = Instantiate(Hazard_Select[Hazard_Num], new Vector3(9.5f, Random.Range(4, -6), 0), Quaternion.identity);
            newhazard.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100, 0));

            Hazard_Num = Hazard_Num + 1;
            if (Hazard_Num == Hazard_Select.Length)
            {
                Hazard_Num = 0;
            }
        }

    }

    private void SpawnProjectile()
    {
        if (GameObject.Find("Solar Racer").GetComponent<PlayerController>().gameState == true)
        {
            GameObject newprojectile = Instantiate(projectile, new Vector3(9.5f, Random.Range(4, -6), 0), Quaternion.identity);
            newprojectile.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100, 0));
        }

    }
}
