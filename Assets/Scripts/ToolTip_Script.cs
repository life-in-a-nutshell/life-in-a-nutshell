using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Newtonsoft.Json;
using System.IO;

public class ToolTip_Script : MonoBehaviour
{
    private string objectname;

    public GameObject panel;
    public Text info;

    public Tips_Class TC = new Tips_Class();

    public Tips_List Tips = new Tips_List();

    TextAsset asset;
    // Start is called before the first frame update
    void Start()
    {
        asset = Resources.Load("tooltips") as TextAsset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseOver()
    {
        objectname = this.name;

        if (asset != null)
        {
            Tips = JsonUtility.FromJson<Tips_List>(asset.text);
            foreach (Tips_Class c in Tips.Tips)
            {
                if(objectname == c.Object)
                {
                   panel.SetActive(true);
                   info.text = c.Text;
                }
            }
        }
    }

    public void OnMouseExit()
    {
        panel.SetActive(false);
    }
}

[Serializable]
public class Tips_Class
{
    public string Object;
    public string Text;
}

[Serializable]
public class Tips_List
{
    public List<Tips_Class> Tips = new List<Tips_Class>();
}