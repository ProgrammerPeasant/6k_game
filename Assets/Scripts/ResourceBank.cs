using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObservableInt
{
    private int _value;

    public int Value
    {
        get => _value;
        set
        {
            if (_value != value)
            {
                _value = value;
                OnValueChanged?.Invoke(_value);
            }
        }
    }

    public event Action<int> OnValueChanged;

    public ObservableInt(int initialValue = 0)
    {
        _value = initialValue;
    }
}

public class ResourceBank : MonoBehaviour
{
    public Dictionary<GameResource, ObservableInt> resources = new Dictionary<GameResource, ObservableInt>();
    

    private void Awake()
    {
        resources.Add(GameResource.Humans, new ObservableInt(0));
        resources.Add(GameResource.Food, new ObservableInt(0));
        resources.Add(GameResource.Wood, new ObservableInt(0));
        resources.Add(GameResource.Stone, new ObservableInt(0));
        resources.Add(GameResource.Gold, new ObservableInt(0));

        resources.Add(GameResource.HumansProdLvl, new ObservableInt(1));
        resources.Add(GameResource.FoodProdLvl, new ObservableInt(1));
        resources.Add(GameResource.WoodProdLvl, new ObservableInt(1));
        resources.Add(GameResource.StoneProdLvl, new ObservableInt(1));
        resources.Add(GameResource.GoldProdLvl, new ObservableInt(1));
    }

    public void ChangeResource(GameResource resource, int value)
    {
        if (resources.ContainsKey(resource))
        {
            resources[resource].Value += value;
        }
        else
        {
            Debug.LogError("Ресурс не найден: " + resource);
        }
    }

    public ObservableInt GetResource(GameResource resource)
    {
        if (resources.ContainsKey(resource))
        {
            return resources[resource];
        }
        else
        {
            Debug.LogError("Ресурс не найден: " + resource);
            return null;
        }
    }
}



