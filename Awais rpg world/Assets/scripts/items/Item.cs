using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory")]
public class Item : ScriptableObject
{
    new public string name = "New Item";            //Name of the item
    public Sprite icon = null;                      //Item icon
    public bool isDefaultItem = false;              //Is the item default wear?

    public virtual void Use()
    {
        //Use the item
        //Something might happen

        Debug.Log("using " + name);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }

}
