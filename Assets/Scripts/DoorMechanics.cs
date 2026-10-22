using UnityEngine;

public class DoorMechanics : MonoBehaviour
{
    public static DoorMechanics instance;
    public GameObject doorDialogue;
    private Animator animator;

    private void Awake()
    {
        instance = this;
        doorDialogue.SetActive(false);
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (KeyPickup.hasKey)
            {
                animator.SetBool("isOpen", true);
            }
            else
            {
                doorDialogue.SetActive(true);
                Invoke(nameof(setDoorDialogueFalse), 3f);
            }
        }
    }

    public void setDoorDialogueFalse()
    {
        doorDialogue.SetActive(false);
    }
}
