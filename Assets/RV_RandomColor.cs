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
        rvMat = transform.GetChild(0).GetComponent<MeshRenderer>().material;
        Color rvColor = colors[Random.Range(0, 7)];
        rvMat.color = rvColor;

        // random rotation
        if (Random.Range(0f, 1f) < .5f)
            transform.forward *= -1f;

        transform.Rotate(0, Random.Range(-2f, 2f), 0);
    }
}
