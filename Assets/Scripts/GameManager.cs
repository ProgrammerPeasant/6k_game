// GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ResourceBank resourceBank;

    private void Start()
    {
        // Находим ResourceBank в сцене
        resourceBank = FindObjectOfType<ResourceBank>();

        if (resourceBank != null)
        {
            // Устанавливаем начальные значения ресурсов
            resourceBank.ChangeResource(GameResource.Humans, 10);
            resourceBank.ChangeResource(GameResource.Food, 5);
            resourceBank.ChangeResource(GameResource.Wood, 5);
        }
        else
        {
            Debug.LogError("ResourceBank не найден на сцене!");
        }
    }
}