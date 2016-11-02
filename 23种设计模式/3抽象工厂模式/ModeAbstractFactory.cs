using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// ================================
//* 功能描述：ModeAbstractFactory  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/9/6 13:49:54
// ================================
namespace Assets.JackCheng._23种设计模式._3抽象工厂模式
{
    public class ModeAbstractFactory : MonoBehaviour
    {
        void Start()
        {
            Shop nanChangShop = new NanChangShop();
            nanChangShop.CreateYaBo().Out();
            nanChangShop.CreateYaJa().Out();

            Shop shangHaiShop = new ShangHaiShop();
            shangHaiShop.CreateYaBo().Out();
            shangHaiShop.CreateYaJa().Out();

        }
    }

    public abstract class Shop {
        public abstract YaBo CreateYaBo();

        public abstract YaJia CreateYaJa();
    }

    public abstract class YaBo {
        public abstract void Out();
    }

    public abstract class YaJia {
        public abstract void Out();
    }

    //南昌店
    public class NanChangShop : Shop {
        public override YaBo CreateYaBo()
        {
            return new NanChangYaBo();
        }

        public override YaJia CreateYaJa()
        {
            return new NanChangYaJia();
        }
    }

    public class NanChangYaBo : YaBo {
        public override void Out()
        {
            Debug.Log("南昌店 -- 鸭脖");
        }
    }

    public class NanChangYaJia : YaJia {
        public override void Out()
        {
            Debug.Log("南昌店 -- 鸭架");
        }
    }


    //上海店
    public class ShangHaiShop : Shop {
        public override YaBo CreateYaBo()
        {
            return new ShangHaiYaBo();
        }

        public override YaJia CreateYaJa()
        {
            return new ShangHaiYaJia();
        }
    }

    public class ShangHaiYaBo : YaBo {
        public override void Out()
        {
            Debug.Log("上海店 -- 鸭脖");
        }

    }

    public class ShangHaiYaJia : YaJia {
        public override void Out()
        {
            Debug.Log("上海店 -- 鸭架");
        }
    }
}
