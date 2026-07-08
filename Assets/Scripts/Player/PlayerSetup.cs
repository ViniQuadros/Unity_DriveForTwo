using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSetup : NetworkBehaviour
{
    private PlayerInput playerInput;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    public override void OnNetworkSpawn()
    {
        if (!IsOwner)
        {
            playerInput.enabled = false;
            return;
        }

        playerInput.enabled = true;
    }
}
