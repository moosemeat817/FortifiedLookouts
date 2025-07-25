using System;
using UnityEngine;

namespace FortifiedLookouts
{
    public class CloneManager : MonoBehaviour
    {
        public static string[,] itemDataArray =
        {
            {"0_Scene", "1_Path"},
            {"LakeRegion", "STR_ForestryLookoutLakeBase_Prefab"},
            {"LakeRegion", "Art/Structures/STRSPAWN_ForesrtyLookoutLake_Prefab2/Hinge"},
            {"LakeRegion", "IndoorSpace"},
            {"LakeRegion", "CabinParticleKiller"},
            {"LakeRegion", "TRIGGER_InteriorTemperature"},
            {"LakeRegion", "TRIGGER_TemperatureIncrease"},          

            {"CanneryRegion", "STRSPAWN_ForestryLookoutCannery_Prefab"},

            {"CoastalRegion", "STR_ForestryLookoutLakeBase_Prefab"},
            {"CoastalRegion", "Art/Structure_Group/STRSPAWN_ForestryLookoutCoastal_Prefab/Hinge"},
            {"CoastalRegion", "IndoorSpace"},
            {"CoastalRegion", "TRN_RockMedGroupB_Win_Base_Prefab"},
            {"CoastalRegion", "ParticleKiller"},

        };

        public static void ChangeObjects()
        {
            for (int i = 1; i < itemDataArray.GetLength(0); i++)
            {
                GameObject findTargetGO = FindGameObjectByPath(itemDataArray[i, 1], itemDataArray[i, 0]);
                if (findTargetGO == null)
                    continue;

                string sceneName = itemDataArray[i, 0];
                string objectPath = itemDataArray[i, 1];

                switch (sceneName)
                {
                    case "LakeRegion":
                        HandleLakeRegion(findTargetGO, objectPath);
                        break;
                    case "CanneryRegion":
                        HandleCanneryRegion(findTargetGO, objectPath);
                        break;
                    case "CoastalRegion":
                        HandleCoastalRegion(findTargetGO, objectPath);
                        break;
                }
            }
        }

        /// <summary>
        /// Finds a GameObject by its hierarchical path or name within a specific scene
        /// </summary>
        /// <param name="path">Either a simple name or hierarchical path like "Parent/Child/Target"</param>
        /// <param name="sceneName">Name of the scene to search in</param>
        /// <returns>The found GameObject or null if not found</returns>
        private static GameObject FindGameObjectByPath(string path, string sceneName)
        {
            // If path doesn't contain '/', treat it as a simple name search
            if (!path.Contains("/"))
            {
                GameObject simpleFind = GameObject.Find(path);
                if (simpleFind != null && simpleFind.scene.name == sceneName)
                    return simpleFind;
                return null;
            }

            // Get the scene and validate it
            UnityEngine.SceneManagement.Scene scene = UnityEngine.SceneManagement.SceneManager.GetSceneByName(sceneName);

            // Check if the scene is valid and loaded
            if (!scene.IsValid() || !scene.isLoaded)
            {
                Debug.LogWarning($"Scene '{sceneName}' is not valid or not loaded yet.");
                return null;
            }

            // Split the path into segments
            string[] pathSegments = path.Split('/');

            // Get root objects from the validated scene
            GameObject[] rootObjects;
            try
            {
                rootObjects = scene.GetRootGameObjects();
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"Failed to get root objects from scene '{sceneName}': {ex.Message}");
                return null;
            }

            foreach (GameObject rootObj in rootObjects)
            {
                GameObject result = SearchInHierarchy(rootObj, pathSegments, 0);
                if (result != null)
                    return result;
            }

            return null;
        }

