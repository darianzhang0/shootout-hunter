using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goodCow : MonoBehaviour
{
    // original scale is 1.6, 1.6, 1

    public float deadTimer = 0.05f;
    public int goodCowPoints = -1;

    public float speed = 13.0f;

    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;

        if (transform.position.x > 24.0f)
        {
            Destroy(gameObject);
        }
    }

    // added 2d polygon collider to work with OnMouseDown
    void OnMouseDown()
    {
        FindObjectOfType<AudioManager>().Play("Hit");
        Points.points += goodCowPoints;

        Destroy(gameObject, deadTimer);
        StartCoroutine(DestroyGoodCow());
    }

    IEnumerator DestroyGoodCow()
    {
        transform.localScale += new Vector3(-0.25f, -0.25f, 0);
        yield return new WaitForSeconds(0.02f);
        transform.localScale += new Vector3(-0.25f, -0.25f, 0);
        yield return new WaitForSeconds(0.02f);
        transform.localScale += new Vector3(-0.25f, -0.25f, 0);
    }
}
