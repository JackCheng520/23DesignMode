using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// ================================
//* 功能描述：ModeSimpleFactory  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/9/6 11:52:10
// ================================
namespace Assets.JackCheng._23种设计模式.简单工厂模式
{
    public class ModeSimpleFactory : MonoBehaviour
    {
        void Start() 
        {
            FoodFactory.CreateFood("水果").Cook();

            FoodFactory.CreateFood("蔬菜").Cook();
        }
    }

    public abstract class Food {
        public abstract void Cook();
    }

    public class Fruit : Food {
        public override void Cook()
        {
            Debug.Log(" -- Food Fruit -- ");
        }
    }

    public class vegetable : Food {
        public override void Cook()
        {
            Debug.Log(" -- Food Vegetable -- ");
        }
    }

    public class FoodFactory{
        public static Food CreateFood(string name)
        {
            switch (name) { 
                case "水果":
                    return new Fruit();
                    break;
                case "蔬菜":
                    return new vegetable();
                    break;
            }

            return null;
        }
    }
}
