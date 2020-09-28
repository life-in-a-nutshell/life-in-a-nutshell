using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
	public static GameEvents current;


	private void Awake() {
		current = this;
	}

	public event Action onEnableTileCursor;
	public void EnableTileCursor()
	{

		if (onEnableTileCursor != null)
		{
			onEnableTileCursor();
		}

	}

	public event Action onDisableTileCursor;
	public void DisableTileCursor()
	{

		if (onDisableTileCursor != null)
		{
			onDisableTileCursor();
		}

	}

}
