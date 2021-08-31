using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boy : MonoBehaviour
{
    // original scale is 2, 2, 1

    public float deadTimer = 0.05f; // how long after shot it disappears
    public static float spawnTimer = 2f; // how long it spawns for
    public int boyPoints = -2;


    void Start()
    {
        Destroy(gameObject, spawnTimer);
    }

    // added 2d polygon collider to work with OnMouseDown
    void OnMouseDown()
    {
        FindObjectOfType<AudioManager>().Play("Hit");
        Points.points += boyPoints;

        Destroy(gameObject, deadTimer);
        StartCoroutine(DestroyBoy());
    }

    IEnumerator DestroyBoy()
    {
        transform.localScale += new Vector3(-0.25f, -0.25f, 0);
        yield return new WaitForSeconds(0.02f);
        transform.localScale += new Vector3(-0.25f, -0.25f, 0);
        yield return new WaitForSeconds(0.02f);
        transform.localScale += new Vector3(-0.25f, -0.25f, 0);
    }
}
