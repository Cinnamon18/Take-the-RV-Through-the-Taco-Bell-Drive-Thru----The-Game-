using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSettings : MonoBehaviour
{

    public bool useSpaceGravity;

    void Awake() {
        if (useSpaceGravity) {
            Physics.gravity = new Vector3(0, 0, 0);
        } else {
            Physics.gravity = new Vector3(0, -9.81f, 0);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
