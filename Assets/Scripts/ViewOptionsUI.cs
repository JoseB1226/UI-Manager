using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewOptionsUI : view, IView<ViewOptionsUI>
{
    [SerializeField]
    private GameObject backButton;
    public override void Initialize()
    {
       IView<ViewOptionsUI>.Instance = this;
    }

    public void OnViewLoad()
    {
        ViewManager.Show<ViewOptionsUI>();
        backButton.SetActive(true);
    }
}
