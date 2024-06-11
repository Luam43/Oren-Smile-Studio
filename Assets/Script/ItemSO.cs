using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public StatToChange statToChange = new StatToChange();
    public int amountToChangeStat;
    public AttributeToChange attributeToChange = new AttributeToChange();
    public int amountToChangeAttribute;

    public void UseItem()
    {
        PlayerHealth playerHealth = GameObject.Find("HealthManager")?.GetComponent<PlayerHealth>();
        if (playerHealth == null)
        {
            Debug.LogWarning("PlayerHealth component not found!");
            return;
        }

        switch (statToChange)
        {
            case StatToChange.health:
                playerHealth.ChangeHealth(amountToChangeStat);
                break;
            // Add cases for other stats like mana, stamina if needed
            default:
                Debug.LogWarning("Stat change type not supported!");
                break;
        }
    }

    public enum StatToChange
    {
        none,
        health,
        mana,
        stamina
    };

    public enum AttributeToChange
    {
        none,
        strength,
        defense,
        intelligence,
        agility
    };
}
