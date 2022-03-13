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

    //grabbing vcam orthographic size components to adjust zoom using mouse wheel
    private CinemachineVirtualCamera vCamKid;
    private CinemachineVirtualCamera vCamAdult;

    //[SerializeField] private float maxOrthographicSize = 7;
    //[SerializeField] private float minOrthographicSize = 5;
    //private float zoomStepSize = 0.75f;
    private SwitchCharacter switchCharacter;

    private CinemachineVirtualCamera vCamKid1;
    private CinemachineVirtualCamera vCamAdult1;
    private CinemachineVirtualCamera vCamKid2;
    private CinemachineVirtualCamera vCamAdult2;
    private CinemachineVirtualCamera vCamKid3;
    private CinemachineVirtualCamera vCamAdult3;

    private int camNum = 0;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        vCamKid = transform.Find("CM vcam Kid").GetComponent<CinemachineVirtualCamera>();
        vCamAdult = transform.Find("CM vcam Adult").GetComponent<CinemachineVirtualCamera>();
        switchCharacter = GameObject.Find("Managers").transform.Find("SwitchCharacter").GetComponent<SwitchCharacter>();

        vCamKid1 = transform.Find("CM vcam Kid").GetComponent<CinemachineVirtualCamera>();
        vCamAdult1 = transform.Find("CM vcam Adult").GetComponent<CinemachineVirtualCamera>();
        vCamKid2 = transform.Find("CM vcam Kid").GetComponent<CinemachineVirtualCamera>();
        vCamAdult2 = transform.Find("CM vcam Adult").GetComponent<CinemachineVirtualCamera>();
        vCamKid3 = transform.Find("CM vcam Kid").GetComponent<CinemachineVirtualCamera>();
        vCamAdult3 = transform.Find("CM vcam Adult").GetComponent<CinemachineVirtualCamera>();
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
            PlayCorrectCamera();
        }
    }

    private void PlayCorrectCamera()
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
        //var zoom = context.ReadValue<Vector2>();
        ////zoom in
        //if (zoom.y > 0f && vCamKid.m_Lens.OrthographicSize > minOrthographicSize)
        //{
        //    camNum = 1;
        //    //vCamKid.m_Lens.OrthographicSize -= zoomStepSize;
        //    //vCamAdult.m_Lens.OrthographicSize -= zoomStepSize;

        //}
        ////zoom out
        //else if (zoom.y < 0f && vCamKid.m_Lens.OrthographicSize < maxOrthographicSize)
        //{
        //    camNum = 1;
        //    //vCamKid.m_Lens.OrthographicSize += zoomStepSize;
        //    //vCamAdult.m_Lens.OrthographicSize += zoomStepSize;

        //}
        //zoom in
        var zoom = context.ReadValue<Vector2>();
        if (zoom.y > 0f && camNum <=3 && camNum>0)
        {
            camNum -= 1;
            PlayCorrectCamera();
            //vCamKid.m_Lens.OrthographicSize -= zoomStepSize;
            //vCamAdult.m_Lens.OrthographicSize -= zoomStepSize;

        }
        //zoom out
        else if (zoom.y < 0f && camNum >=0 && camNum<3)
        {
            camNum += 1;
            PlayCorrectCamera();
            //vCamKid.m_Lens.OrthographicSize += zoomStepSize;
            //vCamAdult.m_Lens.OrthographicSize += zoomStepSize;

        }
    }

}
