using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryComponent : MonoBehaviour
{
    [SerializeField] private int InventorySize = 1;

    public List<WeaponBase> itemsInInventory;
    public WeaponBase itemEquipped;

    // Start is called before the first frame update
    void Start()
    {
        itemsInInventory = new List<WeaponBase>(InventorySize);
    }

    public void SetEquipped(WeaponBase weapon)
    {
        itemsInInventory.Add(weapon);
        itemEquipped = weapon;
    }

    public void DeEquipped()
    {
        itemsInInventory.Remove(itemEquipped);
        itemEquipped = null;
    }

    private void Update()
    {
        if(itemEquipped != null)
        {
            print(itemEquipped.name);
        }
    }



}
