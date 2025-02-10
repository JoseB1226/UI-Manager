using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public  class ViewManager : MonoBehaviour
{
    private static ViewManager instance;

    [SerializeField]
    private view startingView;

    [SerializeField]
    private view[] views;

    private view currentView;

    private readonly Stack<view> history = new Stack<view>();

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public static T GetView<T>() where T : view
    {
        for (int i = 0; i < instance.views.Length; i++)
        {
            if (instance.views[i] is T tView)
            {
                return tView;
            }
        }
        return null;
    }

    public static void Show<T>(bool remember = true) where T : view
    {
        for (int i = 0; i < instance.views.Length; i++)
        {
            if (instance.views[i] is T)
            {
                if (instance.currentView != null)
                {
                    if (remember)
                    {
                        instance.history.Push(instance.currentView);
                    }
                    instance.currentView.Hide();
                }

                instance.views[i].Show();

                instance.currentView = instance.views[i];
            }
        }
    }

    public static void Show(view view, bool remember = true)
    {
        if (instance.currentView != null)
        {
            if (remember)
            {
                instance.history.Push(instance.currentView);
            }
            instance.currentView.Hide();
        }

        view.Show();

        instance.currentView = view;
    }

    public static void ShowLast()
    {
        if (instance.history.Count != 0)
        {
            Show(instance.history.Pop(), false);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"Scene Loaded: {scene.name}, Mode: {mode}");

        var goViews = FindObjectsOfType<view>(true);
        views = new view[goViews.Length];

        Debug.Log($"Found {goViews.Length} views in the scene.");

        for (int i = 0; i < goViews.Length; i++)
        {
            if (goViews[i].onStartView)
            {
                startingView = goViews[i];
            }

            views[i] = goViews[i];
            Debug.Log($"Added view: {views[i].name}");
        }

        for (int i = 0; i < views.Length; i++)
        {
            views[i].Initialize();
            views[i].Hide();
        }

        if (startingView != null)
        {
            Debug.Log($"Starting View: {startingView.name}");
            Show(startingView, true);
        }
        else
        {
            Debug.LogWarning("No starting view found!");
        }
    } 
}