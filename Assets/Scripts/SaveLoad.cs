using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public static void SaveCurrentContract(string saveName, Dictionary<string, string> rules)
    {
        FileStream file = new FileStream(Application.persistentDataPath + "/Resources/Contracts/" + saveName, FileMode.Create, FileAccess.Write);
        StreamWriter sw = new StreamWriter(file);
        sw.WriteLine("rule, punishment");
        foreach (KeyValuePair<string, string> rule in rules)
        {
            sw.WriteLine(rule.Key + ", " + rule.Value);
        }
        sw.Close();
    }

    /// <summary>
    /// Loads all contracts in given path
    /// </summary>
    /// <param name="filePath">Parameter value to pass.</param>
    public static TextAsset[] LoadContracts(string filePath)
    {
        return Resources.LoadAll<TextAsset>(filePath); 
    }


    public static void LoadContract(string saveName)
    {
        TextAsset file = Resources.Load<TextAsset>("Contracts/" + saveName);
        Debug.Log(file);
        string[] newString = file.text.Split(new string[] { "\n" }, StringSplitOptions.None);
        Contract.Instance.ClearCurrentContractRules();
        for (int i = 1; i <= newString.Length - 1; i++)
        {
            string[] dataValues = newString[i].Split(',');
            if(dataValues.Length > 1)
                Contract.Instance.AddRuleToContract(dataValues[0], dataValues[1]);
        }
        print(newString);
    }
}
