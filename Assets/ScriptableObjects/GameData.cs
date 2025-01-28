using UnityEngine;


[CreateAssetMenu]
public class GameData : ScriptableObject
{
    [SerializeField]
    private int _maxHealth;

    public int MaxHealth
    {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }


    [SerializeField]
    private int _currentHealth;

    public int CurrentHealth
    {
        get { return _currentHealth; }
        set { _currentHealth = value; }
    }


}
