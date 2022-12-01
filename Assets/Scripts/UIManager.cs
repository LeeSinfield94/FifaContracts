using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _rulesPrefab;
    [SerializeField] private Transform _parent;


    void Start()
    {
        StartCoroutine(WaitForRulesDictionaryToBePopulated());
    }

    public IEnumerator WaitForRulesDictionaryToBePopulated()
    {
        yield return new WaitUntil(() => Rules.Instance.CSVRead);
        PopulateRules();
    }
    public void PopulateRules()
    {
        foreach(KeyValuePair<string, string> rule in Rules.Instance._Rules)
        {
            GameObject go = Instantiate(_rulesPrefab, _parent);
            go.GetComponent<Rule>().SetRule(rule.Key);
            go.GetComponent<Rule>().SetPunishment(rule.Value);
        }
    }
}
