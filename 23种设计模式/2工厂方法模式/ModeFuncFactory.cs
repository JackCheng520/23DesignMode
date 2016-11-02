using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// ================================
//* 功能描述：ModeFuncFactory  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/9/6 13:19:49
// ================================
namespace Assets.JackCheng._23种设计模式._2工厂方法模式
{
    public class ModeFuncFactory : MonoBehaviour
    {

        void Start()
        {
            RoadCreator gongluCreator = new GongLuCreator();
            RoadCreator baiyouluCreator = new BaiYouLuCreator();

            gongluCreator.CreateRoad().RoadSign();
            baiyouluCreator.CreateRoad().RoadSign();
        }
    }

    public abstract class Road {
        public abstract void RoadSign();
    }

    public abstract class RoadCreator {
        public abstract Road CreateRoad();
    }

    //公路

    public class GongLuCreator : RoadCreator {
        public override Road CreateRoad()
        {
            return new GongLu();
        }
    }
    public class GongLu : Road {
        public override void RoadSign()
        {
            Debug.Log("--公路--");
        }
    }

    //柏油路
    public class BaiYouLuCreator : RoadCreator {
        public override Road CreateRoad()
        {
            return new BaiYouLu();
        }
    }
    public class BaiYouLu : Road {
        public override void RoadSign()
        {
            Debug.Log("--柏油路--");
        }
    }
}
