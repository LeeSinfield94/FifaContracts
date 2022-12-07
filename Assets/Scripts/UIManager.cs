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
    [SerializeField] GameObject _saveButton;
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
            SpawnSaveButton(currentContent);
        }
    }
    
    public void AddSigningSection()
    {
        
    }

    public void SpawnSaveButton(Transform content)
    {
        GameObject go = Instantiate(_saveButton, content);
        go.GetComponentInChildren<Button>().onClick.AddListener(delegate { Contract.Instance.SaveContract(go.GetComponentInChildren<TMP_InputField>().text); });
    }

    public void LoadAllContracts()
    {
        ClearContractsList();
        TextAsset[] contracts = SaveLoad.LoadContracts("Contracts");
        Transform contractsContent = _contents[2];
        foreach (TextAsset contract in contracts)
        {
            string[] newContract = contract.name.Split(new string[] {"Assets/Contracts", "/", "." }, StringSplitOptions.None);
            //string newstring = newContract[1].Remove(0, 1);
            GameObject go = Instantiate(_contractPrefab, contractsContent);
            go.GetComponentInChildren<TMP_Text>().text = newContract[0];
            go.GetComponentInChildren<Button>().onClick.AddListener(delegate { LoadContract(newContract[0]); });
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
