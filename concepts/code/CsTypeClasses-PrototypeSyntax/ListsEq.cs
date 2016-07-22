
// Like Lists, but with a more extensible equality operation.

namespace ListsEq
{
    using System;
    using Eq;

    delegate B Fun<A, B>(A a);

    abstract class List<A>
    {
        public abstract List<B> Map<B>(Fun<A, B> f);
        public abstract bool Mem(A a) where EqA : Eq<A>;

        //a contrived version of Mem that recurses on a list of lists, so needing a dynamically constructed dictionary.
        public abstract bool AltMem(A a) where EqA : Eq<A>;
        public abstract bool Eq(List<A> a) where EqA : Eq<A>;
    }

    class Nil<A> : List<A>
    {
        public override List<B> Map<B>(Fun<A, B> f)
        {
            return new Nil<B>();
        }

        public override bool Mem(A a) where EqA : concept
        {
            return false;
        }

        public override bool AltMem(A a) where EqA : concept
        {
            return false;
        }

        public override bool Eq(List<A> a) where EqA : concept
        {
            return (a != null) && (a as Nil<A> != null);
        }
    }

    class Cons<A> : List<A>
    {
        public A h;
        public List<A> t;

        public override List<B> Map<B>(Fun<A, B> f)
        {
            return new Cons<B>(f(h), t.Map(f));
        }

        public override bool Mem(A a) where EqA : concept
        {
            return Overloads.Eq(a, h) || t.Mem(a);
            //return Eq(a, h) || t.Mem(a);
        }

        public override bool AltMem(A a) where EqA : concept
        {
            Fun<A, List<A>> wrap = delegate (A e) { return new Cons<A>(e, new Nil<A>()); };
            return Overloads.Eq(a, h) || t.Map(wrap).Mem(wrap(a));
            //return Eq(a,h) || t.Map(wrap).Mem(wrap(a));
        }

        public override bool Eq(List<A> a) where EqA : concept
        {
            Cons<A> ca = a as Cons<A>;
            return (a != null) && ca != null && Overloads.Eq(h, ca.h) && t.Eq(ca.t);
        }

        public Cons(A h, List<A> t)
        {
            this.h = h; this.t = t;
        }

    }

    instance EqList<A> : Eq<List<A>> where EqA : Eq<A>
    {
        bool Equals(List<A> a, List<A> b)
        {
            return (a == null) ? b == null : a.Eq(b);
        }
    }

    static class Test
    {
        static List<A> FromArray<A>(params A[] a)
        {
            List<A> l = new Nil<A>();
            for (int i = a.Length - 1; i >= 0; i--)
            {
                l = new Cons<A>(a[i], l);
            }
            return l;
        }

        public static void Run()
        {
            List<int> l1 = FromArray(1, 2, 3, 4);
            List<int> l2 = FromArray(5, 6, 7, 8);
            Console.WriteLine("ListsEq: Eq(null,null)={0}", Overloads.Eq<List<int>>(null, null));
            Console.WriteLine("ListsEq: Eq(null,l1)={0}", Overloads.Eq(null, l1));
            Console.WriteLine("ListsEq: Eq(l1,null)={0}", Overloads.Eq(l1, null));
            Console.WriteLine("ListsEq: Eq(l1,l1)={0}", Overloads.Eq(l1, l1));
            Console.WriteLine("ListsEq: Eq(l1,l2)={0}", Overloads.Eq(l1, l2));
            List<List<int>> ll1 = FromArray(l1, l2);
            List<List<int>> ll2 = FromArray(l2, l1);

            Console.WriteLine("ListsEq: Eq(null,null)={0}", Overloads.Eq<List<List<int>>>(null, null));
            Console.WriteLine("ListsEq: Eq(null,ll1)={0}", Overloads.Eq(null, ll1));
            Console.WriteLine("ListsEq: Eq(ll1,null)={0}", Overloads.Eq(ll1, null));
            Console.WriteLine("ListsEq: Eq(ll1,ll1)={0}", Overloads.Eq(ll1, ll1));
            Console.WriteLine("ListsEq: Eq(ll1,ll2)={0}", Overloads.Eq(ll1, ll2));
        }
    }
}

