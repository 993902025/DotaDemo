using UnityEngine;
using System.Collections;

public class Interactive : MonoBehaviour
{
    public static Interactive Current;

    private bool _Selectd = false;

    public bool Selectd { get { return _Selectd; } }

    public bool Swap = false;       //提供给外部修改状态

  
    public void Select()
    {
        _Selectd = true;
        foreach (var selection in GetComponents<Interaction>())
        {
            selection.Select();
        }
    }


    public void DeSelect()
    {
        _Selectd = false;
        foreach (var selection in GetComponents<Interaction>())
        {
            selection.DeSelect();
        }
    }

    

    // Use this for initialization
    void Start()
    {
        Current = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Swap)
        {
            if (!_Selectd)
            {
                Select();
            }
        }
        else
        {
            if (_Selectd)
            {
                DeSelect();
            }
        }

    }
}
