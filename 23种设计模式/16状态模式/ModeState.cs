using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


// ================================
//* 功能描述：ModeState  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/9/8 13:28:12
// ================================
namespace Assets.JackCheng._23种设计模式
{
    public class ModeState : MonoBehaviour
    {
        private int dis = 0;
        IEnumerator Start()
        {
            Player p = new NPC("Jack");

            while (dis < 510)
            {
                yield return new WaitForSeconds(0.2f);
                dis++;
                if (dis >= 0 && dis < 100)
                    p.ChangeState(new Walk());
                else if (dis >= 100 && dis < 300)
                    p.ChangeState(new Run());
                else
                    p.ChangeState(new Idle());
            }
        }

        void OnGUI()
        {
            GUILayout.Label(dis.ToString());
        }
    }

    public abstract class State
    {
        public string ID;
        public abstract void Init();

        public abstract void Enter();

        public abstract void Exite();

    }

    public class Walk : State
    {
        public Walk()
        {
            ID = "Walk";
        }
        public override void Init()
        {

        }

        public override void Enter()
        {

            Debug.Log("Walk is Enter");
        }

        public override void Exite()
        {
            Debug.Log("Walk is Exite");
        }
    }

    public class Run : State
    {
        public Run()
        {
            ID = "Run";
        }
        public override void Init()
        {

        }

        public override void Enter()
        {
            Debug.Log("Run is Enter");
        }

        public override void Exite()
        {
            Debug.Log("Run is Exite");
        }
    }

    public class Idle : State
    {
        public Idle()
        {
            ID = "Idle";
        }
        public override void Init()
        {

        }

        public override void Enter()
        {
            Debug.Log("Idle is Enter");
        }

        public override void Exite()
        {
            Debug.Log("Idle is Exite");
        }
    }


    public abstract class Player
    {
        public State lastState;
        public State curState;

        public string Name;

        public Player(string _name) { Name = _name; }

        public abstract void ChangeState(State _state);
    }



    /// <summary>
    /// 0-100 walk;100-500 run;>500 idle
    /// </summary>
    public class NPC : Player
    {

        public NPC(string _name)
            : base(_name)
        {
        }


        public override void ChangeState(State _state)
        {
            if (curState == null)
            {
                curState = _state;
                curState.Enter();
                return;
            }


            if (!curState.ID.Equals(_state.ID))
            {
                lastState = curState;
                curState = _state;
                if (lastState != null)
                    lastState.Exite();
                if (curState != null)
                    curState.Enter();
            }
        }
    }
}
