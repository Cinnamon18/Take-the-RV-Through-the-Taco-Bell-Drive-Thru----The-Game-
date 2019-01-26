using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogPopup : MonoBehaviour
{

    Camera cam;
    RectTransform rect;
    public AnimationCurve movementCurve;
    public float timeToAnimate;
    Vector2 initialPosition;
    public Vector2 finalOffset;
    public float offsetScale;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        cam = GameObject.FindObjectOfType<Camera>();
        StartCoroutine(MovingPanelOntoScreen());
        initialPosition = rect.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = cam.transform.rotation;
    }

    IEnumerator MovingPanelOntoScreen() {

        float progress = 0;
        float step = 1f / timeToAnimate;
        
        while(progress < 1) {
            progress += Time.deltaTime * step;

            
            rect.localPosition = movementCurve.Evaluate(progress) * finalOffset * offsetScale + initialPosition;
            rect.localScale = new Vector3(1, 1, 1) * movementCurve.Evaluate(progress);
            //Vector2.Lerp(initialPosition, initialPosition + finalOffset * movementCurve.Evaluate(progress), 1);

            yield return null;
        }

        rect.localPosition = initialPosition + movementCurve.Evaluate(1) * finalOffset * offsetScale;
    }
}