        /// <summary>
        /// Recursively searches through the GameObject hierarchy to find the target path
        /// </summary>
        /// <param name="current">Current GameObject being examined</param>
        /// <param name="pathSegments">Array of path segments to match</param>
        /// <param name="currentIndex">Current index in the path segments</param>
        /// <returns>The found GameObject or null if not found</returns>
        private static GameObject SearchInHierarchy(GameObject current, string[] pathSegments, int currentIndex)
        {
            // If we've reached the end of the path and the current object matches, we found it
            if (currentIndex >= pathSegments.Length)
                return current;

            // Check if current GameObject name matches the current path segment
            if (current.name == pathSegments[currentIndex])
            {
                // If this is the last segment, we found our target
                if (currentIndex == pathSegments.Length - 1)
                    return current;

                // Otherwise, search children for the next segment
                for (int i = 0; i < current.transform.childCount; i++)
                {
                    GameObject child = current.transform.GetChild(i).gameObject;
                    GameObject result = SearchInHierarchy(child, pathSegments, currentIndex + 1);
                    if (result != null)
                        return result;
                }
            }
            else
            {
                // Current name doesn't match, but continue searching children
                // This allows for partial path matching (e.g., starting from any level)
                for (int i = 0; i < current.transform.childCount; i++)
                {
                    GameObject child = current.transform.GetChild(i).gameObject;
                    GameObject result = SearchInHierarchy(child, pathSegments, currentIndex);
                    if (result != null)
                        return result;
                }
            }

            return null;
        }

        private static void HandleLakeRegion(GameObject original, string objectPath)
        {
            string objectName = GetObjectNameFromPath(objectPath);

            switch (objectName)
            {
                case "STR_ForestryLookoutLakeBase_Prefab":
                    CreateCloneIfNotExists(original, "STR_ForestryLookoutLakeBase_Prefab(Clone)",
                        new Vector3(785.7615f, 193.6394f, 967.1845f),
                        Quaternion.Euler(1.2f, 270.173f, -0f),
                        new Vector3(0.98f, 1f, 1.07f));
                    break;
                case "Hinge":
                    CreateCloneIfNotExists(original, "Hinge(Clone)",
                        new Vector3(788.2664f, 206.5442f, 968.9703f),
                        Quaternion.Euler(358.5982f, 90.8289f, 180f),
                        new Vector3(0.98f, .95f, 1.07f));
                    break;
                case "IndoorSpace":
                    CreateCloneIfNotExists(original, "IndoorSpace(Clone)",
                        new Vector3(785.4222f, 206.6555f, 966.0353f),
                        Quaternion.Euler(0f, 0f, 0f),
                        new Vector3(6.5363f, 3.7477f, 5.7658f));
                    break;
                case "CabinParticleKiller":
                    CreateCloneIfNotExists(original, "CabinParticleKiller(Clone)",
                        new Vector3(785.4221f, 206.6555f, 966.0353f),
                        Quaternion.Euler(0f, 0f, 0f),
                        new Vector3(5.9343f, 3.0152f, 5.4935f));
                    break;               
                case "TRIGGER_InteriorTemperature":
                    CreateCloneIfNotExists(original, "TRIGGER_InteriorTemperature(Clone)",
                        new Vector3(785.4222f, 206.6555f, 966.0353f),
                        Quaternion.Euler(0f, 0f, 0f),
                        new Vector3(6.0204f, 3.5044f, 6.0728f));
                    break;

                    /*
                case "TRIGGER_TemperatureIncrease":
                    CreateCloneIfNotExists(original, "TRIGGER_TemperatureIncrease(Clone)",
                        new Vector3(785.4222f, 206.6555f, 966.0353f),
                        Quaternion.Euler(0f, 0f, 0f),
                        new Vector3(4.4732f, 3.6773f, 6.6366f));
                    break;
                    */
                
            }
        }

        private static void HandleCanneryRegion(GameObject original, string objectPath)
        {
            string objectName = GetObjectNameFromPath(objectPath);

            switch (objectName)
            {
                case "STRSPAWN_ForestryLookoutCannery_Prefab":
                    CreateCloneIfNotExists(original, "STRSPAWN_ForestryLookoutCannery_Prefab(Clone)",
                        new Vector3(299.0676f, 219.4258f, 352.1711f),
                        Quaternion.Euler(0f, 15.807f, 0f),
                        new Vector3(0.54f, 1f, 0.77f));
                    break;
            }
        }

