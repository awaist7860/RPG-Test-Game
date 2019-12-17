using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;

    public int currentHealth { get; private set; }

    public Stat damage;
    public Stat armour;

    //public event System.Action<int, int> OnHealthChanged;


    //Set current health to max health
    //When starting the game
    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {

        damage -= armour.GetValue();

        damage = Mathf.Clamp(damage, 0, int.MaxValue);      //Makes sure we dont have a negative damage

        currentHealth -= damage;
        Debug.Log(transform.name + "takes " + damage + " damage.");

        //if (OnHealthChanged != null)
        //{
            //OnHealthChanged(maxHealth, currentHealth);
        //}

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        //Die in some way
        //This method is menat to be overwritten

        Debug.Log(transform.name + " died");
    }
}
