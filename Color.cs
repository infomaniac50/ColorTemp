namespace ColorTemp
{
    public struct Color
    {
        public Color(double value) : this()
        {
            R = value;
            G = value;
            B = value;
        }

        public Color(double R, double G, double B) : this()
        {
            this.R = R;
            this.G = G;
            this.B = B;
        }

        public double R { get; set; }
        public double G { get; set; }
        public double B { get; set; }
    }
}
