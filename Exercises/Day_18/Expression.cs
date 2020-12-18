namespace Exercises.Day_18
{
    public abstract class Expression
    {
        public abstract long Resolve();
        public abstract string Print(int level = 0);
    }

    public abstract class UnaryExpression : Expression
    {
        protected Expression Son;

        public UnaryExpression(Expression son)
        {
            Son = son;
        }
    }

    public abstract class BinaryExpression : Expression
    {
        protected Expression Left, Right;

        public BinaryExpression(Expression left, Expression right)
        {
            Left = left;
            Right = right;
        }
    }
    
    public class AddExpression : BinaryExpression
    {
        public AddExpression(Expression left, Expression right) : base(left, right) { }

        public override long Resolve()
        {
            return Left.Resolve() + Right.Resolve();
        }

        public override string Print(int level = 0)
        {
            string str = "";
            for (int i = 0; i < level; i++)
                str += "  ";
            str += "+:\n";
            str += Left.Print(level + 1);
            str += Right.Print(level + 1);
            return str;
        }
    }
    
    public class MultExpression : BinaryExpression
    {
        public MultExpression(Expression left, Expression right) : base(left, right) { }

        public override long Resolve()
        {
            return Left.Resolve() * Right.Resolve();
        }
        
        public override string Print(int level = 0)
        {
            string str = "";
            for (int i = 0; i < level; i++)
                str += "  ";
            str += "*:\n";
            str += Left.Print(level + 1);
            str += Right.Print(level + 1);
            return str;
        }
    }
    
    public class ValueExpression : Expression
    {
        private int _value;

        public ValueExpression(int value)
        {
            _value = value;
        }
        
        public override long Resolve()
        {
            return _value;
        }

        public override string Print(int level = 0)
        {
            string str = "";
            for (int i = 0; i < level; i++)
                str += "  ";
            str += $"num: {_value}\n";
            return str;
        }
    }
}