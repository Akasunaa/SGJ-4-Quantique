using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    [SerializeField] GameObject _canvas;
    [SerializeField] Image image;

    //SpriteRenderer spriteRenderer;
    //private IEnumerator coroutine;
    private Color spriteRendererColor;

    void Awake()
    {
        spriteRendererColor = image.color;
        LevelManager.Win += Win;
        DontDestroyOnLoad(gameObject);
    }

    private void OnDestroy()
    {
        LevelManager.Win -= Win;
    }
    private void Win()
    {
        StartCoroutine(TransitionToScene(2, 4));



    }

    public IEnumerator FadeOut(float time)
    {

        _canvas.SetActive(true);
        while (spriteRendererColor.a < 1)
        {
            spriteRendererColor = image.color;
            spriteRendererColor.a += Time.unscaledDeltaTime / time;
            image.color = spriteRendererColor;
            yield return null;
        }
    }



    public IEnumerator FadeIn(float time)
    {
        while (spriteRendererColor.a > 0)
        {
            spriteRendererColor = image.color;
            spriteRendererColor.a -= Time.unscaledDeltaTime / time;
            image.color = spriteRendererColor;
            yield return null;
        }
        _canvas.SetActive(false);
    }

    public IEnumerator TransitionToScene(int sceneIndex, float time)
    {
        yield return FadeOut(time);
        yield return SceneManager.LoadSceneAsync("Fin");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Fin"));
        yield return FadeIn(time);
    }

    public void StartTransition(int sceneIndex, float time)
    {

        StartCoroutine(TransitionToScene(sceneIndex, time));
    }

}