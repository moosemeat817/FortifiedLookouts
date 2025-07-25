using System;
using UnityEngine;

namespace FortifiedLookouts
{
    internal class SceneUtils
    {
        private const string INSTANTIATE_PREFIX = "XXX_";
        private const string PLACEMENT_PREFIX = "ZZZ_";

        /// <summary>
        /// Instantiates an object in the scene with optional collider.
        /// </summary>
        public static void InstantiateObjectInScene(GameObject prfb, Vector3 pos, Vector3 rot, Vector3 scale)
        {
            CreateAndPlaceObject(prfb, pos, rot, scale, INSTANTIATE_PREFIX, autoAddCollider: true);
        }

        /// <summary>
        /// Places a named prefab asset into the scene.
        /// </summary>
        public static void PlaceAssetsInScene(string name, Vector3 pos, Vector3 rot, Vector3 scale)
        {
            GameObject prfb = AssetUtils.GetPrefab(name);
            CreateAndPlaceObject(prfb, pos, rot, scale, PLACEMENT_PREFIX, autoAddCollider: false);
        }

        /// <summary>
        /// Central method for creating, transforming, and optionally adding a collider to a GameObject.
        /// </summary>
        private static GameObject CreateAndPlaceObject(GameObject prfb, Vector3 pos, Vector3 rot, Vector3 scale, string namePrefix, bool autoAddCollider)
        {
            if (prfb == null)
                return null;

            GameObject go = UnityEngine.Object.Instantiate(prfb);
            go.transform.position = pos;
            go.transform.rotation = Quaternion.Euler(rot);
            go.transform.localScale = scale;
            go.name = namePrefix + go.name;

            if (autoAddCollider && go.GetComponent<Collider>() == null)
            {
                go.AddComponent<MeshCollider>();
            }

            return go;
        }
    }
}
