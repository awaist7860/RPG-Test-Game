using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// An item that can be equiped
[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipSlot;     //Slot to store equipment in

    public SkinnedMeshRenderer mesh;

    public EquipmentMeshRegion[] coveredMeshRegions;

    public int armorModifier;           //Increase/decrease in armor
    public int damageModifier;          //Increase/decrease in damage


    //When pressed in inventory
    public override void Use()
    {
        base.Use();
        //equip the item
        EquipmentManager.instance.Equip(this);      //Equip it
        //Remove it from the inventory
        RemoveFromInventory();                      //Remove it from inventory
    }
}


public enum EquipmentSlot { Head, Chest, Legs, Weapon, Shield, Feet}
public enum EquipmentMeshRegion { Legs, Arms, Torso};   //Corresponds to body blend shapes