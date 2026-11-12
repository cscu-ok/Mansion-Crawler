using System.Collections;
using UnityEngine;

public class Room_Transition : MonoBehaviour
{
    public Camera camera;
    public float targetX;
    public float panSpeed = 5f;

    private static bool isTransitioning = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTransitioning)
        {
            isTransitioning = true;
            StartCoroutine(RoomTransition());
        }
    }

    private IEnumerator RoomTransition()
    {
        Vector3 cameraStartPosition = camera.transform.position;
        Vector3 cameraTargetPosition = new Vector3(targetX, cameraStartPosition.y, cameraStartPosition.z);

        float elapsed = 0f;
        float duration = Mathf.Abs(targetX - cameraStartPosition.x) / panSpeed;

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            camera.transform.position = Vector3.Lerp(cameraStartPosition, cameraTargetPosition, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        camera.transform.position = cameraTargetPosition;
        isTransitioning = false;
    }
}