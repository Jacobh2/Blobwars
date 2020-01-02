using UnityEngine;

public class BlobMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D blob;
    public int dx;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x == 0)
        {
            dx = 0;
        }
        else
        {
            dx = (int)Mathf.Sign(movement.x);
        }
    }

    private void FixedUpdate()
    {
        blob.MovePosition(blob.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
