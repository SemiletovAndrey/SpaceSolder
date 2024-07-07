using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject flash;
    [SerializeField] private float shotPeriod = 0.5f;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private float lineLength = 20f;
    [SerializeField] private float rangeRay = 100f;
    [SerializeField] private Transform shot;
    [SerializeField] private GameObject decalShooting;
    [SerializeField] private Transform decalsTRansform;

    private Vector3 lineLengthVector;
    private float _timer;
    private DecalsShoting decalsShoting;

    private void Start()
    {
        decalsShoting = decalsTRansform.GetComponent<DecalsShoting>();
    }
    void Update()
    {
        _timer += Time.deltaTime;
        SightRendering();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

    }

    private void SightRendering()
    {
        lineRenderer.SetPosition(0, shot.position);
        RaycastHit hit;
        if (Physics.Raycast(shot.position, shot.forward, out hit, rangeRay))
        {
            lineRenderer.SetPosition(1, hit.point);
            Debug.DrawRay(shot.transform.position, hit.point, Color.green);
        }
        else
        {
            Vector3 point = shot.position + shot.forward * rangeRay;
            lineRenderer.SetPosition(1, point);
        }
    }

    public void Shoot()
    {
        if (_timer > shotPeriod)
        {
            _timer = 0;
            RaycastHit hit;
            if (Physics.Raycast(shot.transform.position, shot.transform.forward, out hit, rangeRay))
            {
                GameObject decal = Instantiate(decalShooting, hit.point, Quaternion.LookRotation(hit.normal), decalsTRansform);
                decalsShoting.AddDecalsInList(decal);
            }
            else
            {

            }
            flash.SetActive(true);
            Invoke(nameof(HideFlash), 0.12f);
        }
    }

    public void HideFlash()
    {
        flash.SetActive(false);
    }
}
