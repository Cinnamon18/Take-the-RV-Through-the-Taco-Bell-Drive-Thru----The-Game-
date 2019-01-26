using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TxtBubbleSpwnSrcn : MonoBehaviour
{
	
	// Start is called before the first frame update
	void Start()
    {
		GameObject bubScrn = GameObject.Find("TextBubbleScrn");
		RectTransform bubScrnTrns = bubScrn.GetComponent<RectTransform>();
		Vector2 bubScrnTopR = bubScrnTrns.anchorMax;
		Vector2 bubScrnBottomL = bubScrnTrns.anchorMin;
	}
}
