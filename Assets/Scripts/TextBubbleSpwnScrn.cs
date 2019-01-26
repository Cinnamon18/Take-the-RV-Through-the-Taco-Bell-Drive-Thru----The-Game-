using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextBubbleSpwnScrn : MonoBehaviour
{
	public GameObject txtBubbleScrn;
	public GameObject panel;
	public TextMeshProUGUI panelTxt;
	// Start is called before the first frame update
	void Start()
	{
		RectTransform bubScrnTrns = txtBubbleScrn.GetComponent<RectTransform>();
		Vector2 bubScrnTopR = bubScrnTrns.anchorMax;
		Vector2 bubScrnBottomL = bubScrnTrns.anchorMin;
		Vector2 size = bubScrnTrns.sizeDelta;

		float xPos = UnityEngine.Random.Range(0, size.x);
		float yPos = UnityEngine.Random.Range(0, size.y);
		//float xPos = UnityEngine.Random.Range(bubScrnBottomL.x, bubScrnTopR.x);
		//float yPos = UnityEngine.Random.Range(bubScrnBottomL.y, bubScrnTopR.y);

		panel.GetComponent<RectTransform>().position = new Vector2(xPos, yPos);
		//panelTxt.GetComponent<RectTransform>().position = panel.GetComponent<RectTransform>().position;
	}

	private void Update()
	{
		panelTxt.text = "this works";
	}

}
