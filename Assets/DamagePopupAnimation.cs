using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DamagePopupAnimation : MonoBehaviour
{
    [SerializeField] AnimationCurve opacityCurve;
    [SerializeField] AnimationCurve scaleCurve;
    [SerializeField] AnimationCurve hightCurve;
    [SerializeField] TextMeshProUGUI Text;
    private float time = 0;
    private Vector3 originPosition;
    private Camera cam;
    private void Awake()
    {
        originPosition= transform.position;
        cam = Camera.main;
        transform.forward = cam.transform.forward;
        InvokeRepeating(nameof(OnAnimation),0f,0.02f);
    }

    void OnAnimation()
    {
        Text.color = new Color(1, 1, 1, opacityCurve.Evaluate(time));
        transform.localScale = Vector3.one * scaleCurve.Evaluate(time);
        transform.position = originPosition + new Vector3(0, 1 + hightCurve.Evaluate(time), 0);
        time += Time.deltaTime;
    }

}
