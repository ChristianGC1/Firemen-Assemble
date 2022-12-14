using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinguisher : MonoBehaviour
{
    [SerializeField] private float amountExtinguishedPerSecond = 1.0f;

    private void Update()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 100f)
            && hit.collider.TryGetComponent(out Fire fire))
            fire.TryExtinguish(amountExtinguishedPerSecond * Time.deltaTime);
    }
}
