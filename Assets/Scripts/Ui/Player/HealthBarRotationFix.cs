using UnityEngine;

public class HealthBarRotationFix : MonoBehaviour
{
    void Update()
    {
        transform.localScale = transform.root.transform.localScale.x == -1 ? new Vector3(-1,1,1) : new Vector3(1,1,1);
    }
}
