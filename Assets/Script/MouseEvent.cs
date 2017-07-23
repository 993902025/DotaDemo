using UnityEngine;
using System.Collections;

public class MouseEvent : MonoBehaviour
{

    private bool isMouseDown;

    private Vector3 lastMousePosition;
    private Vector3 startMousePosition;
    public Color rectColor = Color.green;
    public Material rectMat =null;// = null;//画线的材质 不设定系统会用当前材质画线 结果不可控
    private Vector3 endMousePos;

    LineRenderer lineRenderer;

    // Use this for initialization
    void Start()
    {
        //设置材质  
        rectMat = new Material(Shader.Find("Particles/Additive"));  
    }

    // Update is called once per frame
    void Update()
    {

        startMousePosition = MouseSelect.startMousePos;
        endMousePos = MouseSelect.endMousePos;
        isMouseDown = MouseSelect.isMouseDown;

        //GL.Color(rectColor);
    }

    void OnPostRender()
    {
        if (isMouseDown)
        {
            if (!rectMat)
            {
                Debug.Log("dddddddd");
                return;
            }
            rectMat.SetPass(0);
            GL.PushMatrix(); //保存当前Matirx
            GL.LoadPixelMatrix();

            //GL.Color(new Color(rectColor.r, rectColor.g, rectColor.b, 0.1f));
            //GL.Begin(GL.QUADS);
            //GL.Vertex3(startMousePosition.x, startMousePosition.y, 0);
            //GL.Vertex3(endMousePos.x, startMousePosition.y, 0);
            //GL.Vertex3(endMousePos.x, endMousePos.y, 0);
            //GL.Vertex3(startMousePosition.x, endMousePos.y, 0);
            //GL.End();

            GL.Begin(GL.LINES);
            GL.Color(rectColor);        //设置方框的边框颜色 边框不透明
            GL.Vertex3(startMousePosition.x, startMousePosition.y, 0);
            GL.Vertex3(endMousePos.x, startMousePosition.y, 0);
            GL.Vertex3(endMousePos.x, startMousePosition.y, 0);
            GL.Vertex3(endMousePos.x, endMousePos.y, 0);
            GL.Vertex3(endMousePos.x, endMousePos.y, 0);
            GL.Vertex3(startMousePosition.x, endMousePos.y, 0);
            GL.Vertex3(startMousePosition.x, endMousePos.y, 0);
            GL.Vertex3(startMousePosition.x, startMousePosition.y, 0);
            GL.End();

            GL.PopMatrix();//恢复摄像机投影矩阵
        }
    }
    

}
