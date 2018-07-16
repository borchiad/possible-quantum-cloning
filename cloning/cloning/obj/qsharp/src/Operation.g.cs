#pragma warning disable 1591
using System;
using Microsoft.Quantum.Primitive;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.MetaData.Attributes;

[assembly: OperationDeclaration("Quantum.cloning", "rotation (q1 : Qubit, rnd : Double) : ()", new string[] { }, "C:\\Users\\Davidelocal\\source\\repos\\cloning\\cloning\\Operation.qs", 357L, 8L, 2L)]
[assembly: OperationDeclaration("Quantum.cloning", "Set (q1 : Qubit, desired : Result) : ()", new string[] { }, "C:\\Users\\Davidelocal\\source\\repos\\cloning\\cloning\\Operation.qs", 450L, 15L, 2L)]
[assembly: OperationDeclaration("Quantum.cloning", "cloning (count : Int, rando : Double, initial : Result) : (Int, Int, Int, Int)", new string[] { }, "C:\\Users\\Davidelocal\\source\\repos\\cloning\\cloning\\Operation.qs", 888L, 27L, 5L)]
#line hidden
namespace Quantum.cloning
{
    public class rotation : Operation<(Qubit,Double), QVoid>, ICallable
    {
        public rotation(IOperationFactory m) : base(m)
        {
        }

        public class In : QTuple<(Qubit,Double)>, IApplyData
        {
            public In((Qubit,Double) data) : base(data)
            {
            }

            System.Collections.Generic.IEnumerable<Qubit> IApplyData.Qubits
            {
                get
                {
                    yield return Data.Item1;
                }
            }
        }

        String ICallable.Name => "rotation";
        String ICallable.FullName => "Quantum.cloning.rotation";
        protected IUnitary<(Double,Qubit)> MicrosoftQuantumPrimitiveRx
        {
            get;
            set;
        }

        public override Func<(Qubit,Double), QVoid> Body => (__in) =>
        {
            var (q1,rnd) = __in;
#line 11 "C:\\Users\\Davidelocal\\source\\repos\\cloning\\cloning\\Operation.qs"
            MicrosoftQuantumPrimitiveRx.Apply((rnd, q1));
#line hidden
            return QVoid.Instance;
        }

        ;
        public override void Init()
        {
            this.MicrosoftQuantumPrimitiveRx = this.Factory.Get<IUnitary<(Double,Qubit)>>(typeof(Microsoft.Quantum.Primitive.Rx));
        }

        public override IApplyData __dataIn((Qubit,Double) data) => new In(data);
        public override IApplyData __dataOut(QVoid data) => data;
        public static System.Threading.Tasks.Task<QVoid> Run(IOperationFactory __m__, Qubit q1, Double rnd)
        {
            return __m__.Run<rotation, (Qubit,Double), QVoid>((q1, rnd));
        }
    }

    public class Set : Operation<(Qubit,Result), QVoid>, ICallable
    {
        public Set(IOperationFactory m) : base(m)
        {
        }

        public class In : QTuple<(Qubit,Result)>, IApplyData
        {
            public In((Qubit,Result) data) : base(data)
            {
            }

            System.Collections.Generic.IEnumerable<Qubit> IApplyData.Qubits
            {
                get
                {
                    yield return Data.Item1;
                }
            }
        }

        String ICallable.Name => "Set";
        String ICallable.FullName => "Quantum.cloning.Set";
        protected ICallable<Qubit, Result> M
        {
            get;
            set;
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveX
        {
            get;
            set;
        }

        public override Func<(Qubit,Result), QVoid> Body => (__in) =>
        {
            var (q1,desired) = __in;
#line 17 "C:\\Users\\Davidelocal\\source\\repos\\cloning\\cloning\\Operation.qs"
            var current = M.Apply(q1);
#line 18 "C:\\Users\\Davidelocal\\source\\repos\\cloning\\cloning\\Operation.qs"
            if ((current != desired))
            {
#line 20 "C:\\Users\\Davidelocal\\source\\repos\\cloning\\cloning\\Operation.qs"
                MicrosoftQuantumPrimitiveX.Apply(q1);
            }

#line hidden
            return QVoid.Instance;
        }

        ;
        public override void Init()
        {
            this.M = this.Factory.Get<ICallable<Qubit, Result>>(typeof(Microsoft.Quantum.Primitive.M));
            this.MicrosoftQuantumPrimitiveX = this.Factory.Get<IUnitary<Qubit>>(typeof(Microsoft.Quantum.Primitive.X));
        }

        public override IApplyData __dataIn((Qubit,Result) data) => new In(data);
        public override IApplyData __dataOut(QVoid data) => data;
        public static System.Threading.Tasks.Task<QVoid> Run(IOperationFactory __m__, Qubit q1, Result desired)
        {
            return __m__.Run<Set, (Qubit,Result), QVoid>((q1, desired));
        }
    }

