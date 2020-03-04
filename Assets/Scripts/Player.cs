using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform tf;

    public float rotationSpeed = 1.0f;

    public float movementSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        tf = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            tf.position += tf.right * movementSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            tf.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            tf.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }
    }

}
