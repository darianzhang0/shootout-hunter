using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Outlaw : MonoBehaviour
{
    // original scale is 1.6, 1.6, 1

    public float deadTimer = 0.05f; // how long after shot it disappears
    public static float spawnTimer = 1.25f; // how long it spawns for *added static
    public int outlawPoints = 3;

    void Start()
    {
        Destroy(gameObject, spawnTimer);
    }

    // added 2d polygon collider to work with OnMouseDown
    void OnMouseDown()
    {
        FindObjectOfType<AudioManager>().Play("Hit");
        Points.points += outlawPoints;

        Destroy(gameObject, deadTimer);
        StartCoroutine(DestroyOutlaw());

        //transform.localScale += new Vector3(-0.2f, -0.2f, 0);
        //transform.localScale += new Vector3(-0.3f, -0.3f, 0);
    }

    IEnumerator DestroyOutlaw()
    {
        transform.localScale += new Vector3(-0.25f, -0.25f, 0);
        yield return new WaitForSeconds(0.02f);
        transform.localScale += new Vector3(-0.25f, -0.25f, 0);
        yield return new WaitForSeconds(0.02f);
        transform.localScale += new Vector3(-0.25f, -0.25f, 0);
    }

    /*
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer < 0)
        {
            Destroy(gameObject);
        }

        if (Input.GetMouseButtonDown(0)) // broken
        {
            Points.points += outlawPoints;

            Destroy(gameObject, deadTimer);

            transform.localScale += new Vector3(-0.2f, -0.2f, 0);
            transform.localScale += new Vector3(-0.3f, -0.3f, 0);

        }
    }

    void OutlawDestroyed()
    {
        for (int i = 0; i < Spawner.assets.Length; i++)
        {
            if (Spawner.assets[i].name == "Outlaw")
            {
                Spawner.positions[i] = false;
                return;
            }
        }
    }
    */

}
