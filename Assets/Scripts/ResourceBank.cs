// ObservableInt.cs
using System;

// ResourceBank.cs
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

// ResourceBank.cs

public class ResourceBank : MonoBehaviour
{
    // Словарь, где ключ - это ресурс, а значение - это наблюдаемое целочисленное значение
    private Dictionary<GameResource, ObservableInt> _resources;

    // Инициализация словаря
    private void Awake()
    {
        // Создаем словарь и инициализируем каждый ресурс с базовым значением 0
        _resources = new Dictionary<GameResource, ObservableInt>
        {
            { GameResource.Humans, new ObservableInt() },
            { GameResource.Food, new ObservableInt() },
            { GameResource.Wood, new ObservableInt() },
            { GameResource.Stone, new ObservableInt() },
            { GameResource.Gold, new ObservableInt() }
        };
    }

    // Метод для изменения ресурса
    public void ChangeResource(GameResource resource, int value)
    {
        // Проверяем, что ресурс существует в словаре
        if (_resources.ContainsKey(resource))
        {
            _resources[resource].Value += value;  // Меняем значение ресурса
        }
        else
        {
            Debug.LogError("Ресурс не найден: " + resource);
        }
    }

    // Метод для получения значения ресурса
    public ObservableInt GetResource(GameResource resource)
    {
        if (_resources.ContainsKey(resource))
        {
            return _resources[resource];
        }
        else
        {
            Debug.LogError("Ресурс не найден: " + resource);
            return null;
        }
    }
}

