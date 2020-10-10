using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(TreeNode))]
[CanEditMultipleObjects]
public class LookAtPointEditor : Editor
{
    private TreeNode targetobject;

    SerializedProperty lookAtPoint;

    void OnEnable()
    {
        targetobject = (target as TreeNode);
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.LabelField(targetobject.transform.parent.name);
        if(GUILayout.Button("create child"))
        {
            GameObject obj = Instantiate(targetobject.gameObject);
            if(targetobject.parentNode.Length == 0)
            {
                obj.transform.position = targetobject.transform.position + Vector3.up * 100;



            }
            else
            {
                Vector3 average = Vector3.zero;
                foreach(TreeNode node in targetobject.parentNode)
                {
                    average += targetobject.transform.position - node.transform.position;
                }
                obj.transform.position = targetobject.transform.position + average.normalized * 100;

            }
            obj.transform.SetParent(targetobject.transform.parent, true);
            TreeNode NewNode = obj.GetComponent<TreeNode>();

            NewNode.parentNode = new TreeNode[1];
            NewNode.parentNode[0] = targetobject;

            targetobject.childNodes.Add(NewNode);
            obj.name = "New node";

            if (targetobject.starternode)
            {
                NewNode.starternode = false;
            }



        }
        DrawDefaultInspector();
    }
}