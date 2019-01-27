using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RV_RandomColor : MonoBehaviour
{
    public Color[] colors = new Color[7];
    public Material rvMat;

    // Start is called before the first frame update
    void Start()
    {
        rvMat = transform.GetChild(0).GetComponent<Material>();
        Color rvColor = colors[Random.Range(0, 6)];
    }
}
