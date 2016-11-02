using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// ================================
//* 功能描述：ModePrototype  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/9/6 15:08:43
// ================================
namespace Assets.JackCheng._23种设计模式._5原型模式
{
    public class ModePrototype :MonoBehaviour
    {
        
        void Start() {
            Prototype d = new Door("1");

            Prototype d1 = d.Clone();
            Prototype d2 = d.Clone();
            Debug.Log("--d1--" + d1.ID);
            Debug.Log("--d2--" + d2.ID);

            d1.ID = "2";
            d2.ID = "3";
            Debug.Log("--d1--" + d1.ID);
            Debug.Log("--d2--" + d2.ID);
        }
    }

    public abstract class Prototype 
    {
        public String ID;

        public Prototype(String _id)
        {
            this.ID = _id;
        }

        public abstract Prototype Clone();
    }

    public class Door : Prototype
    {
        public Door(String _id) : base(_id) { }

        public override Prototype Clone()
        {
            return this.MemberwiseClone() as Prototype;
        }
    }
}
