using UnityEngine;

public class Character : MonoBehaviour
{
    public string characterName;

    //Core Statistics
    float baseMight;
    float currentMight;

    float baseAgility;
    float currentAgility;

    float baseIntellect;
    float currentIntellect;

    float baseSavvy;
    float currentSavvy;

    float baseLevel;
    float currentLevel;

    
    //Class Modifiers
    float hitPointModifier;
    float spellPointModifier;


    //Derived Stats
    float HitPoints()
    {
        return currentMight * (4f + hitPointModifier) *currentLevel;
    }
    float SpellPoints()
    {
        return currentIntellect * (1f + spellPointModifier) * currentLevel;
    }
    float ArmorClass()
    {
        return currentAgility;
    }
    float bonusMeleeDamage()
    {
        return currentMight;
    }
    float bonusRangedDamage()
    {
        return currentAgility;
    }

    float currentHitPoints;
    float currentSpellPoints;
 
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentMight = baseMight;
        currentAgility = baseAgility;
        currentIntellect = baseIntellect;
        currentSavvy = baseSavvy;
        currentLevel = baseLevel;
        currentHitPoints = HitPoints();
        currentSpellPoints = SpellPoints();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        currentHitPoints -= damage;
        if (currentHitPoints < 0) 
        { 
            Die(); 
        }
    }

    void Die()
    {

    }
}
