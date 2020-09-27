using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaceBuildingButton : MonoBehaviour
{

	bool buildingPlacement;
	public TextMeshProUGUI buttonText;
	// Start is called before the first frame update
	void Start()
	{
		buildingPlacement = true;
	}

	private void OnGUI()
	{
		if (buildingPlacement)
		{
			buttonText.text = "Building placement is ON";
		}
		else
		{
			buttonText.text = "Building placement is OFF";
		}
	}

    public void ToggleText(){
        buildingPlacement = !buildingPlacement;
    }
}
