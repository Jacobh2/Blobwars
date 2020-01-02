using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D blob;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        blob.MovePosition(blob.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
