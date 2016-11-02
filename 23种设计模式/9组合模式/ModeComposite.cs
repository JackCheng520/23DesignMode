using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// ================================
//* 功能描述：ModeComposite  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/9/7 11:50:30
// ================================
namespace Assets.JackCheng._23种设计模式._9组合模式
{
    public class ModeComposite : MonoBehaviour
    {
        void Start() {
            Graphic line = new Line();
            Graphic circle = new Circle();

            ComplexGraphic comp = new ComplexGraphic();
            comp.Add(line);
            comp.Add(circle);

            comp.Draw();
        }
    }

    //===========================安全组合模式======================
    //public abstract class Graphic {
    //    public Graphic() { }

    //    public abstract void Draw();
    //}

    //public class Line : Graphic {
    //    public override void Draw()
    //    {
    //        Debug.Log("画一条线");
    //    }
    //}

    //public class Circle : Graphic {
    //    public override void Draw()
    //    {
    //        Debug.Log("画一个圈");
    //    }
    //}

    //public class ComplexGraphic :Graphic{

    //    public List<Graphic> listGraphic;
    //    public ComplexGraphic()  
    //    {
    //        listGraphic = new List<Graphic>();
    //    }
    //    public override void Draw()
    //    {
    //        Debug.Log("画一个图形");

    //        for (int i = 0; i < listGraphic.Count; i++)
    //            listGraphic[i].Draw();
    //    }

    //    public void Add(Graphic g) {
    //        listGraphic.Add(g);
    //    }

    //    public void Remove(Graphic g) {
    //        listGraphic.Remove(g);
    //    }
    //}
    //===========================透明组合模式======================
    public abstract class Graphic
    {
        public Graphic() { }

        public abstract void Draw();
        public abstract void Add(Graphic g);
        public abstract void Remove(Graphic g);

    }

    public class Line : Graphic
    {
        public override void Draw()
        {
            Debug.Log("画一条线");
        }
        public override void Add(Graphic g)
        {
            throw new Exception("基础图形不能添加");
        }
        public override void Remove(Graphic g)
        {
            throw new Exception("基础图形不能删除");
        }
    }

    public class Circle : Graphic
    {
        public override void Draw()
        {
            Debug.Log("画一个圈");
        }
        public override void Add(Graphic g)
        {
            throw new Exception("基础图形不能添加");
        }
        public override void Remove(Graphic g)
        {
            throw new Exception("基础图形不能删除");
        }
    }

    public class ComplexGraphic : Graphic
    {

        public List<Graphic> listGraphic;
        public ComplexGraphic()
        {
            listGraphic = new List<Graphic>();
        }
        public override void Draw()
        {
            Debug.Log("画一个图形");

            for (int i = 0; i < listGraphic.Count; i++)
                listGraphic[i].Draw();
        }

        public override void Add(Graphic g)
        {
            listGraphic.Add(g);
        }

        public override void Remove(Graphic g)
        {
            listGraphic.Remove(g);
        }
    }
}
