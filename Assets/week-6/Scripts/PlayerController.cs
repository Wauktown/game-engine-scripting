using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.Events;

namespace Week6
{

    
public class PlayerController : MonoBehaviour
{
        [SerializeField] float speed;
        [SerializeField] float jumpForce;
        [SerializeField] float rotationVertical = 5.0f;
        [SerializeField] float rotationHorizontal = 5.0f;
        
        public Vector3 startingPosition;

        public int health = 100;
        private HealthUI healthUI;

        private float mouseDeltaX = 0f;
        private float mouseDeltaY = 0f;
        private float cameraRotX = 0f;
        private int rotDir = 0;





        InputAction move;
        InputAction fire;
        InputAction jump;
        InputAction look;

        Rigidbody rb;

        PlayerControllerMapping playerMapping;

       private void Awake() 
        { 
            rb = GetComponent<Rigidbody>();

            playerMapping = new PlayerControllerMapping();
            move = playerMapping.Player.Move;
            
            fire = playerMapping.Player.Fire;
            fire.performed += Fire;

            jump = playerMapping.Player.Jump;
            jump.performed += Jump;

            look = playerMapping.Player.Look;
        }
      private void OnEnable()
        {

            move.Enable();
            fire.Enable();
            jump.Enable();
            look.Enable();

        }


        private void OnDisable()
        {
            move.Disable();
            fire.Disable();
            jump.Disable();
            look.Disable();



        }



        // Start is called before the first frame update
        private void Start()
        {
            healthUI = FindObjectOfType<HealthUI>();
            UpdateHealthUI();
            startingPosition = transform.position;
            GameManager.AddRestartEventListener(RestartPosition);

        }


        private void Update()
        {
            HandleHorizontalRotation();
            HandleVerticalRotation();
        }
        void HandleHorizontalRotation()
        {
            mouseDeltaX = look.ReadValue<Vector2>().x;

            if (mouseDeltaX != 0)
            {
                rotDir = mouseDeltaX > 0 ? 1 : -1;

                transform.eulerAngles += new Vector3(0, rotationHorizontal * Time.deltaTime * rotDir, 0);
            }
        }
       
        private void RestartPosition()
        {
            transform.position = startingPosition;
            health = 100; // Reset health
            UpdateHealthUI();


        }
        private void OnDestroy()
        {
            GameManager.RemoveRestartEventListener(RestartPosition);
        }
        void UpdateHealthUI()
        {
            healthUI.UpdateHealthText(health);
            if (health <= 0)
            {
                GameManager.instance.GameOver(); // Trigger game over if health reaches zero
            }
        }

        public void TakeDamage(int damageAmount)
        {
            health -= damageAmount;
            if (health < 0)
            {
                health = 0;
            }
            UpdateHealthUI();
        }

        void HandleVerticalRotation()
        {
            mouseDeltaY = look.ReadValue<Vector2>().y;
            if (mouseDeltaY != 0)
            {
                rotDir = mouseDeltaY > 0 ? -1 : 1;

                cameraRotX += rotationVertical * Time.deltaTime * rotDir;
                cameraRotX = Mathf.Clamp(cameraRotX, -45f, 45f);


                var targetRotation = Quaternion.Euler(Vector3.right * cameraRotX);

                Camera.main.transform.localRotation = targetRotation;
            }
        }


    // Update is called once per frame
    void FixedUpdate()
    {
            Vector2 input = move.ReadValue<Vector2>();
            Vector3 direction = (input.x * transform.right) + (transform.forward * input.y);
           
            transform.position = transform.position + (direction * speed * Time.deltaTime);
    }

        void Fire(InputAction.CallbackContext context)
        {

           

        }

        void Jump(InputAction.CallbackContext context)
        {

            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

        }



    }
    }
