using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class view : MonoBehaviour 
{

    public abstract void Initialize();


    public virtual void Hide() => gameObject.SetActive(false);

    public virtual void Show() => gameObject.SetActive(true);

    public bool onStartView;

}

public interface IView<T> where T : Component
{
    public static T Instance;


    protected virtual void Awake()
    {
        if (Instance != null)
        {

            string typename = typeof(T).Name;
            Debug.LogWarning($"More than one instance of {typename} found.");
        }

        Instance = (T)this;
    }











}