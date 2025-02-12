using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Renderer))]
public class LocationController : MonoBehaviour
{   
    
    private Renderer rend;
    private Collider interactionCollider;
    public LocationData data;
    private Material defaultMaterial;

    // void Start()
    // {
    //     interactionCollider = GetComponent<Collider>();
    //     rend = GetComponent<Renderer>();
    //     defaultMaterial = rend.material;
    // }

    public void Initialize(LocationData locationdata)
    {   
        data = locationdata;
        defaultMaterial = rend.material;
        UpdateState();
    }

    public void SetLockState(bool isLocked)
    {
        interactionCollider.enabled = !isLocked;
        rend.material = isLocked ? data.disabledMaterial : defaultMaterial;
    }

    void OnMouseEnter()
    {   
        if(interactionCollider.enabled)
        {
            rend.material = data.hoverMaterial;
        }
    }
    void OnMouseExit()
    {    
        if (interactionCollider.enabled)
        {
            rend.material = defaultMaterial;
        }
    }

    void OnMouseDown()
    {
        if (interactionCollider.enabled)
        {
            SceneManager.LoadScene(data.sceneName);
        }
    }

    public void UpdateState()
    {
        bool isUnlocked = data.IsUnlocked(GameManager.Instance._flagStates);

        interactionCollider.enabled = isUnlocked;
        rend.material = isUnlocked ? defaultMaterial : data.disabledMaterial;
        

        // // state change effect
        // if (isUnlocked != wasUnlockedLastFrame)
        // {
        //     PlayStateChangeEffect();
        // }
        // wasUnlockedLastFrame = isUnlocked;
    }
}
