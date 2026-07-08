using System.Collections;
using TMPro;
using UnityEngine;

public class ShowMessage : MonoBehaviour
{
    public string messageText;
    public float displayDuration = 2f;
    public TextMeshProUGUI message;

    void Start()
    {
        message.text = messageText;
        message.gameObject.SetActive(false);
    }

    public void DisplayMessage()
    {
        StartCoroutine(Show());
    }

    public void SetMessage(string newMessage)
    {
        messageText = newMessage;
        message.text = messageText;
    }

    private IEnumerator Show()
    {
        message.gameObject.SetActive(true);
        yield return new WaitForSeconds(displayDuration);
        message.gameObject.SetActive(false);
    }
}
