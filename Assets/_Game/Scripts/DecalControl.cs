using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecalControl : MonoBehaviour
{
    [SerializeField] private float timeLife = 10;
    void Start()
    {
        StartCoroutine(DestroyDecal());
    }

    private IEnumerator DestroyDecal()
    {
        yield return new WaitForSeconds(timeLife);
        Destroy(gameObject);
    }
}
