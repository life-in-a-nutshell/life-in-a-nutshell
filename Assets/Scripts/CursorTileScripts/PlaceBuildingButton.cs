using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class PlaceBuildingButton : MonoBehaviour
{

	bool isButtonEnabled;
	public TextMeshProUGUI buttonText;
	// Start is called before the first frame update
	void Start()
	{
		isButtonEnabled = true;
		GameEvents.current.onDisableTileCursor += EnableBuildButton;
		GameEvents.current.onEnableTileCursor += DisableBuildButton;

	}

	private void OnGUI()
	{
		if (isButtonEnabled)
		{
			buttonText.text = "Building placement is OFF";
		}
		else
		{
			buttonText.text = "Building placement is ON";
		}
	}

	void EnableBuildButton()
	{
		isButtonEnabled = true;
		GetComponent<Button>().interactable = true;

	}

	void DisableBuildButton()
	{
		isButtonEnabled = false;
		GetComponent<Button>().interactable = false;
	}
}
