﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelStart : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI possessHim;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(LevelStartCutscene());
    }

    private IEnumerator LevelStartCutscene()
    {
        var isActive = false;
        for (var i = 0; i <= 8; i++)
        {
            possessHim.gameObject.SetActive(!isActive);
            isActive = !isActive;
            yield return new WaitForSeconds(0.1f);
        }
        gameObject.SetActive(false);
        yield return null;
    }
}
