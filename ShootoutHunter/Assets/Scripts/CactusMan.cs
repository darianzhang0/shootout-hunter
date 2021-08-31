using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CactusMan : MonoBehaviour
{
    // original scale is 1.1, 1.1, 1

    public float deadTimer = 0.05f; // how long after shot it disappears
    public static float spawnTimer = 3f; // how long it spawns for
    public int cactusManPoints = 1;


    void Start()
    {
        Destroy(gameObject, spawnTimer);
    }

    // added 2d polygon collider to work with OnMouseDown
    void OnMouseDown()
    {
        FindObjectOfType<AudioManager>().Play("Hit");
        Points.points += cactusManPoints;

        Destroy(gameObject, deadTimer);
        StartCoroutine(DestroyCactusMan());
    }

    IEnumerator DestroyCactusMan()
    {
        transform.localScale += new Vector3(-0.25f, -0.25f, 0);
        yield return new WaitForSeconds(0.02f);
        transform.localScale += new Vector3(-0.25f, -0.25f, 0);
        yield return new WaitForSeconds(0.02f);
        transform.localScale += new Vector3(-0.25f, -0.25f, 0);
    }
}
