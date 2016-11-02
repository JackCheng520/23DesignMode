using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// ================================
//* 功能描述：ModeCommand  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/9/7 15:51:28
// ================================
namespace Assets.JackCheng._23种设计模式._12命令模式
{
    public class ModeCommand : MonoBehaviour
    {
        void Start() 
        {
            Receiver r = new Receiver();

            Command c = new TrainingCommand(r);

            Invoker i = new Invoker(c);

            i.ExcuteCommand();

            Command c2 = new StudyCommand(r);

            Invoker i2 = new Invoker(c2);

            i2.ExcuteCommand();

            
        }
    }

    //命令
    public abstract class Command {
        public Receiver receiver;
        public Command(Receiver r) {
            receiver = r;
        }

        public abstract void Excute();
    }

    public class TrainingCommand : Command {
        
        public TrainingCommand(Receiver r)
            : base(r)
        { 
            
        }

        public override void Excute()
        {
            receiver.Training();
        }
    }

    public class StudyCommand : Command {
        
        public StudyCommand(Receiver r) :base(r){ 
        
        }

        public override void Excute()
        {
            receiver.Study();
        }
    }

    //接受者
    public class Receiver {
        public void Training() 
        {
            Debug.Log("训练跑1000米");
        }

        public void Study() {
            Debug.Log("学习");
        }
    }

    //发布命令者
    public class Invoker 
    {
        public Command c;

        public Invoker(Command _c) 
        {
            c = _c;
        }

        public void ExcuteCommand() 
        {
            c.Excute();
        }
    }
}
