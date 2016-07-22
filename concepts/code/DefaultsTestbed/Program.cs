using System;
using System.Concepts;

namespace DefaultsTestbed
{
    class Program
    {
        concept Eq<A>
        {
            bool Eq(A a, A b);
            bool Neq(A a, A b);
        }

        concept Show<A>
        {
            string Show(A a);
            void Println(A a);
        }

        [ConceptDefault]
        struct Eq_default<A> where EqA : Eq<A>
        {
            public bool Eq(A a, A b) => !EqA.Neq(a, b);
            public bool Neq(A a, A b) => !EqA.Eq(a, b);
        }

        [ConceptDefault]
        struct Show_default<A> where ShowA : Show<A>
        {
            public void Println(A a) => Console.Out.WriteLine(Show(a));
        }

        instance EqInt : Eq<int>
        {
            bool Eq(int a, int b) => a == b;
        }

        instance ShowBool : Show<bool>
        {
            string Show(bool a) => a ? "yes" : "no";
        }

        static void Main(string[] args)
        {
            ShowBool.Println(EqInt.Eq(27, 53));
            ShowBool.Println(EqInt.Neq(27, 53));
        }
    }
}
