﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AudioCollisionFeedback))]
public class AudioCollisionFeedbackEditor : Editor
{
    AudioManager am;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (am == null) am = AudioManager.GetInstance();

        AudioCollisionFeedback myScript = (AudioCollisionFeedback)target;
        
        List<string> options = new List<string>();

        options.Add("None");
        foreach (string s in am.GetSoundDictionary().Keys)
        {
            options.Add(s);
        }

        //if (AudioManager.GetInstance().GetMusicDictionary() == null)
        //{
        //    EditorGUILayout.HelpBox("Error! Add an audio file before running!", MessageType.Error);
        //}

        GUIContent soundDesc = new GUIContent("Sound", "Sound that will be played on collision");

        if (serializedObject.FindProperty("sound").stringValue.Equals("")) EditorGUILayout.Popup(soundDesc, 0, options.ToArray());
        else serializedObject.FindProperty("sound").stringValue = options[EditorGUILayout.Popup(soundDesc, options.IndexOf(serializedObject.FindProperty("sound").stringValue), options.ToArray())];

        serializedObject.ApplyModifiedProperties();
    }
}