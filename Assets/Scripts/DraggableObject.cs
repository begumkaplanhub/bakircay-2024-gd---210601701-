using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    private Camera mainCamera;
    private bool isDragging = false;
    private Platform targetPlatform;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void OnMouseDown()
    {
        isDragging = true;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = mainCamera.WorldToScreenPoint(transform.position).z;
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
            transform.position = new Vector3(worldPosition.x, transform.position.y, worldPosition.z);
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
        GetComponent<Rigidbody>().isKinematic = false;

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0.5f);
        foreach (var hit in hitColliders)
        {
            targetPlatform = hit.GetComponent<Platform>();
            if (targetPlatform != null)
            {
                targetPlatform.PlaceObject(gameObject, Vector3.up * 1.0f);
                PlatformManager platformManager = FindObjectOfType<PlatformManager>();
                platformManager.CheckMatch();
                return;
            }
        }
    }
}
