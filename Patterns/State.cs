using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns
{
    public abstract class State
    {
        protected String status;
        public State(string status) {
            this.status = status;
        }

        

        public String GetStatus() {
            return status;
        }
        public abstract String Handle(Context context);
    }

    public class HangarPlainState : State
    {
        public HangarPlainState() : base("Hangar") { }
        public override String Handle(Context context)
        {
            context.State = new FightPlainState();
            return context.State.GetStatus();
        }
    }

    public class FightPlainState : State
    {
        public FightPlainState() : base("Fighting") {

        }
        public override String Handle(Context context)
        {
            context.State = new CrashPlainState();
            return context.State.GetStatus();
        }
    }

    public class CrashPlainState : State
    {
        public CrashPlainState() : base("Crashed") { }

        public override string Handle(Context context)
        {
            context.State = new CrashPlainState();
            return context.State.GetStatus();
        }

    }

    public class HangarDivisionState : State
    {
        public HangarDivisionState() : base("Division is in Hangar") { }
        public override string Handle(Context context)
        {
            context.State = new FightDivisionState();
            return context.State.GetStatus();
        }
    }

    public class FightDivisionState : State 
    {
        public FightDivisionState() : base("Division is fighting") { }
        public override string Handle(Context context)
        {
            context.State = new WonDivisionState();
            return context.State.GetStatus();
        }
    }

    public class WonDivisionState : State
    {
        public WonDivisionState() : base("Division won") { }
        public override string Handle(Context context)
        {
            context.State = new HangarDivisionState();
            return context.State.GetStatus();
        }
    }



    public class Context{
        public State State { get; set; }
        public Context(State state)
        {
            this.State = state;
        }
        public String Request()
        {
            return this.State.Handle(this);
        }

        public String GetStatus() {
            return State.GetStatus();
        }

       
    }
}
