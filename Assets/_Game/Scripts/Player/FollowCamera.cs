using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float lerpRate;

    private void Start()
    {
        transform.position = playerTransform.position;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, playerTransform.position, lerpRate * Time.deltaTime);
    }
}
