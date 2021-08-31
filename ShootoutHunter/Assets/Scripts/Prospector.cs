using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prospector : MonoBehaviour
{
    // original scale is 1, 1, 1

    public float deadTimer = 0.05f; // how long after shot it disappears
    public static float spawnTimer = 2.5f; // how long it spawns for
    public int ProspectorPoints = 1;


    void Start()
    {
        Destroy(gameObject, spawnTimer);
    }

    // added 2d polygon collider to work with OnMouseDown
    void OnMouseDown()
    {
        FindObjectOfType<AudioManager>().Play("Hit");
        Points.points += ProspectorPoints;

        Destroy(gameObject, deadTimer);
        StartCoroutine(DestroyProspector());
    }

    IEnumerator DestroyProspector()
    {
        transform.localScale += new Vector3(-0.25f, -0.25f, 0);
        yield return new WaitForSeconds(0.02f);
        transform.localScale += new Vector3(-0.25f, -0.25f, 0);
        yield return new WaitForSeconds(0.02f);
        transform.localScale += new Vector3(-0.25f, -0.25f, 0);
    }
}
