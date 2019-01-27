using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CollisionTypes;

public class TextBubbleSpwnScrn : MonoBehaviour
{
	public GameObject txtBubbleScrn;
	public GameObject panel;

	public List<string> tapReactions;
	public List<string> scrapeReactions;
	public List<string> bigReactions;
	
	// Start is called before the first frame update
	void Start()
	{
		SpawnDialogsAccordingToBadnessMeter(100, new Big() );
		//CreateDialog(0);
		//panelTxt.GetComponent<RectTransform>().position = panel.GetComponent<RectTransform>().position;
	}

	private void Update()
	{
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

		float xPos = UnityEngine.Random.Range(0, size.x);
		float yPos = UnityEngine.Random.Range(0, size.y);

		panelInst.GetComponent<RectTransform>().localPosition = new Vector2(xPos/2, yPos/2);
		panelInst.GetComponent<RectTransform>().sizeDelta = new Vector2(1, 1);
		textmesh.text = dialogReaction;
	}

	public void SpawnDialogsAccordingToBadnessMeter(float badnessMeter, CollisionType colType) {

		int severityLevel = 0;
		int numDialogs = 0;
		if (colType is Big) {
			numDialogs = (int) badnessMeter / 10;
		} else if (colType is Scrape) {
			numDialogs = (int) badnessMeter / 20;

		} else if (colType is Tap) {
			numDialogs = (int) badnessMeter / 25;
		}

		StartCoroutine(SpawningDialogs(numDialogs, severityLevel));
	}

	IEnumerator SpawningDialogs(int numDialogs, int severityLevel) {

		for (int i = 0; i < numDialogs; i++) {

			CreateDialog(severityLevel);
			yield return new WaitForSeconds(.2f);
		}
	}
}
