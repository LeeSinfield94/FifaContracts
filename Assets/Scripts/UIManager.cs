using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject _rulesPrefab;
    [SerializeField] Transform[] _contents;
    bool isContractPanel = false;

    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        StartCoroutine(WaitForRulesDictionaryToBePopulated());
    }

    public IEnumerator WaitForRulesDictionaryToBePopulated()
    {
        yield return new WaitUntil(() => Rules.Instance.CSVRead);
        PopulateRules(Rules.Instance._Rules, true);
    }
    public void PopulateRules(Dictionary<string, string> rules, bool buttonOn)
    {
        isContractPanel = !buttonOn;
        Transform currentContent = isContractPanel ? _contents[1] : _contents[0];
        foreach(KeyValuePair<string, string> rule in rules)
        {
            GameObject go = Instantiate(_rulesPrefab, currentContent);
            Rule newRule = go.GetComponent<Rule>();
            newRule.SetRule(rule.Key);
            newRule.SetPunishment(rule.Value);
            newRule.ButtonOn = buttonOn;
        }
        if(isContractPanel)
        {
            //TODO Add Signing Section.
        }
    }
    
    public void ClearCurrentContractList()
    {
        for(int i = 1; i <= _contents[1].childCount - 1; i++)
        {
            Destroy(_contents[1].GetChild(i).gameObject);
        }
    }
}
