using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    private bool inputEnabled = true;
    public bool InputEnabled
    {
        get
        {
            return inputEnabled;
        }
        set
        {
            inputEnabled = value;
            playerInput.enabled = inputEnabled;
        }
    }

    private void Start()
    {
        InputEnabled = GameplayManager.Instance.inputEnabled;
    }
}
