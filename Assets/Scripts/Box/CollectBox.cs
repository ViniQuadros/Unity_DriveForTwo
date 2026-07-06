using UnityEngine;

public class CollectBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Transform target = other.transform.Find("BoxPosition");
            if (target)
            {
                transform.parent = target;
                transform.localPosition = Vector3.zero;
            }
        }
    }
}
