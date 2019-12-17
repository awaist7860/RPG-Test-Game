using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimator : CharacterAnimator
{

    public WeaponAnimation[] weaponAnimations;
    Dictionary<Equipment, AnimationClip[]> weaponAnimationDict;

    protected override void Start()
    {
        base.Start();
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;

        weaponAnimationDict = new Dictionary<Equipment, AnimationClip[]>();


        foreach(WeaponAnimation a in weaponAnimations)
        {
            weaponAnimationDict.Add(a.weapon, a.clips);
        }
    }

    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        //Equiping
        if(newItem != null && newItem.equipSlot == EquipmentSlot.Weapon)
        {
            animator.SetLayerWeight(1, 1);
            if (weaponAnimationDict.ContainsKey(newItem))
            {
                currentAttackAnimSet = weaponAnimationDict[newItem];
            }
        }

        //Unequiping
        else if(newItem == null && oldItem != null && oldItem.equipSlot == EquipmentSlot.Weapon)
        {
            animator.SetLayerWeight(1, 0);
            currentAttackAnimSet = defaultAttackAnimSet;
        }

        if (newItem != null && newItem.equipSlot == EquipmentSlot.Shield)
        {
            animator.SetLayerWeight(2, 1);
        }
        else if (newItem == null && oldItem != null && oldItem.equipSlot == EquipmentSlot.Shield)
        {
            animator.SetLayerWeight(2, 0);
        }
    }


    [System.Serializable]
    public struct WeaponAnimation
    {
        public Equipment weapon;
        public AnimationClip[] clips;
    }
}
