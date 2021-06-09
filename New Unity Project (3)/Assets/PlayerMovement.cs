using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Transform PlayerPos;
    public Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPos = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMov = Input.GetAxis("X");
        float yMov = Input.GetAxis("Y");
        velocity = new Vector2(xMov, yMov);
        velocity *= speed;
        PlayerPos.position += new Vector3(velocity.x, velocity.y, 0f);
    }
}
