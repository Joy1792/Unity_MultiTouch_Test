﻿/*
 * @author Valentin Simonov / http://va.lent.in/
 */

using TouchScript.Behaviors;
using UnityEditor;
using UnityEngine;
using System.Reflection;
using TouchScript.Editor.Utils;

namespace TouchScript.Editor.Behaviors
{
    [CustomEditor(typeof(Transformer), true)]
    internal class TransformerEditor : UnityEditor.Editor
    {
		public static readonly GUIContent TEXT_SMOOTHING_HEADER = new GUIContent("Smoothing", "Applies smoothing to transform actions. This allows to reduce jagged movements but adds some visual lag.");
		public static readonly GUIContent TEXT_SMOOTHING_FACTOR = new GUIContent("Factor", "Indicates how much smoothing to apply. 0 - no smoothing, 100000 - maximum.");
		public static readonly GUIContent TEXT_POSITION_THRESHOLD = new GUIContent("Position Threshold", "Minimum distance between target position and smoothed position when to stop automatic movement.");
		public static readonly GUIContent TEXT_ROTATION_THRESHOLD = new GUIContent("Rotation Threshold", "Minimum angle between target rotation and smoothed rotation when to stop automatic movement.");
		public static readonly GUIContent TEXT_SCALE_THRESHOLD = new GUIContent("Scale Threshold", "Minimum difference between target scale and smoothed scale when to stop automatic movement.");
		public static readonly GUIContent TEXT_ALLOW_CHANGING = new GUIContent("Allow Changing From Outside", "Indicates if this transform can be changed from another script.");
		public static readonly GUIContent TEXT_SMOOTHING_FACTOR_DESC = new GUIContent("Indicates how much smoothing to apply. \n0 - no smoothing, 100000 - maximum.");

		private Transformer instance;

        private SerializedProperty enableSmoothing, allowChangingFromOutside;
//		private SerializedProperty smoothingFactor, positionThreshold, rotationThreshold, scaleThreshold;
		private PropertyInfo enableSmoothing_prop;

        protected virtual void OnEnable()
        {
            enableSmoothing = serializedObject.FindProperty("enableSmoothing");
//            smoothingFactor = serializedObject.FindProperty("smoothingFactor");
//            positionThreshold = serializedObject.FindProperty("positionThreshold");
//            rotationThreshold = serializedObject.FindProperty("rotationThreshold");
//            scaleThreshold = serializedObject.FindProperty("scaleThreshold");
            allowChangingFromOutside = serializedObject.FindProperty("allowChangingFromOutside");

            instance = target as Transformer;

			var type = instance.GetType();
			enableSmoothing_prop = type.GetProperty("EnableSmoothing", BindingFlags.Instance | BindingFlags.Public);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.UpdateIfDirtyOrScript();

			GUILayout.Space(5);

			var display = GUIElements.Header(TEXT_SMOOTHING_HEADER, enableSmoothing, enableSmoothing, enableSmoothing_prop);
			if (display)
			{
				EditorGUI.indentLevel++;
				using (new EditorGUI.DisabledGroupScope(!enableSmoothing.boolValue))
				{
					instance.SmoothingFactor = EditorGUILayout.FloatField(TEXT_SMOOTHING_FACTOR, instance.SmoothingFactor);
					EditorGUILayout.LabelField(TEXT_SMOOTHING_FACTOR_DESC, GUIElements.HelpBox);
					instance.PositionThreshold = EditorGUILayout.FloatField(TEXT_POSITION_THRESHOLD, instance.PositionThreshold);
					instance.RotationThreshold = EditorGUILayout.FloatField(TEXT_ROTATION_THRESHOLD, instance.RotationThreshold);
					instance.ScaleThreshold = EditorGUILayout.FloatField(TEXT_SCALE_THRESHOLD, instance.ScaleThreshold);
					EditorGUILayout.PropertyField(allowChangingFromOutside, TEXT_ALLOW_CHANGING);
				}
				EditorGUI.indentLevel--;
			}

            serializedObject.ApplyModifiedProperties();
        }

    }
}
