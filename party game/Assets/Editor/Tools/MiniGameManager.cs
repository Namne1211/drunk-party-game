using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
public class MiniGameManager : EditorWindow
{
    public GameObject SampleCard;
    public Transform Holder;
    int cardIndex;
    string cardContent;
    string cardContentShow;

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
        EditorGUILayout.PropertyField(obj.FindProperty("Holder"));
        EditorGUILayout.ObjectField(obj.FindProperty("SampleCard"));

        if (Holder == null)
        {
            EditorGUILayout.HelpBox("please assign all variable", MessageType.Warning);
        }
        else
        {
            cardIndex = EditorGUILayout.IntField("index", cardIndex);
            cardContent = EditorGUILayout.TextField("Context", cardContent);
            EditorGUILayout.BeginVertical("box");
            DrawButtonNormal();
            EditorGUILayout.EndVertical();
        }
        obj.ApplyModifiedProperties();

    }

    //handle button

    void DrawButtonNormal()
    {
        if (GUILayout.Button("create normal Card"))
        {
            CreateNormaCard();
        }
        if (Selection.activeGameObject != null && Selection.activeGameObject.GetComponent<Minigame>())
        {
            
            if (GUILayout.Button("update content"))
            {
                UpdateContent();
            }

            if (GUILayout.Button("delete Card"))
            {
               DeleteCard();
            }
            
        }

    }

    void CreateNormaCard()
    {
        if (cardContent == "")
        {
            Debug.LogError("Error: please fill in content");
        }
        else
        {
            GameObject newCard = Instantiate(SampleCard,Holder);
            newCard.transform.position = Holder.transform.position;
            newCard.transform.rotation = Holder.transform.rotation;
            Minigame card = newCard.GetComponent<Minigame>();
            card.ChangeContent(cardContent);
            card.questionIndex = cardIndex;
            Selection.activeGameObject = card.gameObject;
            //card.gameObject.SetActive(false);
            cardContent = "";
        }
        
        
    }

    void UpdateContent()
    {
        
        Minigame card = Selection.activeGameObject.GetComponent<Minigame>();
        card.ChangeContent(cardContent);
        card.questionIndex = cardIndex;
    }

    void DeleteCard()
    {
        Minigame card = Selection.activeGameObject.GetComponent<Minigame>();
        if (card != null)
        DestroyImmediate(card.gameObject);
        cardContent = "";

    }
#endif
}

