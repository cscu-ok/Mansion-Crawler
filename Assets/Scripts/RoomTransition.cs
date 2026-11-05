using System.Collections;
using UnityEngine;

public class Room_Transition : MonoBehaviour
{
    public Camera camera;
    public float targetX = -14.8f;
    public float panSpeed = 5f;
    public Transform player;
    public float playerTarget = -11f;
    public bool isTransitionImmediate = true;
    public float transitionDelay = 5f;
    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(RoomTransition());
        }
    }

    private IEnumerator RoomTransition()
    {
        if (!isTransitionImmediate)
        {
            yield return new WaitForSeconds(transitionDelay);
        }

        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        playerMovement.enabled = false;

        Vector3 cameraStartPosition = camera.transform.position;
        Vector3 cameraTargetPosition = new Vector3(targetX, cameraStartPosition.y, cameraStartPosition.z);
        Vector3 playerStartPosition = player.position;
        Vector3 playerTargetPosition = new Vector3(playerTarget, playerStartPosition.y, playerStartPosition.z);

        float elapsed = 0f;
        float duration = Mathf.Abs(targetX - cameraStartPosition.x) / panSpeed;

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            camera.transform.position = Vector3.Lerp(cameraStartPosition, cameraTargetPosition, t);
            player.position = Vector3.Lerp(playerStartPosition, playerTargetPosition, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        camera.transform.position = cameraTargetPosition;
        player.position = playerTargetPosition;
        playerMovement.enabled = true;
    }
}
