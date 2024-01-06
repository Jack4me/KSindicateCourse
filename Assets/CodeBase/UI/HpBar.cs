using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class HpBar : MonoBehaviour {
        public Image imageCurrent;

        public void SetValue(float Current, float Max){
            imageCurrent.fillAmount = Current / Max;
        }
    }
}