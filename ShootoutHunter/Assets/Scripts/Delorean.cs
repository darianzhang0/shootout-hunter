using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Delorean : MonoBehaviour
{
    // original scale is 3.5, 2.75, 1

    public float deadTimer = 0.05f;
    public int deloreanPoints = -5;

    public float speed = 22.0f;

    void Update()
    {
        transform.position += -transform.right * speed * Time.deltaTime;

        if (transform.position.x < -27.0f)
        {
            Destroy(gameObject);
        }
    }

    // added 2d polygon collider to work with OnMouseDown
    void OnMouseDown()
    {
        FindObjectOfType<AudioManager>().Play("Hit");
        Points.points += deloreanPoints;

        Destroy(gameObject, deadTimer);
        StartCoroutine(DestroyDelorean());
    }

    IEnumerator DestroyDelorean()
    {
        transform.localScale += new Vector3(-0.25f, -0.25f, 0);
        yield return new WaitForSeconds(0.02f);
        transform.localScale += new Vector3(-0.25f, -0.25f, 0);
        yield return new WaitForSeconds(0.02f);
        transform.localScale += new Vector3(-0.25f, -0.25f, 0);
    }
}
