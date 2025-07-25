using MelonLoader.Utils;
using UnityEngine.AddressableAssets;
using Il2CppSystem;
using UnityEngine.UIElements;
using UnityEngine;
using Il2Cpp;
using MelonLoader;


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
                    // Melonlogger.Msg("******************************PlaceTerrain BRP");
                    // Define a helper method to instantiate objects
                    void InstantiatePrefab(string prefabName, Vector3 position, Vector3 rotation, Vector3 scale)
                    {
                        GameObject prefab = GameObject.Find(prefabName);
                        SceneUtils.InstantiateObjectInScene(prefab, position, rotation, scale);
                    }

                    InstantiatePrefab("OBJ_FloodLightTall_A_Prefab (22)", new Vector3(-239.7088f, 224.4004f, 49.2276f), new Vector3(-0f, 181.5559f, 277.3775f), new Vector3(1f, 1f, 1f));
                }
               
                {
                    //Melonlogger.Msg($"Error: Unhandled scene '{mActiveScene}'. No terrain objects placed.");
                }
            }
            catch (System.Exception ex)
            {
                //Melonlogger.Msg($"Exception occurred while placing terrain: {ex.Message}\n{ex.StackTrace}");
            }
        }
        public static void PlaceAssets()
        {
            string scene = GameManager.m_ActiveScene;
            if (scene == "CanneryRegion")
            {

                // Placing OBJ_WoodPlankSingle
                Vector3 pos = new Vector3(302.7242f, 231.7492f, 353.5321f);
                Vector3 rot = new Vector3(-0f, 107.6457f, 321.9999f);
                Vector3 scale = new Vector3(0.58f, 1f, 1.9f);
                SceneUtils.PlaceAssetsInScene("OBJ_WoodPlankSingle4", pos, rot, scale);


                // Placing OBJ_WoodPlankSingle
                Vector3 pos2 = new Vector3(303.3741f, 231.8493f, 355.7159f);
                Vector3 rot2 = new Vector3(-0f, 287.6457f, 319.9999f);
                Vector3 scale2 = new Vector3(0.528f, 1f, 1.9f);
                SceneUtils.PlaceAssetsInScene("OBJ_WoodPlankSingle3", pos2, rot2, scale2);


                // Placing OBJ_WoodPlankSingle
                Vector3 pos3 = new Vector3(299.4398f, 227.8792f, 354.9771f);
                Vector3 rot3 = new Vector3(0f, 195.9618f, -0.0002f);
                Vector3 scale3 = new Vector3(1.68f, 7.9115f, 0.9183f);
                SceneUtils.PlaceAssetsInScene("OBJ_WoodPlankSingle", pos3, rot3, scale3);


                // Placing OBJ_WoodPlankSingle
                Vector3 pos4 = new Vector3(302.0853f, 227.882f, 349.9709f);
                Vector3 rot4 = new Vector3(0f, 105.7767f, 0.0942f);
                Vector3 scale4 = new Vector3(1.88f, 7.0006f, 0.8201f);
                SceneUtils.PlaceAssetsInScene("OBJ_WoodPlankSingle", pos4, rot4, scale4);


            }

            
            else if (scene == "LakeRegion")
            {

                // Placing OBJ_WoodPlankSingle
                Vector3 pos = new Vector3(791.0895f, 205.8441f, 962.8327f);
                Vector3 rot = new Vector3(0.6783f, 180.3155f, 44.111f);
                Vector3 scale = new Vector3(0.54f, 1f, 1.9f);
                SceneUtils.PlaceAssetsInScene("OBJ_WoodPlankSingle", pos, rot, scale);


                // Placing OBJ_WoodPlankSingle
                Vector3 pos2 = new Vector3(789.41f, 206.0342f, 962.7426f);
                Vector3 rot2 = new Vector3(0f, 357.2149f, 44.2419f);
                Vector3 scale2 = new Vector3(0.398f, 1f, 1.9f);
                SceneUtils.PlaceAssetsInScene("OBJ_WoodPlankSingle", pos2, rot2, scale2);


                // Placing OBJ_WoodPlankSingle
                Vector3 pos3 = new Vector3(781.2923f, 202.2775f, 966.1724f);
                Vector3 rot3 = new Vector3(0.6783f, 270.3227f, 359.7365f);
                Vector3 scale3 = new Vector3(1.7677f, 7.5619f, 0.9f);
                SceneUtils.PlaceAssetsInScene("OBJ_WoodPlankSingle", pos3, rot3, scale3);


            }

            else if (scene == "CoastalRegion")
            {

                // Placing OBJ_WoodPlankSingle
                Vector3 pos = new Vector3(350.5297f, 195.9035f, 1162.417f);
                Vector3 rot = new Vector3(0.6783f, 186.8532f, 41.1111f);
                Vector3 scale = new Vector3(0.64f, 1f, 1.9f);
                SceneUtils.PlaceAssetsInScene("OBJ_WoodPlankSingle", pos, rot, scale);


                // Placing OBJ_WoodPlankSingle
                Vector3 pos2 = new Vector3(348.4899f, 196.1236f, 1162.657f);
                Vector3 rot2 = new Vector3(-0f, 9.1926f, 44.2419f);
                Vector3 scale2 = new Vector3(0.448f, 1f, 1.9f);
                SceneUtils.PlaceAssetsInScene("OBJ_WoodPlankSingle", pos2, rot2, scale2);


            }

        }
    }
}
