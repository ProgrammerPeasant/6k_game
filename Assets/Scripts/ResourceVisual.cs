using TMPro;
using UnityEngine;

public class ResourceVisual : MonoBehaviour
{
    public GameResource resource;
    public TextMeshProUGUI resourceText;
    public TextMeshProUGUI resourceLabel;

    private ResourceBank resourceBank;

    private void Start()
    {

        resourceBank = FindObjectOfType<ResourceBank>();
        if (resourceBank != null)
        {
            UpdateVisual(resourceBank.GetResource(resource).Value);
            resourceBank.GetResource(resource).OnValueChanged += UpdateVisual;
        }
    }

    private void UpdateVisual(int newValue)
    {
        resourceText.text = newValue.ToString();
        resourceLabel.text = resource.ToString();
    }

    private void OnDestroy()
    {
        if (resourceBank != null)
        {
            resourceBank.GetResource(resource).OnValueChanged -= UpdateVisual;
        }
    }
}
