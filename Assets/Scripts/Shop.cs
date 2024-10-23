using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Button upgradeHumansButton;
    public Button upgradeFoodButton;
    public Button upgradeWoodButton;
    public Button upgradeStoneButton;
    public Button upgradeGoldButton;

    private ResourceBank resourceBank;

    private void Start()
    {
        resourceBank = FindObjectOfType<ResourceBank>();

        upgradeHumansButton.onClick.AddListener(() => UpgradeProductionLevel(GameResource.HumansProdLvl));
        upgradeFoodButton.onClick.AddListener(() => UpgradeProductionLevel(GameResource.FoodProdLvl));
        upgradeWoodButton.onClick.AddListener(() => UpgradeProductionLevel(GameResource.WoodProdLvl));
        upgradeStoneButton.onClick.AddListener(() => UpgradeProductionLevel(GameResource.StoneProdLvl));
        upgradeGoldButton.onClick.AddListener(() => UpgradeProductionLevel(GameResource.GoldProdLvl));
    }

    private void UpgradeProductionLevel(GameResource prodLevelResource)
    {
        resourceBank.ChangeResource(prodLevelResource, 1);
    }
}