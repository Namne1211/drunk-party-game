using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MiniGameManager : EditorWindow
{
    public GameObject normalSample;
    public Transform Instantiator;

    [MenuItem("Tools/MiniGameEditor")]
        public static void Open()
        {
            //open window
            GetWindow<MiniGameManager>();
        }

    

    private void OnGUI()
    {

        SerializedObject obj = new SerializedObject(this);
        GUILayout.Label("normal card", EditorStyles.boldLabel);
        //check if there is a root for way point or not
        EditorGUILayout.PropertyField(obj.FindProperty("Instantiator"));
        EditorGUILayout.ObjectField(obj.FindProperty("normalSample"));

        if (Instantiator == null)
        {
            EditorGUILayout.HelpBox("please assign an Instantiator", MessageType.Warning);
        }
        else
        {

            EditorGUILayout.BeginVertical("box");
            DrawButtonNormal();
            EditorGUILayout.EndVertical();
        }
        obj.ApplyModifiedProperties();

    }

    //handle button

    void DrawButtonNormal()
    {

        if (GUILayout.Button("create normal MiniGame"))
        {
            CreateNormaCard();
        }

        if (Selection.activeGameObject != null && Selection.activeGameObject.GetComponent<Minigame>())
        {

            if (GUILayout.Button("update content"))
            {
                UpdateContent();
            }

            if (GUILayout.Button("delete minigame"))
            {
               DeleteCard();
            }

        }
    }

    void CreateNormaCard()
    {
        Instantiate(normalSample,Instantiator);
    }

    void UpdateContent()
    {
       
    }

    void DeleteCard()
    {

    }
}

