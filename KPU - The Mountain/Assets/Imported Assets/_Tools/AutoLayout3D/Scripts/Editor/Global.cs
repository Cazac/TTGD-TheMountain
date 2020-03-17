﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace AutoLayout3D
{
    [System.Serializable]
    public struct Padding
    {
        public Vector3 lower;
        public Vector3 upper;
    }

    public enum Direction
    {
        LowerToUpper, UpperToLower
    }

    public enum AxisOrder
    {
        XYZ, XZY, YXZ, YZX, ZXY, ZYX
    }

    public enum AxisAlignment
    {
        Upper, Middle, Lower
    }

    [System.Serializable]
    public struct Bool3
    {
        public bool x, y, z;
    }

    public struct Int3
    {
        public int x, y, z;
    }

    [CustomPropertyDrawer(typeof(Bool3))]
    public class IngredientDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
            Rect xLabelRect = new Rect(position.x, position.y, 15, position.height);
            Rect yLabelRect = new Rect(position.x + 35, position.y, 15, position.height);
            Rect zLabelRect = new Rect(position.x + 70, position.y, 15, position.height);
            Rect xRect = new Rect(position.x + 15, position.y, 15, position.height);
            Rect yRect = new Rect(position.x + 50, position.y, 15, position.height);
            Rect zRect = new Rect(position.x + 85, position.y, 15, position.height);

            EditorGUI.LabelField(xLabelRect, new GUIContent("X"));
            EditorGUI.PropertyField(xRect, property.FindPropertyRelative("x"), GUIContent.none);
            EditorGUI.LabelField(yLabelRect, new GUIContent("Y"));
            EditorGUI.PropertyField(yRect, property.FindPropertyRelative("y"), GUIContent.none);
            EditorGUI.LabelField(zLabelRect, new GUIContent("Z"));
            EditorGUI.PropertyField(zRect, property.FindPropertyRelative("z"), GUIContent.none);

            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }
    }

    public enum ConstraintType
    {
        Flexible, FixedCellCount
    }

    [System.Serializable]
    public class Constraint
    {
        public ConstraintType constraintType = ConstraintType.Flexible;
        public int constraintCount = 1;
    }

    [CustomPropertyDrawer(typeof(Constraint))]
    public class ConstraintDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {

            float height = 18.0f;
            SerializedProperty constraintType = property.FindPropertyRelative("constraintType");
            if ((ConstraintType)constraintType.enumValueIndex == ConstraintType.FixedCellCount)  height = 36.0f;
            return height;
       
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            SerializedProperty constraintType = property.FindPropertyRelative("constraintType");
            Rect rectType = new Rect(position.x, position.y, position.width, 15);
            rectType = EditorGUI.PrefixLabel(rectType, GUIUtility.GetControlID(FocusType.Passive), label);
            EditorGUI.PropertyField(rectType, constraintType, GUIContent.none);

            if ((ConstraintType)constraintType.enumValueIndex == ConstraintType.FixedCellCount)
            {
                EditorGUI.indentLevel = 1;
                Rect rectCount = new Rect(position.x, position.y + 18, position.width, 15);
                EditorGUI.PropertyField(rectCount, property.FindPropertyRelative("constraintCount"));
            }

            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }
    }
}