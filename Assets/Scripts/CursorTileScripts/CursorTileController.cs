using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;
public class CursorTileController : MonoBehaviour
{

	[SerializeField]
	Tile availableTile;
	[SerializeField]
	Tile unavailableTile;

	[SerializeField]
	Tilemap terrainTilemap;

	[SerializeField]
	Tilemap buildingsTilemap;

	[SerializeField]
	Tilemap overlayTilemap;
	Camera cam;

	bool buildingBeingPlaced;

	[SerializeField]
	Tile unbuildableTile;
	[SerializeField]
	Tile buildingTile;



	void Start()
	{
		cam = Camera.main;
		buildingBeingPlaced = false;
		GameEvents.current.onEnableTileCursor += EnableTileCursor;
		GameEvents.current.onDisableTileCursor += DisableTileCursor;
	}

	void Update()
	{
		if (buildingBeingPlaced)
		{
			overlayTilemap.ClearAllTiles();
			Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
			Vector3Int terrainPosition = terrainTilemap.WorldToCell(cam.ScreenToWorldPoint(mousePos));
			Vector3Int buildingPosition = buildingsTilemap.WorldToCell(cam.ScreenToWorldPoint(mousePos)) + new Vector3Int(0, 0, -1);
			Vector3Int gridPosition = overlayTilemap.WorldToCell(cam.ScreenToWorldPoint(mousePos));
			Vector3Int overlayPosition = gridPosition + new Vector3Int(0, 0, -2);
			if (terrainTilemap.HasTile(terrainPosition))
			{
				Debug.Log(terrainTilemap.GetTile(gridPosition));
				if (terrainTilemap.GetTile(terrainPosition) != unbuildableTile && !buildingsTilemap.HasTile(buildingPosition))
				{
					overlayTilemap.SetTile(overlayPosition, availableTile);
					if (Input.GetMouseButtonDown(0))
					{
						buildingsTilemap.SetTile(buildingPosition, buildingTile);
						GameEvents.current.DisableTileCursor();
						buildingBeingPlaced = false;

					}


				}
				else
				{
					overlayTilemap.SetTile(overlayPosition, unavailableTile);

				}

			}
			if (Input.GetMouseButtonDown(1))
			{
				buildingBeingPlaced = false;
				GameEvents.current.DisableTileCursor();
			}

		}
	}
	void EnableTileCursor()
	{
		buildingBeingPlaced = true;
	}

	void DisableTileCursor()
	{
		buildingBeingPlaced = false;
		overlayTilemap.ClearAllTiles();

	}

}