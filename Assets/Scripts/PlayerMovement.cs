using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3.5f;
    private Rigidbody rb;
    private Vector2 inputMovement;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        inputMovement.x = Input.GetAxisRaw("Horizontal");
        inputMovement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Vector3 targetVelocity = (transform.right * inputMovement.x + transform.forward * inputMovement.y).normalized * moveSpeed;
        targetVelocity.y = rb.linearVelocity.y;
        rb.linearVelocity = targetVelocity;
    }
}
