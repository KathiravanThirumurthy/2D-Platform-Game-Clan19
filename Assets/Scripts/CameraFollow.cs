using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    private float smoothSpeed = 0.125f;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private float offsetX = -5.0f;
    [SerializeField]
    private float offsetY = -5.0f;
    private void LateUpdate()
    {
        /*Vector3 desiredPos = _targetPos.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        _targetPos.position = smoothedPosition;
        transform.LookAt(_targetPos);*/
        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, player.position.z+offset.z);
       /* Vector3 tempPos=transform.position;
        tempPos.x = player.transform.position.x - offsetX;
        tempPos.y = player.transform.position.y - offsetY;
        transform.position= tempPos;*/

    }
}
