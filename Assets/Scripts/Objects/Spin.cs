using UnityEngine;

public class Spin : MonoBehaviour
{
    public float spinSpeed = 100f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }
}
