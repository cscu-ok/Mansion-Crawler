using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3.5f;
    private Vector2 inputMovement;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        inputMovement.x = Input.GetAxisRaw("Horizontal");
        inputMovement.y = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = (Vector3.right * inputMovement.x + Vector3.forward * inputMovement.y).normalized;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        if (inputMovement.x > 0) transform.eulerAngles = new Vector3(0, 270, 0);
        else if (inputMovement.x < 0) transform.eulerAngles = new Vector3(0, 90, 0);
        else if (inputMovement.y > 0) transform.eulerAngles = new Vector3(0, 180, 0);
        else if (inputMovement.y < 0) transform.eulerAngles = new Vector3(0, 0, 0);

        bool isWalking = inputMovement.x != 0 || inputMovement.y != 0;
        animator.SetBool("isWalking", isWalking);
    }
}
