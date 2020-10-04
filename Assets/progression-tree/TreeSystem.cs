using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TreeSystem : MonoBehaviour
{
    public static TreeSystem instance;
    public UnityEvent<TreeNode> unlock;
    private void Awake()
    {
        if(instance == null)
        {
            
            instance = this;
        }
        else
        {
            Debug.Log("instance already exist, destroying object");
            Destroy(this);
        }
    }


}
