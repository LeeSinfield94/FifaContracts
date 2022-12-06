using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject _rulesPrefab;
    [SerializeField] GameObject _contractPrefab;
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
            AddSigningSection();
        }
    }
    
    public void AddSigningSection()
    {

    }



    public void LoadAllContracts()
    {
        ClearContractsList();
        string[] contracts = SaveLoad.LoadContracts("Assets/Contracts");
        Transform contractsContent = _contents[2];
        foreach (string contract in contracts)
        {
            string[] newContract = contract.Split(new string[] {"Assets/Contracts", "/", "." }, StringSplitOptions.None);
            string newstring = newContract[1].Remove(0, 1);
            GameObject go = Instantiate(_contractPrefab, contractsContent);
            go.GetComponentInChildren<TMP_Text>().text = newstring;
            go.GetComponentInChildren<Button>().onClick.AddListener(delegate { LoadContract(newstring); });
        }
    }

    public void LoadContract(string contractName)
    {
        SaveLoad.LoadContract(contractName);
        print(contractName);
    }


    public void ClearCurrentContractList()
    {
        for(int i = 1; i <= _contents[1].childCount - 1; i++)
        {
            Destroy(_contents[1].GetChild(i).gameObject);
        }
    }
    public void ClearContractsList()
    {
        for (int i = 0; i <= _contents[2].childCount - 1; i++)
        {
            Destroy(_contents[2].GetChild(i).gameObject);
        }
    }
}
