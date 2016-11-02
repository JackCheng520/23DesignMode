using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// ================================
//* 功能描述：ModeBriage  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/9/6 16:24:37
// ================================
namespace Assets.JackCheng._23种设计模式._7桥接模式
{
    public class ModeBridge : MonoBehaviour
    {
        void Start(){
            RemoteControl ch = new RemoteControl(new ChangHong());
            ch.On();
            ch.Change();
            ch.Off();

            RemoteControl cw = new RemoteControl(new ChuangWei());
            cw.On();
            cw.Change();
            cw.Off();

        }

    }

    public class RemoteControl {
        public TV tv;

        public RemoteControl(TV _tv) {
            tv = _tv;
        }

        public virtual void On() { tv.On(); }

        public virtual void Off() { tv.Off(); }

        public virtual void Change() { tv.Change();}
    }

    public abstract class TV {
        public abstract void On();

        public abstract void Off();

        public abstract void Change();
    }

    public class ChangHong : TV {
        public override void On()
        {
            Debug.Log("长虹电视开机");
        }

        public override void Off()
        {
            Debug.Log("长虹电视关机");
        }

        public override void Change()
        {
            Debug.Log("长虹电视切换频道");
        }
    }

    public class ChuangWei : TV {
        public override void On()
        {
            Debug.Log("创维电视开机");
        }

        public override void Off()
        {
            Debug.Log("创维电视关机");
        }

        public override void Change()
        {
            Debug.Log("创维电视切换频道");
        }
    }
}
