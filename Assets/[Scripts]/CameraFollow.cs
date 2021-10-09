using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerPos;
    private Vector3 camOffset;
    private Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        camOffset = transform.position - playerPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = playerPos.position + camOffset;
        targetPos.x = 0.0f;
        transform.position = targetPos;
    }
}