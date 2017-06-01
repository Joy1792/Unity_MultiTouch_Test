﻿/*
 * @author Valentin Simonov / http://va.lent.in/
 */

using TouchScript.Gestures.TransformGestures;
using UnityEditor;
using UnityEngine;

namespace TouchScript.Editor.Gestures.TransformGestures.Base
{
	internal class OnePointTransformGestureBaseEditor : TransformGestureBaseEditor
    {

		protected override void drawGeneral()
        {
            var typeValue = type.intValue;
            int newType = 0;
            EditorGUILayout.LabelField(TEXT_TYPE);
            EditorGUI.indentLevel++;
            EditorGUILayout.BeginVertical();
			if (EditorGUILayout.ToggleLeft(TEXT_TYPE_ROTATION,
                (typeValue & (int)TransformGesture.TransformType.Rotation) != 0))
                newType |= (int)TransformGesture.TransformType.Rotation;
			if (EditorGUILayout.ToggleLeft(TEXT_TYPE_SCALING,
                (typeValue & (int)TransformGesture.TransformType.Scaling) != 0))
                newType |= (int)TransformGesture.TransformType.Scaling;
            type.intValue = newType;
            EditorGUILayout.EndVertical();
			EditorGUI.indentLevel--;

			EditorGUIUtility.labelWidth = 160;
			EditorGUILayout.PropertyField(screenTransformThreshold, TEXT_SCREEN_TRANSFORM_THRESHOLD);

			base.drawGeneral();
        }

    }
}
