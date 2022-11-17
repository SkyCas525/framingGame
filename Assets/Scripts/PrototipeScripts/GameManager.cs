using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int gold;
    public Text goldText;
    private Building buildingToPlace;
    public GameObject grid;

    public CustomCursor customCursor;
    public Tile[] tiles;


    private void Update()
    {
        goldText.text = gold.ToString();

        if (Input.GetMouseButtonDown(0) && buildingToPlace != null)
        {
            Tile nearestTile = null;
            float nearestDistance = float.MaxValue;
            foreach (Tile tile in tiles)
            {
                float dist = Vector2.Distance(tile.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
                if (dist < nearestDistance)
                {
                    nearestDistance = dist;
                    nearestTile = tile;
                }
            }
            if (nearestTile.isOccupied == false)
            {
                Instantiate(buildingToPlace, nearestTile.transform.position, Quaternion.identity);
                buildingToPlace = null;
                nearestTile.isOccupied = true;
                customCursor.gameObject.SetActive(false);
                Cursor.visible = true;
            }
        }
    }

    //----------------------------------------Buy Buildingd------------------------------------
    public void BuyBuilding(Building building)
    {
        if (gold >= building.cost)
        {
            customCursor.gameObject.SetActive(true);
            customCursor.GetComponent<SpriteRenderer>().sprite = building.GetComponent<SpriteRenderer>().sprite;
            Cursor.visible = false;


            
            gold -= building.cost;
            buildingToPlace = building;
            grid.SetActive(true);
        }
    }



}




