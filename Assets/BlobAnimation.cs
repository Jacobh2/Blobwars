using UnityEngine;

public class BlobAnimation : MonoBehaviour
{
    public BlobMovement blobMovement;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetInteger("dx", blobMovement.dx);
    }
}
