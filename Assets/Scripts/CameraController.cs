using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerPosition;
    public float displacementMultiplier = 0.15f;
    private float zPosition = -10;
    
    private void Update(){
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 cameraDisplacement = (mousePosition - playerPosition.position) * displacementMultiplier;

        Vector3 finalCameraPosition = playerPosition.position + cameraDisplacement;
        finalCameraPosition.z = zPosition;
        transform.position = finalCameraPosition;
    }
}
