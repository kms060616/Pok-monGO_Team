using UnityEngine;

[CreateAssetMenu(fileName = "PokemonData", menuName = "Scriptable Objects/PokemonData")]
public class PokemonData : ScriptableObject
{
    public int pokemonID; 
    public string pokemonName;   
    public Sprite pokemonSprite;  
    public bool isDiscovered;
    public bool isCaught;

    public bool isShiny;
    public bool isLucky; 
    public bool isXXL;
    public bool isXXS;        
    public bool isPerfect;
}
