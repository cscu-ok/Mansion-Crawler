using System.Collections;
using UnityEngine;

public class Room_Transition : MonoBehaviour
{
    public Camera camera;
    public float targetX1;
    public float targetX2;
    public float panSpeed = 10f;

    private int triggerCount = 0;
    private Coroutine currentTransition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            float targetX = triggerCount % 2 == 0 ? targetX2 : targetX1;
            triggerCount++;
            if (currentTransition != null)
                StopCoroutine(currentTransition);

            currentTransition = StartCoroutine(RoomTransition(targetX));
        }
    }

    private IEnumerator RoomTransition(float targetX)
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
        currentTransition = null;
    }
}