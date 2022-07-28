using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField, Range(0f,1f)] private float currentIntensity = 1.0f;

    private float [] startIntensities = new float[0];

    float timeLastWatered = 0;
    [SerializeField] private float regenDelay = 2.5f;
    [SerializeField] private float regenRate = 0.1f;

    [SerializeField] private ParticleSystem [] fireParticleSystems = new ParticleSystem[0];

    public bool isLit = true;

    private void Start()
    {
        startIntensities = new float[fireParticleSystems.Length];

        for(int i = 0; i < fireParticleSystems.Length; i++)
        {
            startIntensities[i] = fireParticleSystems[i].emission.rateOverTime.constant;
        }
    }

    private void Update()
    {
        if(isLit && currentIntensity < 1.0f && Time.time - timeLastWatered >= regenDelay)
        {
            currentIntensity += regenRate * Time.deltaTime;
            ChangeIntensity();
        }
    }

    public bool TryExtinguish(float amount)
    {
        timeLastWatered = Time.time;

        currentIntensity -= amount;

        ChangeIntensity();

        if (currentIntensity <= 0)
        {
            Score.score++;
            Debug.Log("Added 1 point!");
            isLit = false;
            Destroy(gameObject);
            return true;
        }

        return false; //Fire is still lit
    }

    private void ChangeIntensity()
    {
        for (int i = 0; i < fireParticleSystems.Length; i++)
        {
            var emission = fireParticleSystems[i].emission;
            emission.rateOverTime = currentIntensity * startIntensities[i];
        }
    }

    // TODO asdfasfas Debuglog each time a fire is put out entirely. Add 1 to a score whenever a fire gets put out, when fire gets put out it adds 1 to score.
    // Use event system to tell when a fire has been put out, score manager hears the event, and adds score.
    // If score reaches a certain number, a win screen pops out.
}
