﻿using System.Collections;
using TMPro;
using UnityEngine;

public class IntroCutscene : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] cutSceneLines;
    [SerializeField] private GameObject title;

    // Update is called once per frame
    private void Update()
    {
        StartCoroutine(FadeIn(0.01f, 2.0f, cutSceneLines));
    }

    private IEnumerator FadeIn(float timeIncrement, float delay, TextMeshProUGUI[] lines)
    {
        foreach (var line in lines)
        {
            while (line.color.a < 1.0f)
            {
                IncrementTextVisibility(timeIncrement, line);
                yield return null;
            }

            yield return new WaitForSeconds(delay);
        }

        yield return new WaitForSeconds(delay);

        DisableLineVisibility(lines);

        title.SetActive(true);
    }

    private static void IncrementTextVisibility(float timeIncrement, TextMeshProUGUI line)
    {
        line.color = new Color(line.color.r, line.color.g, line.color.b,
            line.color.a + (Time.deltaTime * timeIncrement));
    }

    private static void DisableLineVisibility(TextMeshProUGUI[] lines)
    {
        foreach (var line in lines)
        {
            line.enabled = false;
        }
    }
}