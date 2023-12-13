using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private float damping;

    [SerializeField] private Player player;
    private Vector3 vel = Vector3.zero;

    private void FixedUpdate()
    {
        Vector3 targetTransFrom = player.transform.position + offset;
        targetTransFrom.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, targetTransFrom,ref vel, damping);

    }
}
