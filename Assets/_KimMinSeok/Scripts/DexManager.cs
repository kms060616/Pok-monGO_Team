using System.Collections.Generic;
using UnityEngine;

public class DexManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Transform dexGridParent;
    [SerializeField] private GameObject slotPrefab;

    [Header("Data")]
    [SerializeField] private List<PokemonData> pokemonDatabase = new List<PokemonData>();

    void Start()
    {
        GeneratePokedex();
    }

    // 도감 리스트 생성
    public void GeneratePokedex()
    {
        foreach (Transform child in dexGridParent)
        {
            Destroy(child.gameObject);
        }
        foreach (PokemonData data in pokemonDatabase)
        {
            GameObject newSlot = Instantiate(slotPrefab, dexGridParent);
            DexSlot slotScript = newSlot.GetComponent<DexSlot>();

            if (slotScript != null)
            {
                slotScript.Setup(data);
            }
        }
    }
}
