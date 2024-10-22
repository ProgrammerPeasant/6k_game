// ResourceVisual.cs
using TMPro;
using UnityEngine;

public class ResourceVisual : MonoBehaviour
{
    public GameResource resource;
    public TextMeshProUGUI resourceText;

    private ResourceBank resourceBank;

    private void Start()
    {

        resourceBank = FindObjectOfType<ResourceBank>();

        if (resourceBank != null)
        {
            resourceBank.GetResource(resource).OnValueChanged += UpdateResourceText;
            UpdateResourceText(resourceBank.GetResource(resource).Value);
        }
        else
        {
            Debug.LogError("ResourceBank не найден на сцене!");
        }
    }

    private void UpdateResourceText(int newValue)
    {
        resourceText.text = $"{resource}: {newValue}";
    }
}