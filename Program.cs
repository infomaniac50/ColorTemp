using CommandLine;
using System;

namespace ColorTemp
{
    internal class Program
    {
        private static int ConvertTemperatureToRgb(RgbOptions opts)
        {
            Color color = ColorTemperature.GetColorFromTemperature(opts.Temperature);

            Console.Write("RGB: {0:F2}, {1:F2}, {2:F2}", color.R, color.G, color.B);
            
            return 0;
        }

        private static int Main(string[] args)
        {
            return CommandLine.Parser.Default.ParseArguments<RgbOptions>(args)
                .MapResult(
                    (RgbOptions opts) => ConvertTemperatureToRgb(opts),
                    errs => 1);
        }

        [Verb("rgb", HelpText = "Convert color temperature to RGB.")]
        public class RgbOptions
        {
            [Value(0, MetaName = "temperature", HelpText = "The color temperature in Kelvins.", Required = true)]
            public double Temperature { get; set; }
        }
    }
}