        private static void HandleCoastalRegion(GameObject original, string objectPath)
        {
            string objectName = GetObjectNameFromPath(objectPath);

            switch (objectName)
            {
                case "STR_ForestryLookoutLakeBase_Prefab":
                    CreateCloneIfNotExists(original, "STR_ForestryLookoutLakeBase_Prefab(Clone)",
                        new Vector3(353.3963f, 183.3181f, 1157.235f),
                        Quaternion.Euler(0f, 101.3755f, 0f),
                        new Vector3(0.98f, 1f, 1.07f));
                    break;
                case "Hinge":
                    // Now you can handle the specific Hinge from the path
                    CreateCloneIfNotExists(original, "Hinge(Clone)",
                        new Vector3(350.2995f, 196.1587f, 1156.035f),
                        Quaternion.Euler(359.9853f, 281.437f, 180.0012f),
                        new Vector3(0.98f, .95f, 1.07f));
                    break;
                case "IndoorSpace":
                    CreateCloneIfNotExists(original, "IndoorSpace(Clone)",
                        new Vector3(353.5035f, 196.1387f, 1158.487f),
                        Quaternion.Euler(0f, 0f, 0f),
                        new Vector3(5.9363f, 3.7477f, 5.1658f));
                    break;
                case "ParticleKiller":
                    CreateCloneIfNotExists(original, "ParticleKiller(Clone)",
                        new Vector3(353.5035f, 196.1387f, 1158.487f),
                        Quaternion.Euler(0f, 0f, 0f),
                        new Vector3(18.972f, 4.5f, 25.2791f));
                    break;
                case "TRN_RockMedGroupB_Win_Base_Prefab":
                    CreateCloneIfNotExists(original, "TRN_RockMedGroupB_Win_Base_Prefab(Clone)",
                        new Vector3(353.8506f, 188.6752f, 1153.284f),
                        Quaternion.Euler(9.6676f, 40.4082f, 20.529f),
                        new Vector3(0.3f, 0.4f, 0.3f));

                    CreateCloneIfNotExists(original, "TRN_RockMedGroupB_Win_Base_Prefab2(Clone)",
                        new Vector3(357.3223f, 188.6929f, 1154.773f),
                        Quaternion.Euler(30.6677f, 197.2901f, 14.5291f),
                        new Vector3(0.5f, 0.5f, 0.5f));

                    CreateCloneIfNotExists(original, "TRN_RockMedGroupB_Win_Base_Prefab3(Clone)",
                        new Vector3(356.3156f, 188.2712f, 1153.416f),
                        Quaternion.Euler(43.1267f, 191.9099f, 14.5292f),
                        new Vector3(0.5f, 0.6f, 0.5f));
                    break;

                    /*
                    case "ParticleKiller":
                        CreateCloneIfNotExists(original, "ParticleKiller(Clone)",
                            new Vector3(353.5035f, 196.1387f, 1158.487f),
                            Quaternion.Euler(0f, 0f, 0f),
                            new Vector3(6.972f, 4.5f, 7.2791f));
                        break;
                    */
            }
        }

        /// <summary>
        /// Extracts the object name from a path (the last segment)
        /// </summary>
        /// <param name="path">Full path or simple name</param>
        /// <returns>The object name</returns>
        private static string GetObjectNameFromPath(string path)
        {
            if (!path.Contains("/"))
                return path;

            string[] segments = path.Split('/');
            return segments[segments.Length - 1];
        }

        private static void CreateCloneIfNotExists(GameObject original, string cloneName, Vector3 position,
            Quaternion rotation, Vector3? scale = null, Action<GameObject> postSetup = null)
        {
            if (GameObject.Find(cloneName) != null)
                return;

            GameObject clone = Instantiate(original, position, rotation);
            clone.name = cloneName;

            if (scale.HasValue)
                clone.transform.localScale = scale.Value;

            postSetup?.Invoke(clone);
        }
    }
}