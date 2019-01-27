using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RVVFX : MonoBehaviour
{
    public ParticleSystem dustTrailL;
    public ParticleSystem dustTrailR;
    public ParticleSystem smallImpact;
    public ParticleSystem bigImpact;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void EmitDust(float dustAmount)
    {
        dustTrailL.Play();
        dustTrailR.Play();
    }

    public void playDamageEffect(int indx, Vector3 position)
    {
        ParticleSystem pS = indx == 0? Object.Instantiate(smallImpact): Object.Instantiate(bigImpact);
        pS.transform.position = position;
        pS.Play();
    }
}
