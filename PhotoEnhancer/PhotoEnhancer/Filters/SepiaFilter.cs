using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    class SepiaFilter : PixelFilter
    {
        public SepiaFilter() : base(new SepiaParameters()) {}

        public override string ToString()
        {
            return "Сепия";
        }
        public override Pixel ProcessPixel(Pixel originalPixel, IParameters parameters)
        {
            var origH = Convertors.GetPixelHue(originalPixel);
            var origS = Convertors.GetPixelSaturation(originalPixel);
            var origL = Convertors.GetPixelLightness(originalPixel);


            var newH = (parameters as SepiaParameters).SepiaParameterHueByUser;
            var newS = (parameters as SepiaParameters).SepiaParameterSaturationByUser;
            return Convertors.HSL2Pixel(newH, newS, origL);
        }
    }
}
