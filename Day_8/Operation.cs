namespace Day_8
{
    
    
    public abstract class Operation
    {
        public int N { get; protected set; }
        public abstract void Run(ref int acc, ref int sp);
    }

    public class NopOperation : Operation
    {
        public NopOperation(int n)
        {
            N = n;
        }
        
        public override void Run(ref int acc, ref int sp)
        { }
    }

    public class AccOperation : Operation
    {
        public AccOperation(int n)
        {
            N = n;
        }

        public override void Run(ref int acc, ref int sp)
        {
            acc += N;
        }
    }

    public class JmpOperation : Operation
    {
        public JmpOperation(int n)
        {
            N = n;
        }

        public override void Run(ref int acc, ref int sp)
        {
            sp += N - 1;
        }
    }
}