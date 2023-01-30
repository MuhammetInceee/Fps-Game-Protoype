using UnityEngine;

namespace FPS.Systems.UserInput
{
    public class UserInputSystem : MonoBehaviour
    {
        private float _clickDur;
        
        public bool isClicking;


        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                isClicking = true;
                _clickDur += 0.2f;
            }
            
            Click();
        }

        private void Click()
        {
            if(!isClicking) return;

            _clickDur -= Time.deltaTime;

            if (_clickDur <= 0)
            {
                isClicking = false;
            }
        }
    }
}
