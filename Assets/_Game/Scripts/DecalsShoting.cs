using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecalsShoting : MonoBehaviour
{
    [SerializeField] private List<GameObject> decalsList = new List<GameObject>();
    [SerializeField] private int maxDecals;


    public void AddDecalsInList(GameObject decal)
    {
        if ( decalsList.Count >= maxDecals)
        {
            GameObject oldestDecal = decalsList[0];
            decalsList.RemoveAt(0);
            Destroy(oldestDecal);
        }
        decalsList.Add(decal);
    }
}
