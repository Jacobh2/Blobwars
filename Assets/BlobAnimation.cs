using UnityEngine;

public class BlobAnimation : MonoBehaviour
{
    public BlobDirection blobDirection;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetInteger("dx", blobDirection.dx);
    }
}
