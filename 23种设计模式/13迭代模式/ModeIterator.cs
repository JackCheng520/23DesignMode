using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// ================================
//* 功能描述：ModeIterator  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/9/7 16:39:48
// ================================
namespace Assets.JackCheng._23种设计模式._13迭代模式
{
    public class ModeIterator : MonoBehaviour
    {
        IEnumerator Start()
        {
            Jlist list = new Jlist();
            IJiterator iterator = list.GetIterater();

            while (iterator.MoveNext())
            {
                Debug.Log((iterator.GetCurrent()));
                yield return new WaitForSeconds(0.5f);
                iterator.Next();
            }
        }
    }

    public interface IJlist
    {
        IJiterator GetIterater();
    }

    public interface IJiterator
    {
        bool MoveNext();
        void Next();
        object GetCurrent();
        void Reset();
    }

    public class Jlist : IJlist
    {
        public int[] list = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        public IJiterator GetIterater()
        {
            return new Jiterator(this);
        }

        public int Lenght
        {
            get
            {
                return list.Length;
            }
        }

        public int this[int idx]
        {
            get
            {
                if (idx >= 0 && idx < Lenght)
                    return list[idx];
                return -1;
            }
        }
    }


    public class Jiterator : IJiterator
    {
        private Jlist list;
        private int index;
        public Jiterator(Jlist _list)
        {
            index = 0;
            list = _list;
        }
        public bool MoveNext()
        {
            if (index < list.Lenght)
                return true;
            else
                return false;
        }
        public void Next()
        {
            if (index < list.Lenght)
                index++;
        }
        public object GetCurrent()
        {
            return list[index];
        }
        public void Reset()
        {
            index = 0;
        }
    }
}
