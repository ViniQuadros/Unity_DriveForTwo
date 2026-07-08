using UnityEngine;

public class TargetDelivered : MonoBehaviour
{
    public BoxManager boxManager;
    public ShowMessage showMessage;
    public ParticleSystem effect;
    [SerializeField] private Transform[] spawnPoints;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Transform boxPosition = other.gameObject.transform.Find("BoxPosition");

            if (boxPosition == null || boxPosition.childCount == 0)
                return;

            GameObject boxObj = boxPosition.GetChild(0).gameObject;
            CollectBox box = boxObj.GetComponentInChildren<CollectBox>();

            if (box != null)
            {
                Instantiate(effect, transform.position, Quaternion.identity);
                showMessage.SetMessage("Package Delivered!");
                showMessage.DisplayMessage();
                ChangeLocation();
                boxManager.SpawnBox();
                Destroy(box.gameObject);
            }
        }
    }

    public void ChangeLocation()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];
        transform.position = spawnPoint.position;
    }
}
