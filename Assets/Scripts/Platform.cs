using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject currentObject;

    public void PlaceObject(GameObject obj, Vector3 offset)
    {
        currentObject = obj;
        AlignObject(obj, transform.position + offset);
    }

    public void ClearObject()
    {
        currentObject = null;
    }

    private void AlignObject(GameObject obj, Vector3 position)
    {
        obj.transform.position = position;
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }

    public void PushObjectAway()
    {
        if (currentObject != null)
        {
            Rigidbody rb = currentObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
                Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0.5f, Random.Range(-1f, 1f)).normalized;
                rb.AddForce(randomDirection * 5f, ForceMode.Impulse);
            }
        }
    }
}
