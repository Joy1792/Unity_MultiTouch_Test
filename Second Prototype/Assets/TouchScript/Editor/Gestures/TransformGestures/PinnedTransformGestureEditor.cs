﻿/*
 * @author Valentin Simonov / http://va.lent.in/
 */

using TouchScript.Editor.Gestures.TransformGestures.Base;
using TouchScript.Gestures.TransformGestures;
using UnityEditor;
using UnityEngine;
using TouchScript.Editor.Utils;

namespace TouchScript.Editor.Gestures.TransformGestures
{
    [CustomEditor(typeof(PinnedTransformGesture), true)]
    internal class PinnedTransformGestureEditor : OnePointTransformGestureBaseEditor
    {
		public SerializedProperty projection, projectionPlaneNormal;
		public SerializedProperty projectionProps;

        protected override void OnEnable()
        {
            projection = serializedObject.FindProperty("projection");
            projectionPlaneNormal = serializedObject.FindProperty("projectionPlaneNormal");

			projectionProps = serializedObject.FindProperty("projectionProps");

			base.OnEnable();
        }

		protected override void drawOtherGUI()
		{
			var display = GUIElements.Header(TEXT_PROJECTION_HEADER, projectionProps);
			if (display)
			{
				EditorGUI.indentLevel++;
				EditorGUILayout.PropertyField(projection, TEXT_PROJECTION);
				if (projection.enumValueIndex != (int)TransformGesture.ProjectionType.Layer)
				{
					EditorGUILayout.PropertyField(projectionPlaneNormal, TEXT_PROJECTION_NORMAL);
				}
				EditorGUI.indentLevel--;
			}
		}

    }
}
