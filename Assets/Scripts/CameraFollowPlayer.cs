using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    private PlayerController playerControllerScript;
    public Transform player;
    public float cameraOffsetX;
    public float cameraOffsetY;
    public float cameraOffsetZ;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = player.gameObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!playerControllerScript.isGameOver)
        {
            transform.position = player.position + new Vector3(cameraOffsetX, cameraOffsetY, cameraOffsetZ);
        }
        
    }
}
