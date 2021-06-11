using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed;
    public float sprintSpeed;
    
    public Camera Cam;

    private Rigidbody2D PlayerRB;
    private Vector2 movement;
    private float speed;
    private Vector2 mousePos;

    void Start()
    {
        PlayerRB = GetComponent<Rigidbody2D>(); 
        speed = walkSpeed;
    }

    void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = Cam.ScreenToWorldPoint(Input.mousePosition); 

        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            speed = sprintSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            speed = walkSpeed;
        }
    }

    void FixedUpdate()
    {
        PlayerRB.MovePosition(PlayerRB.position + movement.normalized * speed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - PlayerRB.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        PlayerRB.rotation = angle;
    }
}
