﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFader : MonoBehaviour {

    public Image img;
    public AnimationCurve curve;

    void Start() {
        StartCoroutine(FadeIn());
    }
    public void FadeTo(string scene) {

        StartCoroutine(FadeOut(scene));
    }

    IEnumerator FadeIn() {
        float time = 1f;

        while (time > 0f) {
            time -= Time.deltaTime;
            float alpha = curve.Evaluate(time);
            img.color = new Color(0f, 0f, 0f, alpha);

            yield return 0;
        }
    }

    IEnumerator FadeOut(string scene) {
        float time = 0f;

        while (time < 1f) {
            time += Time.deltaTime;
            float alpha = curve.Evaluate(time);
            img.color = new Color(0f, 0f, 0f, alpha);

            yield return 0;
        }
        //load Scene
        SceneManager.LoadScene(scene);
    }
}
