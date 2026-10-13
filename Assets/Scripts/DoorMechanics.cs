using UnityEngine;
using System.Collections;

public class DoorMechanics : MonoBehaviour
{
    public static DoorMechanics instance;
    public GameObject doorDialogue;

    private void Awake()
    {
        instance = this;
        doorDialogue.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            doorDialogue.SetActive(true);
            Invoke(nameof(setDoorDialogueFalse), 3f);

        }
    }

    public void setDoorDialogueFalse()
    {
        doorDialogue.SetActive(false);
    }
}
