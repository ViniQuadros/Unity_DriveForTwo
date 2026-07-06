using System.Collections;
using TMPro;
using UnityEngine;

public class ShowMessage : MonoBehaviour
{
    public string messageText;
    public float displayDuration = 2f;
    public ParticleSystem effect;
    public TextMeshProUGUI message;

    void Start()
    {
        message.text = messageText;
        message.gameObject.SetActive(false);
    }

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
                StartCoroutine(Show());
                Destroy(box.gameObject);
            }
        }
    }

    private IEnumerator Show()
    {
        message.gameObject.SetActive(true);
        yield return new WaitForSeconds(displayDuration);
        message.gameObject.SetActive(false);
    }
}
