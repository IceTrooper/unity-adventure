using Cinemachine;
using UnityEngine;

public class CameraInitializer : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject virtualPlayerCam;

    private void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        int layer = players.Length + 9;

        virtualPlayerCam.layer = layer;
        var bitMask = (1 << layer)
            | (1 << 0)
            | (1 << 1)
            | (1 << 2)
            | (1 << 4)
            | (1 << 5)
            | (1 << 8);

        cam.cullingMask = bitMask;
        cam.gameObject.layer = layer;

        if(players.Length == 2)
        {
            cam.rect = new Rect(0.5f, 0f, 1f, 1f);
        }
    }
}
