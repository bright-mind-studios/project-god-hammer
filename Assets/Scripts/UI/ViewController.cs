using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    [SerializeField] private View initView;
    [SerializeField] private List<View> views;
    private readonly Stack<View> viewStack = new Stack<View>();
    private View activeView;

    private void Start()
    {
        views.ForEach(v => {
            v.Init();
            v.HideInstant();
        });

        if (initView != null)
            Show(initView, true);
    }

    public T GetView<T>() where T : View
    {
        return views.Find(view => view is T tView) as T;
    }

    public void Show<T>(bool saveOnStack = true) where T : View
    {
        View view = GetView<T>();
        if(view != null)
        {
            if (activeView != null)
            {
                if (saveOnStack)
                    viewStack.Push(activeView);
                activeView.Hide();
            }
            view.Show();
            activeView = view;                   
        }
    }

    public void Show(View view, bool savedOnStack = true)
    {
        if(activeView != null)
        {
            if (savedOnStack)
                viewStack.Push(activeView);            
            activeView.Hide();
        }

        view.Show();
        activeView = view;
    }

    public void ShowLast()
    {        
        if (viewStack.Count != 0)
            Show(viewStack.Pop(), false);
    }
}
