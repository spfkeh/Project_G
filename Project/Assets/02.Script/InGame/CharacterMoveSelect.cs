using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.EventSystems;

public class CharacterMoveSelect : MonoBehaviour
{
    [SerializeField] private GameObject SelectCharacter;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private CinemachineClearShot clearShot;
    [SerializeField] private GameObject CharacterSelectUI;
    [SerializeField] private CharacterArrangement arrangement;
    RaycastHit2D raycast;
    public bool isEnterPointerUI = false;
    void Start()
    {

    }

    public void SetEnterPointerTrue()
    {
        isEnterPointerUI = true;
    }
    public void SetEnterPointerFalse()
    {
        isEnterPointerUI = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)&& !arrangement.isArrangement)
        {
            raycast = Physics2D.Raycast(mainCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.down, 0.1f, LayerMask.GetMask("Character"));
            if (raycast.collider != null)
            {
                if (SelectCharacter == null)
                {
                    Debug.Log(raycast.collider.name);
                    SelectCharacter = raycast.collider.gameObject;
                    ZoomIn(SelectCharacter);
                }
                else
                {
                    Debug.Log("Chage");
                    ZoomOut(SelectCharacter);
                    SelectCharacter = raycast.collider.gameObject;
                    ZoomIn(SelectCharacter);
                    CharacterSelectUI.SetActive(true);
                }
            }
            else if (isEnterPointerUI)
            {
                ZoomOut(SelectCharacter);
                isEnterPointerUI = false;
            }
            else
            {
                Debug.Log("null");
                if (SelectCharacter != null)
                {
                    ZoomOut(SelectCharacter);
                    SelectCharacter = null;
                }
            }

        }
    }
    private void ZoomIn(GameObject ZoomCharacter)
    {
        int index = FindCharacter(ZoomCharacter);
        clearShot.ChildCameras[index].Priority = 11;
        CharacterSelectUI.SetActive(true);
        Invoke("lateSetActivetrue", 0.15f);
    }
    private void ZoomOut(GameObject ZoomCharacter)
    {
        int index = FindCharacter(ZoomCharacter);
        clearShot.ChildCameras[index].Priority = 9;
        Invoke("lateSetActive", 0.1f);
    }

    public void lateSetActive()
    {
        CharacterSelectUI.SetActive(false);
    }
    public void lateSetActivetrue()
    {
        CharacterSelectUI.SetActive(true);
    }

    private int FindCharacter(GameObject ZoomCharacter)
    {
        int index;
        for (index = 1; index < clearShot.ChildCameras.Length; index++)
        {
            if (clearShot.ChildCameras[index].name == ZoomCharacter.name)
            {
                return index;
            }
        }
        return 0;
    }

    public GameObject GetCharacter()
    {
        Debug.Log("a");
        return SelectCharacter;
    }
    public void SetCharacter(GameObject g)
    {
        SelectCharacter = g;
    }
}
