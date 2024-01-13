using Data;
using Infrastructure.Services;
using Infrastructure.Services.Persistent;
using Services.Input;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hero {
    public class HeroMove : MonoBehaviour, ISaveProgress {
        public CharacterController characterController;
        public float movementSpeed = 4.0f;
        private IInputService _inputService;
        private Camera _camera;

        public HeroMove Construct(){
            return this;
        }

        private void Awake(){
            _inputService = AllServices.Container.GetService<IInputService>();
        }

        private void Start(){
            _camera = Camera.main;
            CameraFollow(gameObject);
        }

        private void Update(){
            Vector3 movementVector = Vector3.zero;
            if (_inputService.Axis.sqrMagnitude > Constants.Epsilon){
                //Трансформируем экранныые координаты вектора в мировые
                movementVector = _camera.transform.TransformDirection(_inputService.Axis);
                movementVector.y = 0;
                movementVector.Normalize();
                transform.forward = movementVector;
            }
            movementVector += Physics.gravity;
            characterController.Move(movementSpeed * movementVector * Time.deltaTime);
        }

        private void CameraFollow(GameObject Hero){
//            _camera.GetComponent<CameraFollow>().Follow(hero);
        }

        public void UpdateProgress(PlayerProgress PlayerProgress){
            PlayerProgress.WorldData.PositionAtLvL = new PositionAtLvL(CurrentLvL(), transform.position.AsVectorData());
        }

        public void LoadProgress(PlayerProgress PlayerProgress){
            if (CurrentLvL() == PlayerProgress.WorldData.PositionAtLvL.lvLName){
                Vector3Data savedPotion = PlayerProgress.WorldData.PositionAtLvL.position;
                if (savedPotion != null){
                    TransformTo(To: savedPotion);
                }
            }
        }

        private void TransformTo(Vector3Data To){
            characterController.enabled = false;
            transform.position = To.AsUnityVector().AddY(characterController.height);
            characterController.enabled = true;
        }

        private static string CurrentLvL(){
            return SceneManager.GetActiveScene().name;
        }
    }
}