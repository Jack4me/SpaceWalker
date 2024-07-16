

using Input;
using Services.Input;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HeroSpace {
    public class HeroMove : MonoBehaviour{
        public CharacterController characterController;
        public float movementSpeed = 4.0f;
        public InputService _inputService;
        private Camera _camera;
        private const float EPSILON = 0.01f;

        public HeroMove Construct(){
            return this;
        }

        private void Awake() {
            _inputService = new StandaloneInputService();
        }

        private void Start(){
            _camera = Camera.main;
            CameraFollow(gameObject);
        }

        private void Update(){
            Vector3 movementVector = Vector3.zero;
            if (_inputService.Axis.sqrMagnitude > EPSILON){
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

       

       

        private static string CurrentLvL(){
            return SceneManager.GetActiveScene().name;
        }
    }
}
