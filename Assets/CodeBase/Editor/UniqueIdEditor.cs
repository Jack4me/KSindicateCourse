using System;
using System.Linq;
using Enemy;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace CodeBase.Editor {
    [CustomEditor(typeof(UniqueID))]
    public class UniqueIdEditor : UnityEditor.Editor {
        private void OnEnable(){
            UniqueID uniqID = (UniqueID)target;
            if (string.IsNullOrEmpty(uniqID.ID)){
                Generate(uniqID);
            }
            else{
               UniqueID[] uniqueIDs = FindObjectsOfType<UniqueID>();
               if (uniqueIDs.Any(other => other != uniqID && other.ID == uniqID.ID)){
                   Generate(uniqID);

               }
            }
        }

        private void Generate(UniqueID uniqueId){
            uniqueId.ID = $"{uniqueId.gameObject.scene.name}_{Guid.NewGuid().ToString()}";
            if (!Application.isPlaying){
                EditorUtility.SetDirty(uniqueId);
                EditorSceneManager.MarkSceneDirty(uniqueId.gameObject.scene);
            }
        }
    }
}