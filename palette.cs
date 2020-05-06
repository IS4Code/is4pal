using System;
using System.Collections.Generic;
using System.Drawing;

namespace Is4.Graphics
{
    public static class Palette
    {
        public static Color[] Create(int permutation, double gamma)
        {
            var palette = new Color[256];
            Create(palette, 0, permutation, gamma);
            return palette;
        }

        public static void Create(Color[] array, int index, int permutation, double gamma)
        {
            if(array == null) throw new ArgumentNullException(nameof(array));
            if(permutation < 0 || permutation >= 24) throw new ArgumentOutOfRangeException(nameof(permutation));

            // Build the order of axes
            var indices = new List<int> { 0, 1, 2, 3 };
            int i0 = indices[Math.DivRem(permutation, 6, out permutation)];
            indices.Remove(i0);
            int i1 = indices[Math.DivRem(permutation, 2, out permutation)];
            indices.Remove(i1);
            int i2 = indices[permutation];
            indices.Remove(i2);
            int i3 = indices[0];

            var pos = new int[4];
            for(int y = 0; y < 16; y++)
            {
                (pos[0], pos[1]) = (y / 4, y % 4);
                for(int x = 0; x < 16; x++)
                {
                    (pos[2], pos[3]) = (x / 4, x % 4);

                    var (r, g, b, i) = (pos[i0], pos[i1], pos[i2], pos[i3]);

                    double cr, cg, cb;
                    if(r + g + b == 0)
                    {
                        // Black colors
                        cr = cg = cb = i / 48.0;
                    }else{
                        cr = r / 3.0;
                        cg = g / 3.0;
                        cb = b / 3.0;
                        double ci = (3 - i) / 3.0;

                        ci /= 4.0;
                        cr -= ci;
                        cg -= ci;
                        cb -= ci;
                    }
                    if(cr < 0) cr = 0;
                    if(cg < 0) cg = 0;
                    if(cb < 0) cb = 0;

                    cr = Math.Pow(cr, gamma);
                    cg = Math.Pow(cg, gamma);
                    cb = Math.Pow(cb, gamma);

                    array[index + y * 16 + x] = Color.FromArgb((int)Math.Round(cr * 255), (int)Math.Round(cg * 255), (int)Math.Round(cb * 255));
                }
            }
        }
    }
}
