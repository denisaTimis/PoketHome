using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject background;
    Transform cameraTransform;
    Transform playerTransform;
    Transform backgroundTransform;
    Vector2 lastPos;
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = this.GetComponent<Transform>();
        playerTransform = player.GetComponent<Transform>();
        backgroundTransform = background.GetComponent<Transform>();
        lastPos.x = playerTransform.position.x;
        lastPos.y = playerTransform.position.y;
        lastPos = new Vector2(playerTransform.position.x, playerTransform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.x != lastPos.x || playerTransform.position.y != lastPos.y)
        {
            cameraTransform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, cameraTransform.position.z);
            backgroundTransform.position = new Vector3(cameraTransform.position.x, cameraTransform.position.y, backgroundTransform.position.z);
            lastPos = new Vector2(playerTransform.position.x, playerTransform.position.y);
        }
    }
}
