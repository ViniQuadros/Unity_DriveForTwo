using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUI : MonoBehaviour
{
    [Header("For Host")]
    public Button hostButton;
    public Button playButton;
    public TextMeshProUGUI joinCodeText;

    [Header("For Client")]
    public GameObject clientPanel;
    public TMP_InputField joinCodeInput;

    [Header("For Both")]
    public GameObject mainPanel;

    private void Start()
    {
        playButton.gameObject.SetActive(false);
        clientPanel.gameObject.SetActive(false);
    }

    public async void OnHostButtonPressed()
    {
        mainPanel.SetActive(false);
        playButton.gameObject.SetActive(true);

        try
        {
            string joinCode = await RelayManager.Instance.CreateLobby();
            joinCodeText.text = "Code: " + joinCode;
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Failed to create lobby: {e.Message}");
            joinCodeText.text = "Failed to create lobby";
        }
        finally
        {
            hostButton.interactable = true;
        }
    }

    public async void OnJoinButtonPressed()
    {
        mainPanel.SetActive(false);
        clientPanel.SetActive(true);
    }

    public async void OnJoinCodeSubmit()
    {
        string joinCode = joinCodeInput.text;
        try
        {
            await RelayManager.Instance.JoinLobby(joinCode);
            clientPanel.SetActive(false);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Failed to join lobby: {e.Message}");
            joinCodeInput.text = "Failed to join lobby";
        }
    }
}