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

    
    public cost[] Cost;

    public UnityEvent OnUnlock, OnMadeAvaible;
    public bool starternode;
    [Space()]
    [Header("meta")]
    public TreeNode[] parentNode;
    public List< TreeNode> childNodes = new List<TreeNode>();
    Button button;
    Image img;
    public bool unlocked, avaible;

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

        bool ParentsActive = true;
        foreach(TreeNode treeNode in parentNode)
        {
            if (!treeNode.unlocked)
            {
                ParentsActive = false;
            }
        }
        if (ParentsActive)
        {
            avaible = true;
            button.interactable = true;
        }
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
            foreach (TreeNode treeNode in parentNode)
            {
                Gizmos.DrawLine(transform.position, treeNode.transform.position);
            }
        }

        Gizmos.color = Color.blue;
        foreach (TreeNode treeNode in childNodes)
        {
            if(treeNode == null)
            {
                childNodes.Remove(treeNode);
                continue;
            }
            else
            {
                Gizmos.DrawLine(transform.position, treeNode.transform.position);
            }

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
        population,
        science

    }

}

