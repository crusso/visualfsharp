

// encoding Haskell subclassing...
// overloading numeric operations that also implement equality (thus passing fewer dictionaries to MemSq.
namespace NumEqWithDefaults {
	
  /* Haskell allows default implementations in classes that may be overriden in instances
   * 
   * We can emulate this by putting the body of the default method (e.g. Subtract) in an separate
   * helper class carrying its implementation.
   * 
   * Instance declarations either re-implement or delegate to the default.
   * 
   * Q: What about overrides in derived classes (not just instances?)
   */

  using System;

  using Eq;
   
  concept Num<A> : Eq<A> {
    A Add(A a, A b);
    A Mult(A a, A b);
    A Neg(A a);
    A Subtract(A a, A b);
   /* default:
    { return Add(A,Neg(b));
    }
	*/
    

  }

    // type containing default implementations of methods in Num<A>
    // could also be a (static) class.
    struct NumDefaults {
        public static A Subtract<A>(A a, A b) where NumA : Num<A> => Add(a, Neg(b));
    }


    instance NumInt : Num<int> {
        bool Equals(int a, int b) => EqInt.Equals(a, b);
        int Add(int a, int b) => a + b;
        int Mult(int a, int b) => a * b;
        int Neg(int a) => -a;
        int Subtract(int a, int b)
           => NumDefaults.Subtract(a, b); // still a direct call.
    }


	// similar, but overrides default Substract.
    instance NumFloat : Num<float> {
        bool Equals(float a, float b) => EqFloat.Equals(a, b);
        float Add(float a, float b) => a + b;
        public float Mult(float a, float b) => a * b;
        public float Neg(float a) => -a;
        public float Subtract(float a, float b) => a - b;
    }
}
