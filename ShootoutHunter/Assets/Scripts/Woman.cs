using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Woman : MonoBehaviour
{
    // original scale is 1.2, 1.5, 1

    public float deadTimer = 0.05f; // how long after shot it disappears
    public static float spawnTimer = 1.5f; // how long it spawns for
    public int womanPoints = -2;


    void Start()
    {
        Destroy(gameObject, spawnTimer);
    }

    // added 2d polygon collider to work with OnMouseDown
    void OnMouseDown()
    {
        FindObjectOfType<AudioManager>().Play("Hit");
        Points.points += womanPoints;

        Destroy(gameObject, deadTimer);
        StartCoroutine(DestroyWoman());
    }

    IEnumerator DestroyWoman()
    {
        transform.localScale += new Vector3(-0.25f, -0.25f, 0);
        yield return new WaitForSeconds(0.02f);
        transform.localScale += new Vector3(-0.25f, -0.25f, 0);
        yield return new WaitForSeconds(0.02f);
        transform.localScale += new Vector3(-0.25f, -0.25f, 0);
    }
}
