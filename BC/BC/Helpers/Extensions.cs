namespace BC
{
    public static class Extensions
    {
        public static float ToDpi(this float centimeter)
        {
            var inch = centimeter / 2.54;
            return (float)(inch * 72);
        }
        public static float ToDpI(this float inch)
        {
            return (float)(inch * 72);
        }
    }
}