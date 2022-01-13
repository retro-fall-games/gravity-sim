using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour, IPointerClickHandler
{
  [field: SerializeField] private GameObject PlanetPrefab { get; set; }
  private Camera _cam;


  private void Awake()
  {
    _cam = Camera.main;
  }

  private void Update()
  {
    if (Mouse.current.leftButton.wasPressedThisFrame)
    {
      Plane plane = new Plane(Vector3.up, 0);
      float distance;

      Ray ray = _cam.ScreenPointToRay(Mouse.current.position.ReadValue());

      if (plane.Raycast(ray, out distance))
      {
        Vector3 worldPosition = ray.GetPoint(distance);
        Debug.Log(worldPosition);
        Instantiate(PlanetPrefab, worldPosition, Quaternion.identity);
      }
    }
  }

  public void OnPointerClick(PointerEventData eventData)
  {
    Debug.Log("clicked");
  }
}
