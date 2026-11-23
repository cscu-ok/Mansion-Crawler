using UnityEngine;
using TMPro;

public class KeyPickup : MonoBehaviour
{
    public GameObject pickupPrompt;
    private bool playerInRange = false;
    public static bool hasKey = false;

    [Header("Key Animation Settings")]
    public float hoverHeight = 0.3f;
    public float hoverSpeed = 2f;
    public float rotateSpeed = 90f;

    private Vector3 startPosition;

    private void Awake()
    {
        hasKey = false;
        startPosition = transform.position;
    }

    private void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * hoverSpeed) * hoverHeight;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);

        transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);

        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            hasKey = true;
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
