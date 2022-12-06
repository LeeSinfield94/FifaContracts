using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rules : MonoBehaviour
{
    Dictionary<string, string> _rules = new Dictionary<string, string>();

    public Dictionary<string, string> _Rules
    {
        get { return _rules; }
    }

    bool _CSVRead = false;
    public bool CSVRead
    {
        get { return _CSVRead; }
        set { _CSVRead = value; }
    }

    public static Rules Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void AddRules(string rule, string punishment)
    {
        _rules.Add(rule, punishment);
    }

    public void UpdateRuleDrinkAmount(string key, string newPunishment)
    {
        if(_rules.ContainsKey(key))
        {
            _rules[key] = newPunishment;
        }
    }
}
