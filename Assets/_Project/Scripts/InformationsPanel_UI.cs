using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InformationsPanel_UI : MonoBehaviour
{
    [SerializeField] private GameObject informationsPanel;

    private void Update()
    {
        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            informationsPanel.SetActive(!informationsPanel.activeSelf);
        }

        if(Keyboard.current.rKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
