using System.Collections;
using UnityEngine;

public class Room_Transition : MonoBehaviour
{
    public Camera camera;
    public GameObject nextRoomDoor;
    public float nextRoomDoorZ = 1.28f;
    public float doorSlideSpeed = 3f;
    public float doorSlideDelay = 0.5f;
    public float targetX = -14.8f;
    public float panSpeed = 5f;
    public Transform player;
    public float playerTarget = -11f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(RoomTransition());
        }
    }

    private IEnumerator RoomTransition()
    {
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        playerMovement.enabled = false;

        Vector3 cameraStartPosition = camera.transform.position;
        Vector3 cameraTargetPosition = new Vector3(targetX, cameraStartPosition.y, cameraStartPosition.z);
        Vector3 playerStartPosition = player.position;
        Vector3 playerTargetPosition = new Vector3(playerTarget, playerStartPosition.y, playerStartPosition.z);

        float elapsed = 0f;
        // distance to travel divided by speed gives us the duration of the transition
        float duration = Mathf.Abs(targetX - cameraStartPosition.x) / panSpeed;

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            // Lerp = linear interpolation between two values based on t (0 to 1) for smooth transition
            camera.transform.position = Vector3.Lerp(cameraStartPosition, cameraTargetPosition, t);
            player.position = Vector3.Lerp(playerStartPosition, playerTargetPosition, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        camera.transform.position = cameraTargetPosition;
        player.position = playerTargetPosition;
        playerMovement.enabled = true;

        yield return new WaitForSeconds(doorSlideDelay);
        StartCoroutine(SlideDoor());
    }

    private IEnumerator SlideDoor()
    {
        Animator doorAnimator = nextRoomDoor.GetComponent<Animator>();
        doorAnimator.SetBool("isClosed", true);

        yield return new WaitForSeconds(1f);
        doorAnimator.enabled = false;
    }
}