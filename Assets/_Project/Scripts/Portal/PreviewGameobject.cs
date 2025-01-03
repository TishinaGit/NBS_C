using System.Collections.Generic;
using UnityEngine;

public class PreviewGameobject : MonoBehaviour
{
    [SerializeField] private LayerMask _invalidLayers;
    public bool IsValid { get; private set; } = true;
    [SerializeField] private HashSet<Collider> _collidingObjects = new HashSet<Collider>();

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & _invalidLayers) != 0)
        {
            _collidingObjects.Add(other);
            IsValid = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (((1 << other.gameObject.layer) & _invalidLayers) != 0)
        {
            _collidingObjects.Remove(other);
            IsValid = _collidingObjects.Count <= 0;
        }
    }
}
