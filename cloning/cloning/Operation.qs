namespace Quantum.cloning
{
    open Microsoft.Quantum.Primitive;
    open Microsoft.Quantum.Canon;
	//These are the usual operations which allow the application of a rotation in respect of the x axis of the bloch sphere
	//and the flip of the qubit in the case of undesired state being measured.
	operation rotation (q1 : Qubit, rnd : Double) : ()
	{
		body
		{
			Rx(rnd,q1);
		}
	}
	operation Set (q1: Qubit, desired : Result) : ()
	{
	body{
		let current = M(q1);
		if (current != desired)
		{
			X(q1);
		}
		}
	}
	// Here the program uses a Toffoli gate in which a given (and unknown) state is used as first control. The second control qubit is set to one,
	// (originally set to 0, then a qb-flip is applied). The target qubit is set to zero, then, we'll see.
    operation cloning ( count : Int, rando : Double, initial : Result) : (Int,Int,Int,Int)
    {
        body
        {
		//These two variables will contain the number of ones measured during a run of a number _count_ of qubit, one is used for the original qubit (which we hope
		// it's nice enough to not change its behavior), one is used in the measure of the third qubit (which we hope NOT TO BE IN THE SAME STATE)
         mutable num1_state = 0;
		 mutable num1_three = 0; 
		 //these are the three qubits used in the operation. 
		 using (qubits = Qubit[3])
		 {
		     let state = qubits[0];
			 
			 let two = qubits[1];
			 let three = qubits[2];
			 for(test in 1..count)
			 {
				Set(state,initial);
			 //this line applies the desired rotation to the first qubit. It is(as usal, set at |0>)
				rotation(state,rando);
				Set(two,Zero);
				X(two);
			 //This flips the second qubit
			 //The fun part begins here. Lets apply the Toffoli gate and measure some qubits.
				Set(three,Zero);
			 	 CCNOT(state, two, three);
				 let res_state = M(state);
				 let res_three = M(three);
				 if (res_state == One)
				 {
				 	 set num1_state = num1_state + 1;
				 }
				 if (res_three == One)
				 {
				 	 set num1_three = num1_three + 1;
				 }
			 }
			 Set(qubits[1],Zero);
			 Set(qubits[2],Zero);
			 Set(qubits[0],Zero);
		 }
		 return(count-num1_state,num1_state,count-num1_three,num1_three);
        }
    }
}
