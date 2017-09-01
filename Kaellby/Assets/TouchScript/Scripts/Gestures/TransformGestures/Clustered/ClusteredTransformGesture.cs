﻿/*
 * @author Valentin Simonov / http://va.lent.in/
 */

using System.Collections.Generic;
using Assets.TouchScript.Scripts.Pointers;
using Assets.TouchScript.Scripts.Utils;
using UnityEngine;

namespace Assets.TouchScript.Scripts.Gestures.TransformGestures.Clustered
{
    /// <summary>
    /// TransformGesture which splits all pointers into 2 clusters and works with them.
    /// Should be used for large touch surfaces.
    /// </summary>
    [AddComponentMenu("TouchScript/Gestures/Clustered/Transform Gesture (Clustered)")]
    [HelpURL("http://touchscript.github.io/docs/html/T_TouchScript_Gestures_TransformGestures_Clustered_ClusteredTransformGesture.htm")]
    public class ClusteredTransformGesture : TransformGesture
    {
        #region Private variables

        private Clusters.Clusters2D clusters = new Clusters.Clusters2D();

        #endregion

        #region Gesture callbacks

        /// <inheritdoc />
        protected override void pointersPressed(IList<Pointer> pointers)
        {
            clusters.AddPoints(pointers);

            base.pointersPressed(pointers);
        }

        /// <inheritdoc />
        protected override void pointersUpdated(IList<Pointer> pointers)
        {
            clusters.Invalidate();

            base.pointersUpdated(pointers);
        }

        /// <inheritdoc />
        protected override void pointersReleased(IList<Pointer> pointers)
        {
            clusters.RemovePoints(pointers);

            base.pointersReleased(pointers);
        }

        /// <inheritdoc />
        protected override void reset()
        {
            base.reset();

            clusters.RemoveAllPoints();
        }

        #endregion

        #region Protected methods

        /// <inheritdoc />
        protected override int getNumPoints()
        {
            if (clusters.HasClusters) return 2;
            if (NumPointers > 0) return 1;
            return 0;
        }

        /// <inheritdoc />
        protected override bool relevantPointers1(IList<Pointer> pointers)
        {
            return true;
        }

        /// <inheritdoc />
        protected override bool relevantPointers2(IList<Pointer> pointers)
        {
            return true;
        }

        /// <inheritdoc />
        protected override Vector2 getPointScreenPosition(int index)
        {
            if (!clusters.HasClusters) return ClusterUtils.Get2DCenterPosition(activePointers);

            return clusters.GetCenterPosition(index);
        }

        /// <inheritdoc />
        protected override Vector2 getPointPreviousScreenPosition(int index)
        {
            if (!clusters.HasClusters) return ClusterUtils.GetPrevious2DCenterPosition(activePointers);

            return clusters.GetPreviousCenterPosition(index);
        }

        #endregion
    }
}