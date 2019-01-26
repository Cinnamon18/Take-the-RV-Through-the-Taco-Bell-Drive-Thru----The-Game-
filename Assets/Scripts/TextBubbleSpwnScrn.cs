using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextBubbleSpwnScrn : MonoBehaviour
{
	public GameObject txtBubbleScrn;
	public GameObject panel;
	
	// Start is called before the first frame update
	void Start()
	{
		CreateDialog("TEST");
		//panelTxt.GetComponent<RectTransform>().position = panel.GetComponent<RectTransform>().position;
	}

	private void Update()
	{
	}

	public void CreateDialog(string dialog) {
		GameObject panelInst = GameObject.Instantiate(panel, txtBubbleScrn.transform);
		TextMeshProUGUI textmesh = panelInst.GetComponentsInChildren<TextMeshProUGUI>()[0];
		RectTransform bubScrnTrns = txtBubbleScrn.GetComponent<RectTransform>();
		
		Vector2 size = bubScrnTrns.sizeDelta;

		float xPos = UnityEngine.Random.Range(0, size.x);
		float yPos = UnityEngine.Random.Range(0, size.y);

		//panelInst.GetComponent<RectTransform>().localPosition = new Vector2(xPos, yPos);
		panelInst.GetComponent<RectTransform>().sizeDelta = new Vector2(1, 1);
		textmesh.text = dialog;
	}

}
