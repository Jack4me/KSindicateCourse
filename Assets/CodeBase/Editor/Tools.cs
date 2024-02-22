using UnityEditor;
using UnityEngine;

namespace CodeBase.Editor {
    public class Tools : MonoBehaviour
    {
        [MenuItem("Tools/CreatePrefs")]
        public static void ClearPrefs(){
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }


    }
}
