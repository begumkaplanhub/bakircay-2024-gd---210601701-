using UnityEngine;
using System.Collections;

public class PlatformManager : MonoBehaviour
{
    public Platform platformA;
    public Platform platformB;
    public ScoreManager scoreManager;

    public void CheckMatch()
    {
        if (platformA.currentObject != null && platformB.currentObject != null)
        {
            GameObject objectA = platformA.currentObject;
            GameObject objectB = platformB.currentObject;

            if (objectA.tag == objectB.tag)
            {
                Destroy(objectA);
                Destroy(objectB);
                platformA.ClearObject();
                platformB.ClearObject();
                scoreManager.AddScore(10);
            }
            else
            {
                StartCoroutine(ResetObjects());
            }
        }
    }

    private IEnumerator ResetObjects()
    {
        yield return new WaitForSeconds(2f);
        platformA.PushObjectAway();
        platformB.PushObjectAway();
        platformA.ClearObject();
        platformB.ClearObject();
    }
}
