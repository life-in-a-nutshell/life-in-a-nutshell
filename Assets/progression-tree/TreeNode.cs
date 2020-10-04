using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TreeNode : MonoBehaviour
{
    [Header("stats")]
    public string skillname;

    
    public cost[] c;

    public UnityEvent OnUnlock, OnMadeAvaible;
    public bool starternode;
    [Space()]
    [Header("meta")]
    public TreeNode parentNode;
    public TreeNode[] childNodes;
    Button button;
    Image img;
    bool unlocked, avaible;

    private void Awake()
    {
        button = GetComponent<Button>();
        img = GetComponent< Image>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (starternode)
        {
            MakeAvaible();
        }
        else
        {
            button.interactable = false;
        }
    }


    public void MakeAvaible()
    {
        avaible = true;
        button.interactable = true;
    }

    public void OnClick()
    {

        unlocked = true;
        OnUnlock.Invoke();
        button.interactable = false;
        foreach(TreeNode treeNode in childNodes)
        {
            treeNode.MakeAvaible();
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (!starternode)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, parentNode.transform.position);
        }

        Gizmos.color = Color.blue;
        foreach (TreeNode treeNode in childNodes)
        {
            Gizmos.DrawLine(transform.position, treeNode.transform.position);
        }

    }

    [System.Serializable]
    public struct cost
    {
        public resource resource;
        public int amount;
        public bool removeOnUnlock;
    }

    public enum resource
    {
        energy,
        population
    }

}
