using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class badCow : MonoBehaviour
{
    // original scale is 2.4, 2.4, 1

    public float deadTimer = 0.05f;
    public int badCowPoints = 4;

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
        Points.points += badCowPoints;

        Destroy(gameObject, deadTimer);
        StartCoroutine(DestroyBadCow());
    }

    IEnumerator DestroyBadCow()
    {
        transform.localScale += new Vector3(-0.25f, -0.25f, 0);
        yield return new WaitForSeconds(0.02f);
        transform.localScale += new Vector3(-0.25f, -0.25f, 0);
        yield return new WaitForSeconds(0.02f);
        transform.localScale += new Vector3(-0.25f, -0.25f, 0);
    }
}
