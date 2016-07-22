using System.Concepts.Prelude;

namespace BeautifulDifferentiation
{
    /// <summary>
    ///     Numeric utility functions.
    /// </summary>
    static class NumUtils
    {
        /// <summary>
        ///     The zero of a numeric class.
        /// </summary>
        /// <returns>
        ///     Zero.
        /// </returns>
        public static A Zero<A>() where NumA : Num<A> => FromInteger(0);

        /// <summary>
        ///     The unity of a numeric class.
        /// </summary>
        /// <returns>
        ///     One.
        /// </returns>
        public static A One<A>() where NumA : Num<A> => FromInteger(1);

        /// <summary>
        ///     The two of a numeric class.
        /// </summary>
        /// <returns>
        ///     Two.
        /// </returns>
        public static A Two<A>() where NumA : Num<A> => FromInteger(2);

        /// <summary>
        ///     Calculates the negation of a number.
        /// </summary>
        /// <param name="x">
        ///     The number to negate.
        /// </param>
        /// <returns>
        ///     The negation of <paramref name="x"/>.
        /// </returns>
        public static A Neg<A>(A x) where NumA : Num<A> => Mul(FromInteger(-1), x);

        /// <summary>
        ///     Calculates the square of a number.
        /// </summary>
        /// <param name="x">
        ///     The number to square.
        /// </param>
        /// <returns>
        ///     The square of <paramref name="x"/>.
        /// </returns>
        public static A Square<A>(A x) where NumA : Num<A> => Mul(x, x);

        /// <summary>
        ///     Calculates the reciprocal of a number.
        /// </summary>
        /// <param name="x">
        ///     The number to reciprocate.
        /// </param>
        /// <returns>
        ///     The reciprocal of <paramref name="x"/>.
        /// </returns>
        public static A Recip<A>(A x) where FracA : Fractional<A> => Div(FromInteger(1), x);
    }

}