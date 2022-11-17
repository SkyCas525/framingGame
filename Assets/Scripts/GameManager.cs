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
    private void Update()
    {
        goldText.text = gold.ToString();


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




