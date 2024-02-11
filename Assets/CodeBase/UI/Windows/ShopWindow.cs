using TMPro;

namespace UI.Windows {
    public class ShopWindow : WindowBase {
        public TextMeshProUGUI textSkull;

        protected override void Initialize(){
            RefreshSkullText();
        }

        protected override void SubscribeUpdate(){
            PlayerProgress.WorldData.LootData.ChangedAction += RefreshSkullText;
        }

        protected override void CleanUp(){
            base.CleanUp();
            PlayerProgress.WorldData.LootData.ChangedAction -= RefreshSkullText;
        }

        private void RefreshSkullText(){
            textSkull.text = PlayerProgress.WorldData.LootData.Collected.ToString();
        }
    }
}