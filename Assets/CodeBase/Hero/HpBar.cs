﻿using UnityEngine;
using UnityEngine.UI;

namespace Hero {
    public class HpBar : MonoBehaviour {
        public Image imageCurrent;

        public void SetValue(float Current, float Max){
            Debug.Log("IMAGE CURRENT");
            imageCurrent.fillAmount = Current / Max;
        }
    }
}