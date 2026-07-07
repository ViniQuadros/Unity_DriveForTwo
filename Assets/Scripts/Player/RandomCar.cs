using UnityEngine;

public class RandomCar : MonoBehaviour
{
    public GameObject playerCar;
    [SerializeField] private GameObject[] cars;

    void Start()
    {
        int randomIndex = Random.Range(0, cars.Length);
        GameObject selectedCar = cars[randomIndex];
        Instantiate(selectedCar, playerCar.transform.position, playerCar.transform.rotation, transform);
        Destroy(playerCar);
    }
}
