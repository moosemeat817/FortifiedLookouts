using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace FortifiedLookouts
{
    internal static class AssetUtils
    {
        static Dictionary<string, GameObject> cachedPrefabs = new Dictionary<string, GameObject>();

        public static GameObject GetPrefab(string prefabName)
        {
            if (!cachedPrefabs.ContainsKey(prefabName))
            {
                GeneratePrefab(prefabName);
            }
            else if (cachedPrefabs.ContainsKey(prefabName) && cachedPrefabs[prefabName] == null)
            {
                cachedPrefabs.Remove(prefabName);
                GeneratePrefab(prefabName);
            }
            // Return the prefab reference directly instead of instantiating it
            return cachedPrefabs[prefabName];
        }

        private static void GeneratePrefab(string prefabName)
        {
            GameObject go = new GameObject();
            go.name = prefabName;

            MeshFilter meshFilter = go.AddComponent<MeshFilter>();
            MeshRenderer meshRenderer = go.AddComponent<MeshRenderer>();
            MeshCollider meshCollider = go.AddComponent<MeshCollider>();

            switch (prefabName)
            {
                case "OBJ_WoodPlankSingle":
                    meshFilter.sharedMesh = Addressables.LoadAssetAsync<Mesh>("Assets/ArtAssets/Env/Structures/STR_CoastalHouseG/OBJ_WoodPlankSingle.fbx").WaitForCompletion();
                    meshRenderer.sharedMaterial = Addressables.LoadAssetAsync<Material>("Assets/ArtAssets/Materials/Global/GLB_WoodWallRed_F01.mat").WaitForCompletion();
                    meshCollider.sharedMesh = meshFilter.sharedMesh;
                    break;

                case "OBJ_WoodPlankSingle2":
                    meshFilter.sharedMesh = Addressables.LoadAssetAsync<Mesh>("Assets/ArtAssets/Env/Structures/STR_CoastalHouseG/OBJ_WoodPlankSingle.fbx").WaitForCompletion();
                    meshRenderer.sharedMaterial = Addressables.LoadAssetAsync<Material>("Assets/ArtAssets/Materials/Global/GLB_WoodWallNatural_M02_Snow.mat").WaitForCompletion();
                    meshCollider.sharedMesh = meshFilter.sharedMesh;
                    break;

                case "OBJ_WoodPlankSingle3":
                    meshFilter.sharedMesh = Addressables.LoadAssetAsync<Mesh>("Assets/ArtAssets/Env/Structures/STR_CoastalHouseG/OBJ_WoodPlankSingle.fbx").WaitForCompletion();
                    meshRenderer.sharedMaterial = Addressables.LoadAssetAsync<Material>("Assets/ArtAssets/Materials/Global/GLB_WoodWallNatural_M03.mat").WaitForCompletion();
                    meshCollider.sharedMesh = meshFilter.sharedMesh;
                    break;

                case "OBJ_WoodPlankSingle4":
                    meshFilter.sharedMesh = Addressables.LoadAssetAsync<Mesh>("Assets/ArtAssets/Env/Structures/STR_CoastalHouseG/OBJ_WoodPlankSingle.fbx").WaitForCompletion();
                    meshRenderer.sharedMaterial = Addressables.LoadAssetAsync<Material>("Assets/ArtAssets/Materials/Global/GLB_WoodWallNatural_M03_Snow.mat").WaitForCompletion();
                    meshCollider.sharedMesh = meshFilter.sharedMesh;
                    break;

            }

            cachedPrefabs.Add(prefabName, go);
        }
    }
}