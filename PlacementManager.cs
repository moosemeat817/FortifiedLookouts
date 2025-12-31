using MelonLoader;
using UnityEngine;
using System.Collections;

namespace FortifiedLookouts
{
    public static class PlacementManager
    {
        public static void PlaceTerrain()
        {
            string mActiveScene = GameManager.m_ActiveScene;
            try
            {
                if (mActiveScene == "BlackrockPrisonSurvivalZone")
                {
                    void InstantiatePrefab(string prefabName, Vector3 position, Vector3 rotation, Vector3 scale)
                    {
                        GameObject prefab = GameObject.Find(prefabName);
                        SceneUtils.InstantiateObjectInScene(prefab, position, rotation, scale);
                    }

                    InstantiatePrefab("OBJ_FloodLightTall_A_Prefab (22)", new Vector3(-239.7088f, 224.4004f, 49.2276f), new Vector3(-0f, 181.5559f, 277.3775f), new Vector3(1f, 1f, 1f));
                }
            }
            catch (System.Exception ex)
            {
                MelonLogger.Error($"[FortifiedLookouts] Exception occurred while placing terrain: {ex.Message}\n{ex.StackTrace}");
            }
        }

        public static IEnumerator PlaceAssetsAsync()
        {
            string scene = GameManager.m_ActiveScene;

            if (scene == "CanneryRegion")
            {
                yield return PlaceAssetAsync("OBJ_WoodPlankSingle4",
                    new Vector3(302.7242f, 231.7492f, 353.5321f),
                    new Vector3(-0f, 107.6457f, 321.9999f),
                    new Vector3(0.58f, 1f, 1.9f));

                yield return PlaceAssetAsync("OBJ_WoodPlankSingle3",
                    new Vector3(303.3741f, 231.8493f, 355.7159f),
                    new Vector3(-0f, 287.6457f, 319.9999f),
                    new Vector3(0.528f, 1f, 1.9f));

                yield return PlaceAssetAsync("OBJ_WoodPlankSingle",
                    new Vector3(299.4398f, 227.8792f, 354.9771f),
                    new Vector3(0f, 195.9618f, -0.0002f),
                    new Vector3(1.68f, 7.9115f, 0.9183f));

                yield return PlaceAssetAsync("OBJ_WoodPlankSingle",
                    new Vector3(302.0853f, 227.882f, 349.9709f),
                    new Vector3(0f, 105.7767f, 0.0942f),
                    new Vector3(1.88f, 7.0006f, 0.8201f));
            }
            else if (scene == "LakeRegion")
            {
                yield return PlaceAssetAsync("OBJ_WoodPlankSingle",
                    new Vector3(791.0895f, 205.8441f, 962.8327f),
                    new Vector3(0.6783f, 180.3155f, 44.111f),
                    new Vector3(0.54f, 1f, 1.9f));

                yield return PlaceAssetAsync("OBJ_WoodPlankSingle",
                    new Vector3(789.41f, 206.0342f, 962.7426f),
                    new Vector3(0f, 357.2149f, 44.2419f),
                    new Vector3(0.398f, 1f, 1.9f));

                yield return PlaceAssetAsync("OBJ_WoodPlankSingle",
                    new Vector3(781.2923f, 202.2775f, 966.1724f),
                    new Vector3(0.6783f, 270.3227f, 359.7365f),
                    new Vector3(1.7677f, 7.5619f, 0.9f));
            }
            else if (scene == "CoastalRegion")
            {
                yield return PlaceAssetAsync("OBJ_WoodPlankSingle",
                    new Vector3(350.5297f, 195.9035f, 1162.417f),
                    new Vector3(0.6783f, 186.8532f, 41.1111f),
                    new Vector3(0.64f, 1f, 1.9f));

                yield return PlaceAssetAsync("OBJ_WoodPlankSingle",
                    new Vector3(348.4899f, 196.1236f, 1162.657f),
                    new Vector3(-0f, 9.1926f, 44.2419f),
                    new Vector3(0.448f, 1f, 1.9f));
            }
        }

        private static IEnumerator PlaceAssetAsync(string prefabName, Vector3 pos, Vector3 rot, Vector3 scale)
        {
            GameObject prefab = null;
            yield return AssetUtils.LoadPrefabAsync(prefabName, (go) => prefab = go);

            if (prefab != null)
            {
                SceneUtils.PlaceAssetsInScene(prefabName, pos, rot, scale);
            }
            else
            {
                MelonLogger.Warning($"[FortifiedLookouts] Failed to load prefab: {prefabName}");
            }
        }
    }
}