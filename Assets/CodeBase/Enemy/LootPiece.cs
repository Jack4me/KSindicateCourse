using System;
using System.Collections;
using Data;
using TMPro;
using UnityEngine;

namespace Enemy {
    public class LootPiece : MonoBehaviour {
        public TextMeshPro lootText;
        public GameObject lootFXPrefab;
        public GameObject PickUpPopUp;
        public GameObject Skull;

        private Loot _loot;
        private bool _picked;
        private WorldData _worldData;

        public void Construct(WorldData worldData){
            _worldData = worldData;
        }

        public void Initialize(Loot loot){
            _loot = loot;
        }

        private void OnTriggerEnter(Collider other){
            PickUp();
        }

        private void PickUp(){
            if (_picked){
                return;
            }
            _picked = true;
            
            UpdateWorldData();
            HideSkull();
            ShowText();
            PlayPickUpFX();
            StartCoroutine(DestroyGameObject());
        }

        private void UpdateWorldData(){
            _worldData.LootData.Collect(_loot);
        }

        private void HideSkull(){
            Skull.SetActive(false);
        }

        private void PlayPickUpFX(){
            Instantiate(lootFXPrefab, transform.position, Quaternion.identity);
        }

        private void ShowText(){
            lootText.text = $"{_loot.Value}";
            PickUpPopUp.SetActive(true);
        }

        private IEnumerator DestroyGameObject(){
            yield return new WaitForSeconds(1.5f);
            Destroy(gameObject);
        }
    }
}