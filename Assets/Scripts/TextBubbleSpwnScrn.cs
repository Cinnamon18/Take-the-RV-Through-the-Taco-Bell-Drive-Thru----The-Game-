using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CollisionTypes;

public class TextBubbleSpwnScrn : MonoBehaviour {
	public GameObject txtBubbleScrn;
	public GameObject panel;

	public List<string> tapReactions;
	public List<string> scrapeReactions;
	public List<string> bigReactions;

	// Start is called before the first frame update
	void Start() {
		//SpawnDialogsAccordingToBadnessMeter(100, new Big() );
		//CreateDialog(0);
		//panelTxt.GetComponent<RectTransform>().position = panel.GetComponent<RectTransform>().position;
	}

	private void Update() {
	}

	public void SpawnDialogsAccordingToBadnessMeter(float badnessMeter, CollisionType colType) {

		int severityLevel = 0;
		int numDialogs = 0;
		if (colType is Big) {
			numDialogs = Random.Range(2, 4);
			severityLevel = 2;
		} else if (colType is Scrape) {
			numDialogs = Random.Range(1, 3);
			severityLevel = 1;
		} else if (colType is Tap) {
			numDialogs = Random.Range(1, 2);
			severityLevel = 0;
		}

		StartCoroutine(SpawningDialogs(numDialogs, severityLevel));
	}

	IEnumerator SpawningDialogs(int numDialogs, int severityLevel) {

		for (int i = 0; i < numDialogs; i++) {

			CreateDialog(severityLevel);
			yield return new WaitForSeconds(.2f);
		}
	}

	public void CreateDialog(int severityLevel) {

		string dialogReaction;
		switch (severityLevel) {
			case (0):
				dialogReaction = tapReactions[UnityEngine.Random.Range(0, tapReactions.Count)];
				break;
			case (1):
				dialogReaction = scrapeReactions[UnityEngine.Random.Range(0, scrapeReactions.Count)];
				break;
			case (2):
				dialogReaction = bigReactions[UnityEngine.Random.Range(0, bigReactions.Count)];
				break;
			default:
				dialogReaction = "ERROR";
				break;
		}

		GameObject panelInst = GameObject.Instantiate(panel, txtBubbleScrn.transform);
		TextMeshProUGUI textmesh = panelInst.GetComponentsInChildren<TextMeshProUGUI>()[0];
		RectTransform bubScrnTrns = txtBubbleScrn.GetComponent<RectTransform>();
		Vector2 size = bubScrnTrns.sizeDelta;

		float xPos = UnityEngine.Random.Range(0, size.x) / 2;
		float yPos = UnityEngine.Random.Range(0, size.y) / 2;

		RectTransform popupBubbleTrans = panelInst.GetComponent<RectTransform>();

		popupBubbleTrans.sizeDelta = new Vector2(1, 1);
		popupBubbleTrans.localPosition = new Vector2(xPos, yPos);
		textmesh.text = dialogReaction;

		//invert the text for things less than halfway
		// if (xPos > (size.x / 4.0f)) {
		// 	Debug.Log(dialogReaction);
		// 	popupBubbleTrans.localScale = new Vector3(-1, 1, 1);
			// popupBubbleTrans.localScale = new Vector3(popupBubbleTrans.localScale.x * -1, popupBubbleTrans.localScale.y, popupBubbleTrans.localScale.z);
			// RectTransform childTrans = panelInst.GetComponentInChildren<RectTransform>();
			// childTrans.localScale = new Vector3(childTrans.localScale.x * -1, childTrans.localScale.y, childTrans.localScale.z);
		// }
	}
}
