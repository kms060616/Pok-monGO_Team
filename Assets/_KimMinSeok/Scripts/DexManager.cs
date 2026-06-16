using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DexManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Transform dexGridParent;
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private TextMeshProUGUI countText;

    [Header("Top Counters")]
    [SerializeField] private TextMeshProUGUI shinyText;
    [SerializeField] private TextMeshProUGUI luckyText;
    [SerializeField] private TextMeshProUGUI xxlText;
    [SerializeField] private TextMeshProUGUI xxsText;
    [SerializeField] private TextMeshProUGUI perfectText;

    [Header("Data")]
    [SerializeField] private List<PokemonData> pokemonDatabase = new List<PokemonData>();
    private PokemonForm currentFilter = PokemonForm.Normal;

    void Start()
    {
        ChangeFilter((int)PokemonForm.Normal);
    }

    public void ChangeFilter(int formIndex)
    {
        currentFilter = (PokemonForm)formIndex;
        GeneratePokedex();
    }

    public void GeneratePokedex()
    {
        foreach (Transform child in dexGridParent)
        {
            Destroy(child.gameObject);
        }
        int caughtCount = 0;
        int shinyCount = 0;
        int luckyCount = 0;
        int xxlCount = 0;
        int xxsCount = 0;
        int perfectCount = 0;
        int totalCount = 0;

        foreach (PokemonData data in pokemonDatabase)
        {
            if (data.pokemonForm == currentFilter)
            {
                totalCount++;
                if (data.isCaught) caughtCount++;
                if (data.isShiny) shinyCount++;
                if (data.isLucky) luckyCount++;
                if (data.isXXL) xxlCount++;
                if (data.isXXS) xxsCount++;
                if (data.isPerfect) perfectCount++;

                GameObject newSlot = Instantiate(slotPrefab, dexGridParent);
                DexSlot slotScript = newSlot.GetComponent<DexSlot>();

                if (slotScript != null)
                {
                    slotScript.Setup(data);
                }
            }
        }
        if (countText != null) countText.text = $"{caughtCount} / {totalCount}";
        if (shinyText != null) shinyText.text = shinyCount.ToString();
        if (luckyText != null) luckyText.text = luckyCount.ToString();
        if (xxlText != null) xxlText.text = xxlCount.ToString();
        if (xxsText != null) xxsText.text = xxsCount.ToString();
        if (perfectText != null) perfectText.text = perfectCount.ToString();
    }
}
