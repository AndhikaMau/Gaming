using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform cameraTransform;

    [Range(0f, 1f)]
    public float parallaxEffect = 0.5f;

    private Vector3 lastCameraPosition;

    void Start()
    {
        if (cameraTransform == null)
            cameraTransform = Camera.main.transform;

        lastCameraPosition = cameraTransform.position;
    }

    void LateUpdate()
    {
        Vector3 deltaMovement =
            cameraTransform.position - lastCameraPosition;

        transform.position +=
            new Vector3(deltaMovement.x * parallaxEffect, 0f, 0f);

        lastCameraPosition = cameraTransform.position;
    }
}