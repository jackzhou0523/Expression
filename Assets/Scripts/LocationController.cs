using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

// [RequireComponent(typeof(Renderer))]
public class LocationController : MonoBehaviour
{   
    [Header("Renderer")]
    // private Renderer rend;
    [SerializeField ]private MeshRenderer[] childRenderers;
    [SerializeField] Material[] childdefaultMaterials;

    
    private Collider interactionCollider;
    public LocationData data;
    // private Material defaultMaterial;

    private PlayerInputActions inputActions;

    private void Awake()
    {
        // if (rend == null) rend = GetComponent<Renderer>();
        if (interactionCollider == null) interactionCollider = GetComponent<Collider>();

        // if (rend == null || interactionCollider == null)
        // {
        //     Debug.LogError($"Prefab {gameObject.name} missing component！");
        // }

        inputActions = new PlayerInputActions();
    }

    // private void OnEnable()
    // {
    //     inputActions.Enable();
    //     inputActions.MouseControls.Click.performed += OnClick;
    //     inputActions.MouseControls.Hover.started += OnHover;
    //     inputActions.MouseControls.Hover.canceled += OnHoverExit;
    // }

    // private void OnDisable()
    // {
    //     inputActions.MouseControls.Click.performed -= OnClick;
    //     inputActions.MouseControls.Hover.started -= OnHover;
    //     inputActions.MouseControls.Hover.canceled -= OnHoverExit;
    //     inputActions.Disable();
    // }

    void Start()
    {
        interactionCollider = GetComponent<Collider>();
        childRenderers = GetComponentsInChildren<MeshRenderer>();
        childdefaultMaterials = new Material[childRenderers.Length];
        if (childRenderers.Length > 0)
        {
            for (int i = 0; i < childRenderers.Length; i++)
            {
                childdefaultMaterials[i] = childRenderers[i].material;
                // Debug.Log(childRenderers[i].material);
            }
        }
        // rend = GetComponent<Renderer>();
        // defaultMaterial = rend.material;
    }


    public void Initialize(LocationData locationdata)
    {
        data = locationdata;
        // Debug.Log (childRenderers.Length);
        // Debug.Log (childdefaultMaterials.Length);
        if (childRenderers.Length > 0)
        {
            // if (childdefaultMaterials == null || childdefaultMaterials.Length != childRenderers.Length)
            // {
            //     childdefaultMaterials = new Material[childRenderers.Length];
            // }

            for (int i = 0; i < childRenderers.Length; i++)
            {
                childRenderers[i].material = childdefaultMaterials[i];
            }
        }
        // defaultMaterial = rend.material;
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
        // rend.material = isLocked ? data.disabledMaterial : defaultMaterial;

        if (childRenderers.Length > 0)
        {
            for (int i = 0; i < childRenderers.Length; i++)
            {
                childRenderers[i].material = isLocked ? data.disabledMaterial : childdefaultMaterials[i];
            }
        }
    }

    // private void OnHover(InputAction.CallbackContext context)
    // {
    //     Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
    //     if (Physics.Raycast(ray, out RaycastHit hit) && hit.collider == interactionCollider)
    //     {
    //         rend.material = data.hoverMaterial;
    //     }
    // }


    // private void OnHoverExit(InputAction.CallbackContext context)
    // {
    //     Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
    //     if (!Physics.Raycast(ray, out RaycastHit hit) || hit.collider != interactionCollider)
    //     {
    //         rend.material = defaultMaterial;
    //     }
    // }

    // private void OnClick(InputAction.CallbackContext context)
    // {
    //     if (interactionCollider.enabled && isHovering)
    //     {
    //         SceneManager.LoadScene(data.sceneName);
    //     }
    // }

    // void Update()
    // {
    //     HandleMouseHover();
    // }

    // private void HandleMouseHover()
    // {
    //     Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
    //     if (Physics.Raycast(ray, out RaycastHit hit))
    //     {
    //         if (hit.collider == interactionCollider)
    //         {
    //             OnMouseEnter();
    //         }
    //         else
    //         {
    //             OnMouseExit();
    //         }
    //     }
    //     else
    //     {
    //         OnMouseExit();
    //     }
    // }

    void OnMouseEnter()
    {      
        Debug.Log("Mouse Enter");
        // if(interactionCollider.enabled)
        // {
        //     rend.material = data.hoverMaterial;
        // }

        if (interactionCollider.enabled && childRenderers.Length > 0)
        {
            for (int i = 0; i < childRenderers.Length; i++)
            {
                childRenderers[i].material = data.hoverMaterial;
            }
        }

        
    }
    void OnMouseExit()
    {    
        // if (interactionCollider.enabled)
        // {
        //     rend.material = defaultMaterial;
        // }

        if (interactionCollider.enabled && childRenderers.Length > 0)
        {
            for (int i = 0; i < childRenderers.Length; i++)
            {
                childRenderers[i].material = childdefaultMaterials[i];
            }
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
        // rend.material = isUnlocked ? defaultMaterial : data.disabledMaterial;
        if (childRenderers.Length > 0)
        {
            for (int i = 0; i < childRenderers.Length; i++)
            {
                childRenderers[i].material = isUnlocked ? childdefaultMaterials[i] : data.disabledMaterial;
            }
        }
    }
}