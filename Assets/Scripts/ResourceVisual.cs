using TMPro;
using UnityEngine;

public class ResourceVisual : MonoBehaviour
{
    public GameResource resource; // Тип ресурса
    public TextMeshProUGUI resourceText; // Текстовый элемент для отображения количества ресурса
    public TextMeshProUGUI resourceLabel; // Текстовый элемент для отображения названия ресурса

    private ResourceBank resourceBank;

    private void Start()
    {
        // Найдем ResourceBank на сцене
        resourceBank = FindObjectOfType<ResourceBank>();
        if (resourceBank != null)
        {
            // Изначально обновим текст
            UpdateVisual(resourceBank.GetResource(resource).Value);
            // Подпишемся на обновление значения ресурса
            resourceBank.GetResource(resource).OnValueChanged += UpdateVisual;
        }
    }

    // Метод для обновления текста с параметром нового значения ресурса
    private void UpdateVisual(int newValue)
    {
        // Обновляем текст без двоеточия
        resourceText.text = newValue.ToString();
        resourceLabel.text = resource.ToString(); // Название ресурса
    }

    private void OnDestroy()
    {
        // Отписываемся от события при уничтожении объекта
        if (resourceBank != null)
        {
            resourceBank.GetResource(resource).OnValueChanged -= UpdateVisual;
        }
    }
}
