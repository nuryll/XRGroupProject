using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Portal_Controller : MonoBehaviour
{
    [Header("Applied to the effects at start")]
    [SerializeField] private Color portalEffectColor = Color.cyan;

    [Header("Changing these might break the effects")]
    [Space(20)]
    [SerializeField] private Renderer portalRenderer;
    [SerializeField] private ParticleSystem[] effectsParticles;
    [SerializeField] private Light portalLight;
    [SerializeField] private AudioSource orbAudio, flashAudio, portalAudio;

    private float maxVolOrb = 0.08f;
    private float maxVolPortal = 0.8f;
    private float maxIntPortalLight = 4f;
    private float transitionSpeed = 1.5f;

    private bool inTransition;
    private bool activated;

    private Material portalMat;
    private Material portalEffectMat;

    private float fadeFloat;

    private Coroutine transitionCor;

    private void Awake()
    {
        Setup();
    }

    private void Start()
    {
        // Auto test start (remove if you don't want auto start)
        TogglePortal(true);
    }

    public void TogglePortal(bool activate)
    {
        if (activate == activated)
            return;

        if (transitionCor != null)
            StopCoroutine(transitionCor);

        activated = activate;

        if (activated)
            transitionCor = StartCoroutine(PreActivate());
        else
            transitionCor = StartCoroutine(TransitionSequence());
    }

    private IEnumerator PreActivate()
    {
        inTransition = true;

        if (orbAudio != null)
        {
            orbAudio.volume = maxVolOrb;
            orbAudio.Play();
        }

        if (effectsParticles.Length > 0 && effectsParticles[0] != null)
            effectsParticles[0].Play();

        yield return new WaitForSeconds(2.2f);

        if (flashAudio != null) flashAudio.Play();
        if (portalAudio != null) portalAudio.Play();

        yield return new WaitForSeconds(0.3f);

        transitionCor = StartCoroutine(TransitionSequence());

        if (effectsParticles.Length > 2 && effectsParticles[2] != null)
            effectsParticles[2].Play();
    }

    private IEnumerator TransitionSequence()
    {
        inTransition = true;

        while (true)
        {
            float target = activated ? 1f : 0f;

            fadeFloat = Mathf.MoveTowards(
                fadeFloat,
                target,
                Time.deltaTime * transitionSpeed
            );

            if (portalAudio != null)
                portalAudio.volume = maxVolPortal * fadeFloat;

            if (portalEffectMat != null)
                portalEffectMat.SetFloat("_PortalFade", fadeFloat);

            if (portalMat != null)
                portalMat.SetFloat("_EmissionStrength", fadeFloat);

            if (portalLight != null)
                portalLight.intensity = maxIntPortalLight * fadeFloat;

            if (Mathf.Abs(fadeFloat - target) < 0.01f)
                break;

            yield return null;
        }

        if (!activated)
        {
            if (portalAudio != null) portalAudio.Stop();
            if (effectsParticles.Length > 2 && effectsParticles[2] != null)
                effectsParticles[2].Stop();
        }

        if (orbAudio != null) orbAudio.Stop();

        inTransition = false;
    }

    private void Setup()
    {
        if (portalRenderer == null)
        {
            Debug.LogError("Portal Renderer not assigned!", this);
            return;
        }

        Material[] mats = portalRenderer.materials;

        if (mats.Length < 2)
        {
            Debug.LogError("Portal Renderer must have at least 2 materials!", this);
            return;
        }

        portalMat = mats[0];
        portalEffectMat = mats[1];

        portalMat.SetColor("_EmissionColor", portalEffectColor);
        portalMat.SetFloat("_EmissionStrength", 0);

        portalEffectMat.SetColor("_ColorMain", portalEffectColor);
        portalEffectMat.SetFloat("_PortalFade", 0);

        foreach (var part in effectsParticles)
        {
            if (part == null) continue;
            var mod = part.main;
            mod.startColor = portalEffectColor;
        }

        if (portalAudio != null) portalAudio.volume = 0f;
        if (portalLight != null) portalLight.intensity = 0f;

        fadeFloat = 0f;
        activated = false;
        inTransition = false;
    }
}