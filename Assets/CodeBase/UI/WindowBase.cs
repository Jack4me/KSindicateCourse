﻿using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class WindowBase : MonoBehaviour {
        public Button CloseButton;

        private void Awake(){
            OnAwake();
        }

        protected virtual void OnAwake(){
            CloseButton.onClick.AddListener(() => Destroy(gameObject));
        }
    }
}