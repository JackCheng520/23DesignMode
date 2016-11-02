using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

// ================================
//* 功能描述：ModeDecorator  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/9/6 17:21:42
// ================================
namespace Assets.JackCheng._23种设计模式._8装饰模式
{
    public class ModeDecorator : MonoBehaviour
    {
        void Start() 
        {
            Phone ios = new IosPhone();
            //只有贴膜
            Sticker sticker = new Sticker(ios);
            sticker.Show();

            //只有挂件
            Accessories accessories = new Accessories(ios);
            accessories.Show();

            //同时有贴膜和挂件
            sticker = new Sticker(accessories);
            sticker.Show();
        }
    }

    public abstract class Phone {
        public abstract void Show();
    }

    public class IosPhone : Phone
    {
        public override void Show()
        {
            Debug.Log("苹果手机");
        }    
    }

    public class AndroidPhone : Phone {
        public override void Show()
        {
            Debug.Log("安卓手机");
        }
    }
    

    //装饰基类
    public abstract class Decorator :Phone{
        public Phone p;
        public Decorator(Phone _p) {
            p = _p;
        }

        public override void Show() {
            p.Show();
        }
    }

    //贴膜
    public class Sticker : Decorator
    {
        public Sticker(Phone _p) : base(_p) { }

        public override void Show()
        {
            base.Show();
            Debug.Log("手机有贴膜");
        }
    }

    //手机挂件
    public class Accessories : Decorator
    {
        public Accessories(Phone _p) : base(_p) { }

        public override void Show()
        {
            base.Show();
            Debug.Log("手机有挂件");
        }
    }
}
