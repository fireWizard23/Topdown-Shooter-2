using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryComponent : MonoBehaviour
{
    [SerializeField] private int InventorySize = 1;

    public List<WeaponDropBase> itemsInInventory;
    public WeaponDropBase itemEquipped;

    // Start is called before the first frame update
    void Start()
    {
        itemsInInventory = new List<WeaponDropBase>(InventorySize);
    }

    public void SetEquipped(WeaponDropBase weapon)
    {
        itemsInInventory.Add(weapon);
        itemEquipped = weapon;
        weapon.transform.parent = transform;
    }

    public void DeEquipped()
    {
        itemsInInventory.Remove(itemEquipped);
        itemEquipped = null;
        itemEquipped.transform.parent = null;

    }

    private void Update()
    {
        if(itemEquipped != null)
        {
            print(itemEquipped.name);
        }
    }



}
