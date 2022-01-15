using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraFollower : MonoSingleton<CameraFollower>
{
    [SerializeField] private GameObject player;
    public Vector3 offset;

    [SerializeField] private float smoothSpeed = 0.125f;

    void FixedUpdate()
    {
        Vector3 desiredPos = player.transform.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);

        transform.position = smoothedPos;
    }
    public void SetTarget(GameObject target)
    {
        player = target;
        transform.position = new Vector3(0f, transform.position.y, transform.position.z);
        offset = new Vector3(0, offset.y, offset.z);
    }
}