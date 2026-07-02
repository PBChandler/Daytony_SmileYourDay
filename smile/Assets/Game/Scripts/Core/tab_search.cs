using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using UnityEditor;
using System;
using UnityEditor.Search;
using JetBrains.Annotations;
public class tab_search : MonoBehaviour
{
    public List<SquawkrProfileScriptableObject> scriptableObjects = new List<SquawkrProfileScriptableObject>();
    private List<Tuple<string, SquawkrProfileScriptableObject>> searchTable = new List<Tuple<string, SquawkrProfileScriptableObject>>();

    private List<Tuple<string, SquawkrProfileScriptableObject>> currentSearchTable = new List<Tuple<string, SquawkrProfileScriptableObject>>();
    public List<squawkr_profilepreview> cells = new List<squawkr_profilepreview>();
    //image friend is image FRAUD
    void Start()
    {
        for(int i = 0; i < scriptableObjects.Count; i++)
        {
            searchTable.Add(new Tuple<string, SquawkrProfileScriptableObject>(scriptableObjects[i].DisplayName.ToLower(), scriptableObjects[i]));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSearchQuery(string search)
    {
        search = search.ToLower();
        currentSearchTable.Clear();
        for(int i = 0; i < searchTable.Count; i++)
        {
            if(searchTable[i].Item1.Contains(search))
            {
                currentSearchTable.Add(searchTable[i]);
            }
            
        }

        for(int i = 0; i < cells.Count; i++)
        {
            try
            {
                cells[i].SetCell(currentSearchTable[i].Item2);
            }
            catch
            {
                cells[i].SetCellEmpty();
            }
               
        }
    }
}
