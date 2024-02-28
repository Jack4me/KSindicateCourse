using System.Collections.Generic;
using StaticData.Windows;
using UnityEngine;

namespace StaticData {
    [CreateAssetMenu(menuName = "StaticData/ Window Static Data", fileName = "Window Static Data")]
    public class WindowStaticData : ScriptableObject 
    {
        public List<WindowConfigData> ConfigsList;
    }
}