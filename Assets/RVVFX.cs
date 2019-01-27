using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RVVFX : MonoBehaviour
{
    public ParticleSystem exhaust;
    public ParticleSystem smallImpact;
    public ParticleSystem bigImpact;

    // Start is called before the first frame update
    void Start()
    {
        exhaust.Play();
    }

    public void playDamageEffect(int indx, Vector3 position)
    {
        ParticleSystem pS = indx == 0? Object.Instantiate(smallImpact): Object.Instantiate(bigImpact);
        pS.transform.position = position;
        pS.Play();
    }
}
