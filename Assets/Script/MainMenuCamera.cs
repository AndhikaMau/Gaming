using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuCamera : MonoBehaviour
{
    public Transform focusPoint;
    public float zoomSize = 3f;
    public float zoomSpeed = 2f;
    public string nextSceneName = "Stage1";

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    public void StartGame()
    {
        StartCoroutine(ZoomToPlayer());
    }

    IEnumerator ZoomToPlayer()
    {
        Vector3 startPos = cam.transform.position;
        Vector3 targetPos = new Vector3(focusPoint.position.x, focusPoint.position.y, cam.transform.position.z);

        float startSize = cam.orthographicSize;
        float time = 0f;

        while (time < 1f)
        {
            time += Time.deltaTime * zoomSpeed;

            cam.transform.position = Vector3.Lerp(startPos, targetPos, time);
            cam.orthographicSize = Mathf.Lerp(startSize, zoomSize, time);

            yield return null;
        }

        SceneManager.LoadScene(nextSceneName);
    }
}