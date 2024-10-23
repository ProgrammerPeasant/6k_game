using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class ProductionBuilding : MonoBehaviour
{
    public GameResource resource;
    public float productionTime = 5f;
    public Button productionButton;
    public Slider progressSlider;

    private ResourceBank resourceBank;
    private Coroutine productionCoroutine;

    private void Start()
    {

        resourceBank = FindObjectOfType<ResourceBank>();

        progressSlider.value = 0;

        productionButton.onClick.AddListener(StartProduction);
    }

    private void StartProduction()
    {

        if (productionCoroutine == null)
        {
            productionCoroutine = StartCoroutine(ProduceResource());
        }
    }

    private IEnumerator ProduceResource()
    {
        productionButton.interactable = false;

        int prodLevel = resourceBank.GetResource(GetProductionLevelResource(resource)).Value;

        float adjustedProductionTime = productionTime * (1 - prodLevel * 2 / 100f);

        float elapsedTime = 0;

        while (elapsedTime < adjustedProductionTime)
        {
            elapsedTime += Time.deltaTime;
            progressSlider.value = Mathf.Clamp01(elapsedTime / adjustedProductionTime);
            yield return null;
        }

        resourceBank.ChangeResource(resource, 1);

        progressSlider.value = 0;
        productionButton.interactable = true;

        productionCoroutine = null;
    }
    private GameResource GetProductionLevelResource(GameResource resource)
    {
        switch (resource)
        {
            case GameResource.Humans: return GameResource.HumansProdLvl;
            case GameResource.Food: return GameResource.FoodProdLvl;
            case GameResource.Wood: return GameResource.WoodProdLvl;
            case GameResource.Stone: return GameResource.StoneProdLvl;
            case GameResource.Gold: return GameResource.GoldProdLvl;
            default: return GameResource.HumansProdLvl;
        }
    }

}