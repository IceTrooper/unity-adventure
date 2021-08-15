using UnityEngine;
using UnityEngine.InputSystem;

public class PlayersJoiner : MonoBehaviour
{
    [SerializeField] private PlayerInputManager playerInputManager;

    private void Update()
    {
        if(Keyboard.current.nKey.wasPressedThisFrame && GameplayManager.Instance.InputEnabled)
        {
            playerInputManager.JoinPlayer(1, 1, "Keyboard-2", Keyboard.current);
        }
    }
}
