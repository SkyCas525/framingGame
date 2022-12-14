using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : ItemPanel
{
    /*[SerializeField] ItemContainer inventory;
    [SerializeField] List<InventoryButton> buttons;

    private void Start()
    {
        SetIndex();
        Show();
    }

    private void SetIndex()
    {
        for (int i = 0; i < inventory.slots.Count && buttons.Count >i; i++)
        {
            buttons[i].SetIndex(i);
        }
    }

    private void OnEnable()
    {
        Show();
    }

    public void Show()
    {
        for (int i = 0; i < inventory.slots.Count && buttons.Count > i; i++)
        {
            if (inventory.slots[i].item == null)
            {
                buttons[i].Clean();
            }
            else
            {
                buttons[i].Set(inventory.slots[i]);
            }
        }
    }*/

    public override void OnClick(int id)
    {
        GameManager.Instance.itemDragAndDropController.OnClick(inventory.slots[id]);
        Show();
    }
}
