using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using UnityEngine.SceneManagement;

public class CinemachineBehavior : MonoBehaviour
{
    //[SerializeField] private InputAction switchAction;
    private SwitchCharacter switchCharacter; //to find which character is active
    private Animator animator;
    private int camNum = 0;
    private float wholeLevelShownTime = 2f;
    private float transitionToKidTime = 2f;
    private float switchCameraTime = 1f;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        switchCharacter = GameObject.Find("Managers").transform.Find("SwitchCharacter").GetComponent<SwitchCharacter>();
        if (SceneManager.GetActiveScene().name != "Level01")
        {
            StartCoroutine(BeginLevel());
        }
        else
        {
            animator.Play("KidCam0");
        }
    }

    private IEnumerator BeginLevel()
    {
        InputManager.playerInput.DeactivateInput();
        animator.Play("Level");
        animator.gameObject.GetComponent<CinemachineStateDrivenCamera>().m_DefaultBlend.m_Time = transitionToKidTime;
        yield return new WaitForSeconds(wholeLevelShownTime);
        SwitchCamera();
        yield return new WaitForSeconds(transitionToKidTime);
        animator.gameObject.GetComponent<CinemachineStateDrivenCamera>().m_DefaultBlend.m_Time = switchCameraTime;
        InputManager.playerInput.ActivateInput();
    }
    // Start is called before the first frame update
    void Start()
    {
        //switchAction.performed += context => SwitchState();
    }

    public void OnSwitchState(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SwitchCamera();
        }
    }

    private void SwitchCamera()
    {
        if (switchCharacter.KidActive)
        {
            animator.Play("KidCam" + camNum);
        }
        else if (!switchCharacter.KidActive)
        {
            animator.Play("AdultCam" + camNum);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //private void OnEnable()
    //{
    //    switchAction.Enable();
    //}
    //private void OnDisable()
    //{
    //    switchAction.Disable();
    //}

    public void OnZoom(InputAction.CallbackContext context)
    {
        var zoom = context.ReadValue<Vector2>();
        //zoom in
        if (zoom.y > 0f && camNum>0 && camNum<=3)
        {
            camNum -= 1;
            SwitchCamera();
        }
        //zoom out
        else if (zoom.y < 0f && camNum>=0 && camNum<3)
        {
            camNum += 1;
            SwitchCamera();
        }
    }

}
