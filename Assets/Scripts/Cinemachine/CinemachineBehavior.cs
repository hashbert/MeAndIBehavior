using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class CinemachineBehavior : MonoBehaviour
{
    //[SerializeField] private InputAction switchAction;

    private Animator animator;
    private Animator kidAnim;
    private bool cameraOnKid = true;
    
    private float desiredDuration = 0.5f;
    private float elapsedTime;

    //grabbing vcam orthographic size components to adjust zoom using mouse wheel
    private CinemachineVirtualCamera vCamKid;
    private CinemachineVirtualCamera vCamAdult;
    [SerializeField] private float maxOrthographicSize = 7;
    [SerializeField] private float minOrthographicSize = 5;
    private float zoomStepSize = 0.75f;
    private SwitchCharacter switchCharacter;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        kidAnim = GameObject.Find("Kid").GetComponent<Animator>();
        vCamKid = transform.Find("CM vcam Kid").GetComponent<CinemachineVirtualCamera>();
        vCamAdult = transform.Find("CM vcam Adult").GetComponent<CinemachineVirtualCamera>();
        switchCharacter = GameObject.Find("Managers").transform.Find("SwitchCharacter").GetComponent<SwitchCharacter>();
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
            if (switchCharacter.KidActive)
            {
                animator.Play("KidCam");
            }
            else if (!switchCharacter.KidActive)
            {
                animator.Play("AdultCam");
            }
        }
    }
    //public void OnSwitchState(InputAction.CallbackContext context)
    //{
    //    if (context.started)
    //    {
    //        if (kidAnim.GetInteger("KidState") != 0)
    //        {
    //            return;
    //        }
    //        if (cameraOnKid)
    //        {
    //            animator.Play("AdultCam");
    //        }
    //        else
    //        {
    //            animator.Play("KidCam");
    //        }
    //        cameraOnKid = !cameraOnKid;
    //    }
    //}

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
        if (zoom.y > 0f && vCamKid.m_Lens.OrthographicSize > minOrthographicSize)
        {
            vCamKid.m_Lens.OrthographicSize -= zoomStepSize;
            vCamAdult.m_Lens.OrthographicSize -= zoomStepSize;

            //vCamKid.m_Lens.OrthographicSize = Mathf.Lerp(vCamKid.m_Lens.OrthographicSize, vCamKid.m_Lens.OrthographicSize - zoomStepSize, lerpFraction);
            //vCamAdult.m_Lens.OrthographicSize = Mathf.Lerp(vCamKid.m_Lens.OrthographicSize, vCamKid.m_Lens.OrthographicSize - zoomStepSize, lerpFraction);
        }
        //zoom out
        else if (zoom.y < 0f && vCamKid.m_Lens.OrthographicSize < maxOrthographicSize)
        {
            vCamKid.m_Lens.OrthographicSize += zoomStepSize;
            vCamAdult.m_Lens.OrthographicSize += zoomStepSize;

            //vCamKid.m_Lens.OrthographicSize = Mathf.Lerp(vCamKid.m_Lens.OrthographicSize, vCamKid.m_Lens.OrthographicSize + zoomStepSize, lerpFraction);
            //vCamAdult.m_Lens.OrthographicSize = Mathf.Lerp(vCamKid.m_Lens.OrthographicSize, vCamKid.m_Lens.OrthographicSize + zoomStepSize, lerpFraction);
        }
    }

}
