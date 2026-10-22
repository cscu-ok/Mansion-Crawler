using UnityEngine;
using TMPro;

public class KeyPickup : MonoBehaviour
{
    public GameObject pickupPrompt;
    private bool playerInRange = false;

    private void Update()
    {
        if(playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            pickupPrompt.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pickupPrompt.gameObject.SetActive(true);
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pickupPrompt.gameObject.SetActive(false);
            playerInRange = false;
        }
    }
}
