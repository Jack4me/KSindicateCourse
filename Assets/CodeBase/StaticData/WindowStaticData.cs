using System.Collections.Generic;
using UnityEngine;

namespace StaticData {
    [CreateAssetMenu(menuName = "StaticData/ Window Static Data", fileName = "Window Static Data")]
    public class WindowStaticData : ScriptableObject 
    {
        public List<WindowConfig> WindowConfigsList;
    }
}