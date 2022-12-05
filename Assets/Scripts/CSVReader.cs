using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVReader : MonoBehaviour
{
    public TextAsset textAssetData;

    string[] _CSVData;
    public string[] CSVData
    {
        get { return _CSVData; }
    }


    // Start is called before the first frame update
    void Start()
    {
        ReadCSV();
    }

    public void ReadCSV()
    {

        _CSVData = textAssetData.text.Split(new string[] { "\n" }, StringSplitOptions.None);
        for(int i = 1; i <= _CSVData.Length - 1; i++)
        {
            string[] dataValues = _CSVData[i].Split(',');
            Rules.Instance.AddRules(dataValues[0], dataValues[1]);
        }
        Rules.Instance.CSVRead = true;
    }
}