    public class cloning : Operation<(Int64,Double,Result), (Int64,Int64,Int64,Int64)>, ICallable
    {
        public cloning(IOperationFactory m) : base(m)
        {
        }

        public class In : QTuple<(Int64,Double,Result)>, IApplyData
        {
            public In((Int64,Double,Result) data) : base(data)
            {
            }

            System.Collections.Generic.IEnumerable<Qubit> IApplyData.Qubits => null;
        }

        public class Out : QTuple<(Int64,Int64,Int64,Int64)>, IApplyData
        {
            public Out((Int64,Int64,Int64,Int64) data) : base(data)
            {
            }

            System.Collections.Generic.IEnumerable<Qubit> IApplyData.Qubits => null;
        }

        String ICallable.Name => "cloning";
        String ICallable.FullName => "Quantum.cloning.cloning";
        protected Allocate Allocate
        {
            get;
            set;
        }

        protected IUnitary<(Qubit,Qubit,Qubit)> MicrosoftQuantumPrimitiveCCNOT
        {
            get;
            set;
        }

        protected ICallable<Qubit, Result> M
        {
            get;
            set;
        }

        protected Release Release
        {
            get;
            set;
        }

        protected ICallable<(Qubit,Result), QVoid> Set
        {
            get;
            set;
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveX
        {
            get;
            set;
        }

        protected ICallable<(Qubit,Double), QVoid> rotation
        {
            get;
            set;
        }

        public override Func<(Int64,Double,Result), (Int64,Int64,Int64,Int64)> Body => (__in) =>
        {
            var (count,rando,initial) = __in;
            //These two variables will contain the number of ones measured during a run of a number _count_ of qubit, one is used for the original qubit (which we hope
            // it's nice enough to not change its behavior), one is used in the measure of the third qubit (which we hope NOT TO BE IN THE SAME STATE)
#line 32 "C:\\Users\\Davidelocal\\source\\repos\\cloning\\cloning\\Operation.qs"
            var num1_state = 0L;
#line 33 "C:\\Users\\Davidelocal\\source\\repos\\cloning\\cloning\\Operation.qs"
            var num1_three = 0L;
            //these are the three qubits used in the operation. 
#line 35 "C:\\Users\\Davidelocal\\source\\repos\\cloning\\cloning\\Operation.qs"
            var qubits = Allocate.Apply(3L);
#line 37 "C:\\Users\\Davidelocal\\source\\repos\\cloning\\cloning\\Operation.qs"
            var state = qubits[0L];
#line 39 "C:\\Users\\Davidelocal\\source\\repos\\cloning\\cloning\\Operation.qs"
            var two = qubits[1L];
#line 40 "C:\\Users\\Davidelocal\\source\\repos\\cloning\\cloning\\Operation.qs"
            var three = qubits[2L];
#line 41 "C:\\Users\\Davidelocal\\source\\repos\\cloning\\cloning\\Operation.qs"
            foreach (var test in new Range(1L, count))
            {
#line 43 "C:\\Users\\Davidelocal\\source\\repos\\cloning\\cloning\\Operation.qs"
                Set.Apply((state, initial));
                //this line applies the desired rotation to the first qubit. It is(as usal, set at |0>)
#line 45 "C:\\Users\\Davidelocal\\source\\repos\\cloning\\cloning\\Operation.qs"
                rotation.Apply((state, rando));
#line 46 "C:\\Users\\Davidelocal\\source\\repos\\cloning\\cloning\\Operation.qs"
                Set.Apply((two, Result.Zero));
#line 47 "C:\\Users\\Davidelocal\\source\\repos\\cloning\\cloning\\Operation.qs"
                MicrosoftQuantumPrimitiveX.Apply(two);
                //This flips the second qubit
                //The fun part begins here. Lets apply the Toffoli gate and measure some qubits.
#line 50 "C:\\Users\\Davidelocal\\source\\repos\\cloning\\cloning\\Operation.qs"
                Set.Apply((three, Result.Zero));
#line 51 "C:\\Users\\Davidelocal\\source\\repos\\cloning\\cloning\\Operation.qs"
                MicrosoftQuantumPrimitiveCCNOT.Apply((state, two, three));
#line 52 "C:\\Users\\Davidelocal\\source\\repos\\cloning\\cloning\\Operation.qs"
                var res_state = M.Apply(state);
#line 53 "C:\\Users\\Davidelocal\\source\\repos\\cloning\\cloning\\Operation.qs"
                var res_three = M.Apply(three);
#line 54 "C:\\Users\\Davidelocal\\source\\repos\\cloning\\cloning\\Operation.qs"
                if ((res_state == Result.One))
                {
#line 56 "C:\\Users\\Davidelocal\\source\\repos\\cloning\\cloning\\Operation.qs"
                    num1_state = (num1_state + 1L);
                }

#line 58 "C:\\Users\\Davidelocal\\source\\repos\\cloning\\cloning\\Operation.qs"
                if ((res_three == Result.One))
                {
#line 60 "C:\\Users\\Davidelocal\\source\\repos\\cloning\\cloning\\Operation.qs"
                    num1_three = (num1_three + 1L);
                }
            }

#line 63 "C:\\Users\\Davidelocal\\source\\repos\\cloning\\cloning\\Operation.qs"
            Set.Apply((qubits[1L], Result.Zero));
#line 64 "C:\\Users\\Davidelocal\\source\\repos\\cloning\\cloning\\Operation.qs"
            Set.Apply((qubits[2L], Result.Zero));
#line 65 "C:\\Users\\Davidelocal\\source\\repos\\cloning\\cloning\\Operation.qs"
            Set.Apply((qubits[0L], Result.Zero));
#line hidden
            Release.Apply(qubits);
#line 67 "C:\\Users\\Davidelocal\\source\\repos\\cloning\\cloning\\Operation.qs"
            return ((count - num1_state), num1_state, (count - num1_three), num1_three);
        }

        ;
        public override void Init()
        {
            this.Allocate = this.Factory.Get<Allocate>(typeof(Microsoft.Quantum.Primitive.Allocate));
            this.MicrosoftQuantumPrimitiveCCNOT = this.Factory.Get<IUnitary<(Qubit,Qubit,Qubit)>>(typeof(Microsoft.Quantum.Primitive.CCNOT));
            this.M = this.Factory.Get<ICallable<Qubit, Result>>(typeof(Microsoft.Quantum.Primitive.M));
            this.Release = this.Factory.Get<Release>(typeof(Microsoft.Quantum.Primitive.Release));
            this.Set = this.Factory.Get<ICallable<(Qubit,Result), QVoid>>(typeof(Quantum.cloning.Set));
            this.MicrosoftQuantumPrimitiveX = this.Factory.Get<IUnitary<Qubit>>(typeof(Microsoft.Quantum.Primitive.X));
            this.rotation = this.Factory.Get<ICallable<(Qubit,Double), QVoid>>(typeof(Quantum.cloning.rotation));
        }

        public override IApplyData __dataIn((Int64,Double,Result) data) => new In(data);
        public override IApplyData __dataOut((Int64,Int64,Int64,Int64) data) => new Out(data);
        public static System.Threading.Tasks.Task<(Int64,Int64,Int64,Int64)> Run(IOperationFactory __m__, Int64 count, Double rando, Result initial)
        {
            return __m__.Run<cloning, (Int64,Double,Result), (Int64,Int64,Int64,Int64)>((count, rando, initial));
        }
    }
}