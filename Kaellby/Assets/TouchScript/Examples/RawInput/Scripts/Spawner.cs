﻿/*
 * @author Valentin Simonov / http://va.lent.in/
 */

using Assets.TouchScript.Scripts;
using UnityEngine;

namespace Assets.TouchScript.Examples.RawInput.Scripts
{
    /// <exclude />
    public class Spawner : MonoBehaviour
    {
        public GameObject Prefab;

        private void OnEnable()
        {
            if (TouchManager.Instance != null)
            {
                TouchManager.Instance.PointersPressed += pointersPressedHandler;
            }
        }

        private void OnDisable()
        {
            if (TouchManager.Instance != null)
            {
                TouchManager.Instance.PointersPressed -= pointersPressedHandler;
            }
        }

        private void spawnPrefabAt(Vector2 position)
        {
            var obj = Instantiate(Prefab) as GameObject;
            obj.transform.position = UnityEngine.Camera.main.ScreenToWorldPoint(new Vector3(position.x, position.y, 10));
            obj.transform.rotation = transform.rotation;
        }

        private void pointersPressedHandler(object sender, PointerEventArgs e)
        {
            foreach (var pointer in e.Pointers)
            {
                spawnPrefabAt(pointer.Position);
            }
        }
    }
}