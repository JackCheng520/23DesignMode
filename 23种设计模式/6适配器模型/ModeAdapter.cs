using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// ================================
//* 功能描述：ModeAdapter  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/9/6 16:15:34
// ================================
namespace Assets.JackCheng._23种设计模式._6适配器模型
{
    public class ModeAdapter : MonoBehaviour
    {

    }

    public abstract class LogAdaptee {
        public abstract void LogWrite();
    }

    public class DataBaseLog : LogAdaptee {
        public override void LogWrite()
        {
            
        }
    }

    public class FileLog : LogAdaptee {
        public override void LogWrite()
        {
            
        }
    }

    public interface ILog {
        void Log();
    }

    //类适配器
    public class DataBaseAdapter : DataBaseLog, ILog {
        public void Log() { 
        
        }
    }

    public class FileAdapter : FileLog, ILog {
        public void Log() { 
        
        }
    }

    //对象适配器
    public class LogAdapter : ILog {
        public LogAdaptee adaptee;

        public LogAdapter(LogAdaptee _adaptee) {
            adaptee = _adaptee;
        }

        public void Log() 
        {
            adaptee.LogWrite();
        }
    }
}
