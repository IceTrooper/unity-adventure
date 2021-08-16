using UnityEngine;
using UnityEngine.InputSystem;

public class InformationsPanel_UI : MonoBehaviour
{
    [SerializeField] private GameObject informationsPanel;

    private void Update()
    {
        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            informationsPanel.SetActive(!informationsPanel.activeSelf);
        }
    }
}
