using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGate_Controller : MonoBehaviour
{
    [Header("Applied to the effects at start")]
    [SerializeField] private Color portalEffectColor = Color.cyan;

    [Header("Changing these might break the effects")]
    [Space(20)]
    [SerializeField] private Renderer portalRenderer;
    [SerializeField] private ParticleSystem[] effectsPartSystems;
    [SerializeField] private Light portalLight;
    [SerializeField] private Transform symbolTF;
    [SerializeField] private AudioSource portalAudio, flashAudio;

    private bool portalActive;
    private bool inTransition;

    private float transitionF;
    private float baseLightIntensity;

    private Material portalMat;
    private Material portalEffectMat;

    private Vector3 symbolStartPos;

    private Coroutine transitionCor;
    private Coroutine symbolMovementCor;

    private void Awake()
    {
        Setup();
    }

    private void Start()
    {
        // Auto start portal after initialization
        Invoke(nameof(AutoStart), 0.1f);
    }

    private void AutoStart()
    {
        F_TogglePortalGate(true);
    }

    private void Setup()
    {
        if (!portalRenderer || portalRenderer.materials.Length < 2)
        {
            Debug.LogError("Portal Renderer missing or has less than 2 materials!", this);
            enabled = false;
            return;
        }

        portalMat = portalRenderer.materials[0];
        portalEffectMat = portalRenderer.materials[1];

        portalMat.SetColor("_EmissionColor", portalEffectColor);
        portalMat.SetFloat("_EmissionStrength", 0);

        portalEffectMat.SetColor("_ColorMain", portalEffectColor);
        portalEffectMat.SetFloat("_PortalFade", 0f);

        if (symbolTF != null)
        {
            symbolStartPos = symbolTF.localPosition;
            var r = symbolTF.GetComponent<Renderer>();
            if (r) r.material = portalMat;
        }

        if (portalLight != null)
        {
            portalLight.color = portalEffectColor;
            baseLightIntensity = portalLight.intensity;
            portalLight.intensity = 0;
        }

        foreach (var part in effectsPartSystems)
        {
            if (!part) continue;
            var mod = part.main;
            mod.startColor = portalEffectColor;
        }

        if (portalAudio != null)
            portalAudio.volume = 0f;

        transitionF = 0f;
        portalActive = false;
        inTransition = false;
    }

    public void F_TogglePortalGate(bool activate)
    {
        if (portalActive == activate)
            return;

        portalActive = activate;

        if (transitionCor != null)
            StopCoroutine(transitionCor);

        if (activate)
        {
            foreach (var part in effectsPartSystems)
                if (part) part.Play();

            if (portalAudio != null) portalAudio.Play();
            if (flashAudio != null) flashAudio.Play();

            if (symbolMovementCor != null)
                StopCoroutine(symbolMovementCor);

            symbolMovementCor = StartCoroutine(SymbolMovement());
        }
        else
        {
            foreach (var part in effectsPartSystems)
                if (part) part.Stop();

            if (symbolMovementCor != null)
                StopCoroutine(symbolMovementCor);
        }

        transitionCor = StartCoroutine(PortalTransition());
    }

    private IEnumerator PortalTransition()
    {
        inTransition = true;

        float target = portalActive ? 1f : 0f;

        while (!Mathf.Approximately(transitionF, target))
        {
            transitionF = Mathf.MoveTowards(
                transitionF,
                target,
                Time.deltaTime * (portalActive ? 0.6f : 1.2f)
            );

            portalMat.SetFloat("_EmissionStrength", transitionF);
            portalEffectMat.SetFloat("_PortalFade", transitionF * 0.4f);

            if (portalLight != null)
                portalLight.intensity = baseLightIntensity * transitionF;

            if (portalAudio != null)
                portalAudio.volume = transitionF * 0.8f;

            yield return null;
        }

        if (!portalActive && portalAudio != null)
            portalAudio.Stop();

        inTransition = false;
    }

    private IEnumerator SymbolMovement()
    {
        if (!symbolTF) yield break;

        Vector3 target;

        while (true)
        {
            Vector3 offset = new Vector3(
                0f,
                Random.Range(-0.08f, 0.08f),
                Random.Range(-0.08f, 0.08f)
            );

            target = symbolStartPos + offset;

            float t = 0f;

            while (t < 1f)
            {
                symbolTF.localPosition = Vector3.Lerp(symbolTF.localPosition, target, t);
                t += Time.deltaTime * 0.5f;
                yield return null;
            }

            yield return new WaitForSeconds(0.1f);
        }
    }
}