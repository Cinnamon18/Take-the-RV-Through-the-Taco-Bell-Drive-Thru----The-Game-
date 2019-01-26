using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextBubbleSpwnScrn : MonoBehaviour
{
	public GameObject txtBubbleScrn;
	public GameObject panel;
	public TextContainer panelTxt;
	// Start is called before the first frame update
	void Start()
	{
		RectTransform bubScrnTrns = txtBubbleScrn.GetComponent<RectTransform>();
		Vector2 bubScrnTopR = bubScrnTrns.anchorMax;
		Vector2 bubScrnBottomL = bubScrnTrns.anchorMin;
	}

}
