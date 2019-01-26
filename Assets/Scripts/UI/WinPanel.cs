using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPanel : MonoBehaviour
{
    RectTransform rect;
    public AnimationCurve movementCurve;
    public float timeToAnimate;
    Vector2 initialPosition;
    public Vector2 finalOffset;

    void Awake() {
        rect = GetComponent<RectTransform>();
        initialPosition = rect.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        MovePanelOntoScreen();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MovePanelOntoScreen() {
        int i = 77;
        int k = i + 1;
        StartCoroutine(MovingPanelOntoScreen());
    }

    IEnumerator MovingPanelOntoScreen() {

        float progress = 0;
        float step = 1f / timeToAnimate;
        
        while(progress < 1) {
            progress += Time.deltaTime * step;

            
            rect.position = movementCurve.Evaluate(progress) * finalOffset + initialPosition;
            rect.localScale = new Vector3(1, 1, 1) * movementCurve.Evaluate(progress);
            //Vector2.Lerp(initialPosition, initialPosition + finalOffset * movementCurve.Evaluate(progress), 1);

            yield return null;
        }

        rect.position = initialPosition + movementCurve.Evaluate(1) * finalOffset;
    }
}
