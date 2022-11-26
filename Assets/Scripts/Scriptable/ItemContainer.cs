using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class ItemSlot
{
    public Item item;
    public int count;
}

[CreateAssetMenu(menuName ="Data/Item Container")]
public class ItemContainer : ScriptableObject
{
    public List<ItemSlot> slots;

    public void Add(Item item, int count = 1)
    {
        if (item.stackable == true) // este sirve para agregar objetos que si se pueden acomular
        {
            ItemSlot itemSlot = slots.Find(x => x.item);
            if (itemSlot != null)
            {
                itemSlot.count += count;
            }
            else
            {
                itemSlot = slots.Find(x => x.item == null);
                if (itemSlot != null)
                {
                    itemSlot.item = item;
                    itemSlot.count = count;
                }
            }
        }
        else
        {
           
           ItemSlot itemSlot = slots.Find(x => x.item == null); // agregamos un objeto que no se puede acomular
            if (itemSlot != null)
            {
                itemSlot.item = item;
            }
        }
    }
}
