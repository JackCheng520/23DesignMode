using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Runtime.InteropServices;

// ================================
//* 功能描述：ModeFlyweight  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/9/7 14:22:00
// ================================
namespace Assets.JackCheng._23种设计模式._11享元模式
{
    public class ModeFlyweight : MonoBehaviour
    {
        void Start() {
            CharactorFactory charFactory = new CharactorFactory();

            CharactorA ca = charFactory.GetCharactor("A") as CharactorA;


            ca.Display();
            (charFactory.GetCharactor("B") as CharactorB).Display();
            (charFactory.GetCharactor("C") as CharactorC).Display();

        }


        
    }

    

    public abstract class Charactor
    {
        protected char symbol;

        protected int width;

        protected int height;

        public abstract void Display();
    }

    public class CharactorA : Charactor
    {
        public override void Display()
        {
            Debug.Log("Charactor -- A");
        }
    }

    public class CharactorB : Charactor
    {
        public override void Display()
        {
            Debug.Log("Charactor -- B");
        }
    }

    public class CharactorC : Charactor
    {
        public override void Display()
        {
            Debug.Log("Charactor -- C");
        }
    }

    public class CharactorFactory
    {
        private Hashtable charactors;

        public CharactorFactory()
        {
            charactors = new Hashtable();
        }

        public object GetCharactor(string key)
        {
            Charactor c = charactors[key] as Charactor;
            if (c == null)
            {
                switch (key)
                {
                    case "A":
                        c = new CharactorA();
                        break;
                    case "B":
                        c = new CharactorB();
                        break;
                    case "C":
                        c = new CharactorC();
                        break;
                }
                charactors.Add(key, c);
            }

            return c;
        }
    }
}
