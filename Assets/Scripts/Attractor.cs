using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
  private Rigidbody rb;
  private const float G = 667.4f;
  public static List<Attractor> Attractors;

  private void Awake()
  {
    rb = GetComponent<Rigidbody>();
  }

  private void FixedUpdate()
  {
    foreach (Attractor attractor in Attractors)
    {
      if (attractor != this)
        Attract(attractor);
    }
  }

  private void OnEnable()
  {
    if (Attractors == null)
      Attractors = new List<Attractor>();

    Attractors.Add(this);
  }

  private void OnDisable()
  {
    Attractors.Remove(this);
  }

  private void Attract(Attractor objToAttract)
  {
    Rigidbody rbToAttract = objToAttract.rb;

    Vector3 direction = rb.position - rbToAttract.position;

    float distance = direction.sqrMagnitude;

    if (distance == 0)
      return;

    float forceMagnitude = G * (rb.mass * rbToAttract.mass) / distance;

    Vector3 force = direction.normalized * forceMagnitude;

    rbToAttract.AddForce(force);
  }
}
