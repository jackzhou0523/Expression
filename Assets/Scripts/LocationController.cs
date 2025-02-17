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

    private void Awake()
    {
        if (rend == null) rend = GetComponent<Renderer>();
        if (interactionCollider == null) interactionCollider = GetComponent<Collider>();
        
        if (rend == null || interactionCollider == null)
        {
            Debug.LogError($"Prefab {gameObject.name} missing component！");
        }
    }

    void Start()
    {
        interactionCollider = GetComponent<Collider>();
        rend = GetComponent<Renderer>();
        defaultMaterial = rend.material;
    }

    public void Initialize(LocationData locationdata)
    {   
        data = locationdata;
        defaultMaterial = rend.material;
        // Add null checks and log statements
        if (data == null)
        {
            Debug.LogError("LocationData is null");
            return;
        }
        if (data.disabledMaterial == null)
        {
            Debug.LogError("disabledMaterial is null in LocationData");
        }
        if (data.hoverMaterial == null)
        {
            Debug.LogError("hoverMaterial is null in LocationData");
        }
        if (string.IsNullOrEmpty(data.sceneName))
        {
            Debug.LogError("sceneName is null or empty in LocationData");
        }
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
