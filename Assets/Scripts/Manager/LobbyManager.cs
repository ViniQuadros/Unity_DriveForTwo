using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public class LobbyManager : NetworkBehaviour
{
    public Button playButton;

    public void BeginGame()
    {
        if (!IsServer) return;

        NetworkManager.Singleton.SceneManager.LoadScene("GameScene", UnityEngine.SceneManagement.LoadSceneMode.Single);
    }

    void Update()
    {
        playButton.interactable = NetworkManager.Singleton.IsServer && NetworkManager.Singleton.ConnectedClientsList.Count == 2; ;
    }
}
