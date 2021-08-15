using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    private static GameplayManager instance;
    public static GameplayManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<GameplayManager>();
            }
            return instance;
        }
    }

    public bool InputEnabled => inputEnabled;
    [SerializeField] private bool inputEnabled = false;

    public void EnableInput()
    {
        inputEnabled = true;

        var players = GameObject.FindGameObjectsWithTag("Player");
        foreach(var p in players)
        {
            p.GetComponent<Player>().InputEnabled = inputEnabled;
        }
    }
}
