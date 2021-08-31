using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Robber : MonoBehaviour
{
    // original scale is 1.3, 1.3, 1

    public float deadTimer = 0.05f; // how long after shot it disappears
    public static float spawnTimer = 1.5f; // how long it spawns for
    public int robberPoints = 2;


    void Start()
    {
        Destroy(gameObject, spawnTimer);
    }

    // added 2d polygon collider to work with OnMouseDown
    void OnMouseDown()
    {
        FindObjectOfType<AudioManager>().Play("Hit");
        Points.points += robberPoints;

        Destroy(gameObject, deadTimer);
        StartCoroutine(DestroyRobber());
    }

    IEnumerator DestroyRobber()
    {
        transform.localScale += new Vector3(-0.25f, -0.25f, 0);
        yield return new WaitForSeconds(0.02f);
        transform.localScale += new Vector3(-0.25f, -0.25f, 0);
        yield return new WaitForSeconds(0.02f);
        transform.localScale += new Vector3(-0.25f, -0.25f, 0);
    }
}
