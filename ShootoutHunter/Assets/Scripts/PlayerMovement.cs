using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float zPos = 20f;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        //transform.position = Input.mousePosition;

        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, zPos);

        //Debug.Log(transform.position);

        if (Input.GetMouseButtonDown(0))
        {
            FindObjectOfType<AudioManager>().Play("Gunshot");
        }

    }
}
