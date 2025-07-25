using MelonLoader.Utils;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace FortifiedLookouts
{
    public class Main : MelonMod
    {
        public override void OnInitializeMelon()
        {
            Settings.OnLoad();
        }

        private bool ShouldSkipScene(string sceneName)
        {
            if (string.IsNullOrEmpty(sceneName))
                return true;

            string lowerSceneName = sceneName.ToLowerInvariant();
            return lowerSceneName.Contains("boot") ||
                   lowerSceneName.Contains("empty") ||
                   lowerSceneName.Contains("menu");
        }

        private GameObject FindGameObjectSafely(string path)
        {
            try
            {
                return GameObject.Find(path);
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        private void SetTransformSafely(GameObject obj, Vector3 position, Vector3 rotation)
        {
            if (obj?.transform != null)
            {
                obj.transform.SetPositionAndRotation(position, Quaternion.Euler(rotation));
            }
        }

        private void SetScaleSafely(GameObject obj, Vector3 scale)
        {
            if (obj?.transform != null)
            {
                obj.transform.localScale = scale;
            }
        }

        private void SetActiveSafely(GameObject obj, bool active)
        {
            if (obj != null)
            {
                obj.SetActive(active);
            }
        }

        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            if (ShouldSkipScene(sceneName))
                return;

            string mActiveScene = GameManager.m_ActiveScene;

            if (sceneName == "LakeRegion" && Settings.options.mysteryLookout)
            {
                if (Settings.options.coastalMini)
                {
                    //CloneManager.ChangeObjects();
                    //PlacementManager.PlaceAssets();
                }

                // Disable all children containing "icicle" (case-insensitive)
                Utilities.DisableChildrenByNameContains("Art/Structures/STRSPAWN_ForesrtyLookoutLake_Prefab2", "icicle");
                Utilities.DisableChildrenByIndex("Scene Collision", new int[] { 0, 1, 2, 4, 5 });
            }
            else if (sceneName == "CanneryRegion" && Settings.options.bleakLookout)
            {
                if (Settings.options.bleakMini)
                {
                    //CloneManager.ChangeObjects();
                    PlacementManager.PlaceAssets();
                    Utilities.DisableChildrenByIndex("STRSPAWN_ForestryLookoutCannery_Prefab(Clone)", new int[] { 2, 13 });
                }
                // Disable all children containing "icicle" (case-insensitive)
                //Utilities.DisableChildrenByNameContains("Art/Structures/STRSPAWN_ForesrtyLookoutLake_Prefab2", "icicle");
                //Utilities.DisableChildrenByIndex("Scene Collision", new int[] { 0, 1, 2, 4, 5 });
            }
            else if (sceneName == "CoastalRegion" && Settings.options.coastalLookout)
            {
                if (Settings.options.coastalMini)
                {
                    //CloneManager.ChangeObjects();
                }

                //PlacementManager.PlaceAssets();

                // Disable all children containing "icicle" (case-insensitive)
                //Utilities.DisableChildrenByNameContains("Art/Structures/STRSPAWN_ForesrtyLookoutLake_Prefab2", "icicle");
                //Utilities.DisableChildrenByIndex("Scene Collision", new int[] { 0, 1, 2, 4, 5 });
            }
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (ShouldSkipScene(sceneName))
                return;

            if (sceneName == "LakeRegion" && Settings.options.mysteryLookout)
            {
                ProcessLakeRegion();
            }

            if (sceneName == "CanneryRegion" && Settings.options.bleakLookout)
            {
                ProcessCanneryRegion();
            }

            if (sceneName == "CoastalRegion" && Settings.options.coastalLookout)
            {
                ProcessCoastalRegion();
            }
        }

        private void ProcessLakeRegion()
        {

            var windKiller = FindGameObjectSafely("Design/Scripting/ParticleKillers/ShelteredWindKiller");
            SetTransformSafely(windKiller, new Vector3(785.4221f, 206.6555f, 966.0353f), new Vector3(-0, 0f, 0));

            var railCarKiller = FindGameObjectSafely("Art/Structures/Objects/RailCars_New/OBJ_RailCarA2DestroyedLegacy_Prefab/Terrain_ParticleKiller");
            SetTransformSafely(railCarKiller, new Vector3(785.4221f, 206.6555f, 966.0353f), new Vector3(-0, 0f, 0));

            var lookoutBase = FindGameObjectSafely("Art/Structures/STRSPAWN_ForesrtyLookoutLake_Prefab2/STR_ForestryLookoutLakeBase_Prefab");
            SetScaleSafely(lookoutBase, new Vector3(1.785f, 1.07f, 1.4f));
            SetTransformSafely(lookoutBase, new Vector3(789.3401f, 200.2799f, 967.07f), new Vector3(-0, 0f, 0));

            var hinge = FindGameObjectSafely("Art/Structures/STRSPAWN_ForesrtyLookoutLake_Prefab2/Hinge");
            SetScaleSafely(hinge, new Vector3(1f, 1.02f, 1.4f));
            SetTransformSafely(hinge, new Vector3(792.6357f, 214.015f, 963.442f), new Vector3(-0f, 179.8904f, 180));  // Offset -6.3093

            var antenna = FindGameObjectSafely("Art/STR_RadioAntennaA_02_Prefab");
            SetTransformSafely(antenna, new Vector3(786.066f, 215.7762f, 963.579f), new Vector3(0, 308.1196f, 0));

            // 6.5363 3.7477 5.7658 indoor space scale
            var indoorSpace = FindGameObjectSafely("Art/Structures/STRSPAWN_ForesrtyLookoutLake_Prefab2/Tech/IndoorSpace");
            SetScaleSafely(indoorSpace, new Vector3(11.1812f, 3.7477f, 8.3198f));
            SetTransformSafely(indoorSpace, new Vector3(787.1846f, 214.1074f, 967.0839f), new Vector3(0, 6.3093f, 0));

            // 6.0204 3.5044 6.0728
            var interiorTemp = FindGameObjectSafely("Design/Scripting/TRIGGER_InteriorTemperature");
            SetScaleSafely(interiorTemp, new Vector3(12.7968f, 3.7477f, 10.102f));
            SetTransformSafely(interiorTemp, new Vector3(788.86f, 214.53f, 966.86f), new Vector3(0, 6.3093f, 0));

            // 4.4732 3.6773 6.6366
            var tempIncrease = FindGameObjectSafely("Design/Scripting/TRIGGER_TemperatureIncrease");
            SetScaleSafely(tempIncrease, new Vector3(7.985f, 3.7477f, 9.291f));
            SetTransformSafely(tempIncrease, new Vector3(787f, 204.1f, 983.8f), new Vector3(0, 6.3093f, 0));

            var fallingSnowKiller = FindGameObjectSafely("Art/Structures/STRSPAWN_ForesrtyLookoutLake_Prefab2/Tech/FallingSnowParticleKiller");
            SetScaleSafely(fallingSnowKiller, new Vector3(13.672f, 6f, 10.8791f));

            var blowingSnowKiller = FindGameObjectSafely("Art/Structures/STRSPAWN_ForesrtyLookoutLake_Prefab2/Tech/BlowingSnowParticleKiller");
            SetScaleSafely(blowingSnowKiller, new Vector3(19.9464f, 6.1956f, 23.8681f));


            // Disable lights
            string[] lightPaths = {
                "Art/NewLights/OBJ_LightStandFloodA_Prefab (11)",
                "Art/NewLights/OBJ_LightStandFloodA_Prefab (10)",
                "Art/NewLights/OBJ_LightStandFloodA_Prefab (9)",
                "Art/NewLights/OBJ_LightStandFloodA_Prefab (8)",
                "Art/NewLights/OBJ_ExteriorFloodLights_Prefab (1)",
                "Art/NewLights/OBJ_ExteriorFloodLights_Prefab",
                "Art/NewLights/OBJ_TrailerCeilingLightA_Prefab (1)",
                "Art/NewLights/OBJ_TrailerCeilingLightA_Prefab"
            };

            foreach (string lightPath in lightPaths)
            {
                var light = FindGameObjectSafely(lightPath);
                SetActiveSafely(light, false);
            }

            if (Settings.options.mysteryWindows)
            {
                var window = FindGameObjectSafely("Art/Structures/STRSPAWN_ForesrtyLookoutLake_Prefab2/STR_ForestryLookoutLakeBase_Prefab/STR_ForestryLookout_Prefab/STR_ForestryLookout_Window");
                SetTransformSafely(window, new Vector3(789.3401f, 201.6096f, 967.07f), new Vector3(0, 0f, 0));
            }

            if (Settings.options.mysteryMini)
            {
                CloneManager.ChangeObjects();
                Utilities.DisableChildrenByIndex("STRSPAWN_ForestryLookoutCoastal_Prefab(Clone)", new int[] { 2, 4 });
                PlacementManager.PlaceAssets();
            }
        }

        private void ProcessCanneryRegion()
        {
            var lookoutBase = FindGameObjectSafely("Art/Structures/Lookout/STRSPAWN_ForestryLookoutCannery_Prefab/STR_ForestryLookoutLakeBase_Prefab");
            SetScaleSafely(lookoutBase, new Vector3(1.785f, 1.07f, 1.4f));
            SetTransformSafely(lookoutBase, new Vector3(298.5741f, 226.42f, 354.8993f), new Vector3(-0, 285.7286f, 0)); // Offset 105.7286

            var hinge = FindGameObjectSafely("Art/Structures/Lookout/STRSPAWN_ForestryLookoutCannery_Prefab/Hinge");
            SetTransformSafely(hinge, new Vector3(302.9935f, 240.1687f, 357.0857f), new Vector3(-0, 105.7286f, 180));
            SetScaleSafely(hinge, new Vector3(1, 1.03f, 1.4f));

            var indoorSpace = FindGameObjectSafely("Art/Structures/Lookout/STRSPAWN_ForestryLookoutCannery_Prefab/Tech/IndoorSpace");
            SetScaleSafely(indoorSpace, new Vector3(9.7363f, 4.2477f, 8.8658f));
            SetTransformSafely(indoorSpace, new Vector3(297.739f, 240.1474f, 352.8523f), new Vector3(0, 105.7286f, 0));

            var particleKiller = FindGameObjectSafely("Art/Structures/Lookout/STRSPAWN_ForestryLookoutCannery_Prefab/Tech/ParticleKiller");
            SetScaleSafely(particleKiller, new Vector3(14.027f, 5f, 10.0791f));
            SetTransformSafely(particleKiller, new Vector3(299.2114f, 240.6763f, 350.9491f), new Vector3(0, 105.7286f, 0));

            //GameObject.Find("Art/Rocks/TRN_RockSmall_04_Group_Win_Base_Prefab").gameObject.transform.localScale = new Vector3(1.4f, 1.4f, 1.4f);
            //GameObject.Find("Art/Rocks/TRN_RockSmall_04_Group_Win_Base_Prefab").transform.SetPositionAndRotation(new Vector3(297.5791f, 226.7976f, 380.4872f), Quaternion.Euler(new Vector3(4.3894f, 240.0457f, 8.4465f)));

            Utilities.DisableChildrenByIndex("Art/Structures/Lookout/STRSPAWN_ForestryLookoutCannery_Prefab", new int[] { 4, 5, 6, 7, 8, 9, 10, 11, 12 });  // Icicles

            if (Settings.options.bleakWindows)
            {
                var window = FindGameObjectSafely("Art/Structures/Lookout/STRSPAWN_ForestryLookoutCannery_Prefab/STR_ForestryLookoutLakeBase_Prefab/STR_ForestryLookout_Prefab/STR_ForestryLookout_Window");
                SetTransformSafely(window, new Vector3(298.5741f, 227.7496f, 354.8993f), new Vector3(0, 285.7286f, 0));
            }

            if (Settings.options.bleakMini)
            {
                CloneManager.ChangeObjects();
                Utilities.DisableChildrenByIndex("STRSPAWN_ForestryLookoutCannery_Prefab(Clone)", new int[] { 2, 13 });
                //PlacementManager.PlaceAssets();
            }
        }

        private void ProcessCoastalRegion()
        {
            var baseRocks = FindGameObjectSafely("Art/Terrain_Group/TRN_Rock_Group/TRN_RockMedGroupB_Win_Base_Prefab");
            SetScaleSafely(baseRocks, new Vector3(1.3f, 1.1f, 1f));
            SetTransformSafely(baseRocks, new Vector3(346.6133f, 184.8203f, 1165.177f), new Vector3(356.6677f, 176.2901f, 14.5291f));

            var baseRocks2 = FindGameObjectSafely("Art/Terrain_Group/TRN_Rock_Group/TRN_RockMedGroupB_Win_Base_Prefab (5)");
            SetScaleSafely(baseRocks2, new Vector3(1.3f, 1.3f, 1f));
            SetTransformSafely(baseRocks2, new Vector3(362.0393f, 185.7202f, 1160.472f), new Vector3(356.6677f, 197.2901f, 14.5291f));

            var lookoutBase = FindGameObjectSafely("Art/Structure_Group/STRSPAWN_ForestryLookoutCoastal_Prefab/STR_ForestryLookoutLakeBase_Prefab");
            SetTransformSafely(lookoutBase, new Vector3(349.532f, 190.6899f, 1158.135f), new Vector3(-0, 191.1833f, 0));
            SetScaleSafely(lookoutBase, new Vector3(1.785f, 1.07f, 1.4f));

            var rock = FindGameObjectSafely("Art/Terrain_Group/TRN_Rock_Group/TRN_RockMedGroupA_Win_Base_Prefab (3)");
            SetActiveSafely(rock, false);

            Utilities.DisableChildrenByIndex("Art/Structure_Group/STRSPAWN_ForestryLookoutCoastal_Prefab/", new int[] { 4, 5, 6, 7, 8, 9, 10, 11, 12 });  // Icicles

            var hinge = FindGameObjectSafely("Art/Structure_Group/STRSPAWN_ForestryLookoutCoastal_Prefab/Hinge");
            SetScaleSafely(hinge, new Vector3(1, 1.03f, 1.4f));
            SetTransformSafely(hinge, new Vector3(346.988f, 204.4127f, 1162.364f), new Vector3(-0, 11.1645f, 180));

            // 6.5363 3.7477 5.7658
            var indoorSpace = FindGameObjectSafely("Art/Structure_Group/STRSPAWN_ForestryLookoutCoastal_Prefab/Tech/IndoorSpace");
            SetScaleSafely(indoorSpace, new Vector3(11.667f, 3.7477f, 8.072f));
            SetTransformSafely(indoorSpace, new Vector3(351.4609f, 204.3371f, 1157.769f), new Vector3(0, 191.1829f, 0));  // Offset

            // 6.972 4.5 7.2791
            var particleKiller = FindGameObjectSafely("Art/Structure_Group/STRSPAWN_ForestryLookoutCoastal_Prefab/Tech/ParticleKiller");
            SetScaleSafely(particleKiller, new Vector3(18.972f, 4.5f, 7.2791f));
            //GameObject.Find("Art/Structure_Group/STRSPAWN_ForestryLookoutCoastal_Prefab/Tech/ParticleKiller").transform.SetPositionAndRotation(new Vector3(357.5925f, 204.3371f, 1157.769f), Quaternion.Euler(new Vector3(0, 191.1829f, 0)));  // Offset

            //CloneManager.ChangeObjects();

            if (Settings.options.coastalWindows)
            {
                var window = FindGameObjectSafely("Art/Structure_Group/STRSPAWN_ForestryLookoutCoastal_Prefab/STR_ForestryLookoutLakeBase_Prefab/STR_ForestryLookout_Prefab/STR_ForestryLookout_Window");
                SetTransformSafely(window, new Vector3(349.532f, 192.0193f, 1158.135f), new Vector3(0, 191.1833f, 0));
            }

            if (Settings.options.coastalMini)
            {
                CloneManager.ChangeObjects();
                //Utilities.DisableChildrenByIndex("STRSPAWN_ForestryLookoutCoastal_Prefab(Clone)", new int[] { 2, 13 });
                PlacementManager.PlaceAssets();
            }
        }
    }
}