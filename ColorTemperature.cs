using static System.Math;

namespace ColorTemp
{
    public class ColorTemperature
    {
        /*
        http://planetpixelemporium.com/tutorialpages/light.html

        | Light Source    | Kelvin Temperature | RGB Values    |
        |-----------------|--------------------|---------------|
        | Candle          | 1900               | 255, 147, 41  |
        | 40W Tungsten    | 2600               | 255, 197, 143 |
        | 100W Tungsten   | 2850               | 255, 214, 170 |
        | Halogen         | 3200               | 255, 241, 224 |
        | Carbon Arc      | 5200               | 255, 250, 244 |
        | High Noon Sun   | 5400               | 255, 255, 251 |
        | Direct Sunlight | 6000               | 255, 255, 255 |
        | Overcast Sky    | 7000               | 201, 226, 255 |
        | Clear Blue Sky  | 20000              | 64, 156, 255  |
        */

        //Given a temperature (in Kelvin), estimate an RGB equivalent
        public static Color GetColorFromTemperature(double tmpKelvin)
        {
            double tmpCalc;

            //Temperature must fall between 1000 and 40000 degrees
            //All calculations require tmpKelvin / 100, so only do the conversion once
            tmpKelvin = Clamp(tmpKelvin, 1000.0, 40000.0) / 100.0;

            Color RgbEquivalent = new Color();

            //Calculate each color in turn

            //First: red
            if (tmpKelvin <= 66.0)
            {
                RgbEquivalent.R = 255.0;
            }
            else
            {
                //Note: the R-squared value for this approximation is .988
                tmpCalc = tmpKelvin - 60.0;
                tmpCalc = 329.698727446 * Pow(tmpCalc, -0.1332047592);
                RgbEquivalent.R = Clamp(tmpCalc, 0.0, 255.0);
            }

            //Second: green
            if (tmpKelvin <= 66.0)
            {
                //Note: the R-squared value for this approximation is .996
                tmpCalc = tmpKelvin;
                tmpCalc = 99.4708025861 * Log(tmpCalc) - 161.1195681661;
                RgbEquivalent.G = Clamp(tmpCalc, 0.0, 255.0);
            }
            else
            {
                //Note: the R-squared value for this approximation is .987
                tmpCalc = tmpKelvin - 60.0;
                tmpCalc = 288.1221695283 * Pow(tmpCalc, -0.0755148492);
                RgbEquivalent.G = Clamp(tmpCalc, 0.0, 255.0);
            }

            //Third: blue
            if (tmpKelvin >= 66.0)
            {
                RgbEquivalent.B = 255.0;
            }
            else if (tmpKelvin <= 19.0)
            {
                RgbEquivalent.B = 0.0;
            }
            else
            {
                //Note: the R-squared value for this approximation is .998
                tmpCalc = tmpKelvin - 10.0;
                tmpCalc = 138.5177312231 * Log(tmpCalc) - 305.0447927307;
                RgbEquivalent.B = Clamp(tmpCalc, 0.0, 255.0);
            }

            return RgbEquivalent;
        }
    }
}
