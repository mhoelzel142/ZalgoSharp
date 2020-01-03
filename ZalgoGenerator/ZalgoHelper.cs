using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace ZalgoGenerator
{
    static class ZalgoHelper
    {
        static readonly Random Rnd = new Random();

        //those go UP
        public static char[] ZalgoUp = {
        '\u030d', /*     Ì     */        '\u030e', /*     ÌŽ     */        '\u0304', /*     Ì„     */       '\u0305', /*     Ì…     */
        '\u033f', /*     Ì¿     */        '\u0311', /*     Ì‘     */       '\u0306', /*     Ì†     */       '\u0310', /*     Ì     */
        '\u0352', /*     Í’     */       '\u0357', /*     Í—     */       '\u0351', /*     Í‘     */       '\u0307', /*     Ì‡     */
        '\u0308', /*     Ìˆ     */        '\u030a', /*     ÌŠ     */        '\u0342', /*     Í‚     */       '\u0343', /*     Ì“     */
        '\u0344', /*     ÌˆÌ     */        '\u034a', /*     ÍŠ     */        '\u034b', /*     Í‹     */       '\u034c', /*     ÍŒ     */
        '\u0303', /*     Ìƒ     */        '\u0302', /*     Ì‚     */       '\u030c', /*     ÌŒ     */        '\u0350', /*     Í     */
        '\u0300', /*     Ì€     */       '\u0301', /*     Ì     */        '\u030b', /*     Ì‹     */       '\u030f', /*     Ì     */
        '\u0312', /*     Ì’     */       '\u0313', /*     Ì“     */       '\u0314', /*     Ì”     */       '\u033d', /*     Ì½     */
        '\u0309', /*     Ì‰     */       '\u0363', /*     Í£     */        '\u0364', /*     Í¤     */        '\u0365', /*     Í¥     */
        '\u0366', /*     Í¦     */        '\u0367', /*     Í§     */        '\u0368', /*     Í¨     */        '\u0369', /*     Í©     */
        '\u036a', /*     Íª     */        '\u036b', /*     Í«     */        '\u036c', /*     Í¬     */        '\u036d', /*     Í­     */
        '\u036e', /*     Í®     */        '\u036f', /*     Í¯     */        '\u033e', /*     Ì¾     */        '\u035b', /*     Í›     */
        '\u0346', /*     Í†     */       '\u031a' /*     Ìš     */
                   };

        //those go DOWN
        public static char[] ZalgoDown = {
        '\u0316', /*     Ì–     */       '\u0317', /*     Ì—     */       '\u0318', /*     Ì˜     */        '\u0319', /*     Ì™     */
        '\u031c', /*     Ìœ     */        '\u031d', /*     Ì     */        '\u031e', /*     Ìž     */        '\u031f', /*     ÌŸ     */
        '\u0320', /*     Ì      */     '\u0324', /*     Ì¤     */        '\u0325', /*     Ì¥     */        '\u0326', /*     Ì¦     */
        '\u0329', /*     Ì©     */        '\u032a', /*     Ìª     */        '\u032b', /*     Ì«     */        '\u032c', /*     Ì¬     */
        '\u032d', /*     Ì­     */        '\u032e', /*     Ì®     */        '\u032f', /*     Ì¯     */        '\u0330', /*     Ì°     */
        '\u0331', /*     Ì±     */        '\u0332', /*     Ì²     */        '\u0333', /*     Ì³     */        '\u0339', /*     Ì¹     */
        '\u033a', /*     Ìº     */        '\u033b', /*     Ì»     */        '\u033c', /*     Ì¼     */        '\u0345', /*     Í…     */
        '\u0347', /*     Í‡     */       '\u0348', /*     Íˆ     */        '\u0349', /*     Í‰     */       '\u034d', /*     Í     */
        '\u034e', /*     ÍŽ     */        '\u0353', /*     Í“     */       '\u0354', /*     Í”     */       '\u0355', /*     Í•     */
        '\u0356', /*     Í–     */       '\u0359', /*     Í™     */       '\u035a', /*     Íš     */        '\u0323' /*     Ì£     */
                     };
        

        //those always stay in the middle
        public static char[] ZalgoMid = {
            
            '\u0315', /*     Ì•     */       '\u031b', /*     Ì›     */       '\u0340', /*     Ì€     */       '\u0341', /*     Ì     */
        '\u0358', /*     Í˜     */        '\u0321', /*     Ì¡     */        '\u0322', /*     Ì¢     */        '\u0327', /*     Ì§     */
        '\u0328', /*     Ì¨     */        '\u0334', /*     Ì´     */        '\u0335', /*     Ìµ     */        '\u0336', /*     Ì¶     */
        '\u034f', /*     Í     */        '\u035c', /*     Íœ     */        '\u035d', /*     Í     */        '\u035e', /*     Íž     */
        '\u035f', /*     ÍŸ     */        '\u0360', /*     Í      */     '\u0362', /*     Í¢     */        '\u0338', /*     Ì¸     */
        //'\u0337', /*     Ì·     */      '\u0361', /*     Í¡     */        '\u0489' /*     Ò‰_     */      
                    };

        public static bool IsZalgoChar(char c)
        {
            if (ZalgoDown.Contains(c) ||
                ZalgoMid.Contains(c) ||
                ZalgoUp.Contains(c))
                return true;
            return false;
        }

        public enum ZalgoSize
        {
            Mini, Normal, Maxi
        }

        public static string ToZalgo(this string text, ZalgoSize size = ZalgoSize.Normal)
        {
            var newtxt = "";

            for (var i = 0; i < text.Length; i++)
            {
                if (IsZalgoChar(text.ToCharArray()[i]))
                    continue;

                newtxt += text.ToCharArray()[i];
                newtxt += GetZalgo();
            }

            return newtxt;
        }

        public static string GetZalgo(ZalgoSize size = ZalgoSize.Normal)
        {
            var newtxt = "";
            var numUp = 0;
            var numMid = 0;
            var numDown = 0;

            switch (size)
            {
                case ZalgoSize.Mini:
                    numUp = Rnd.Next(1, 8);
                    numMid = Rnd.Next(1, 2);
                    numDown = Rnd.Next(1, 8);
                    break;
                case ZalgoSize.Normal:
                    numUp = Rnd.Next(1, 16) / 2 + 1;
                    numMid = Rnd.Next(1, 6) / 2;
                    numDown = Rnd.Next(1, 16) / 2 + 1;
                    break;
                case ZalgoSize.Maxi:
                    numUp = Rnd.Next(1, 64) / 4 + 3;
                    numMid = Rnd.Next(1, 16) / 4 + 1;
                    numDown = Rnd.Next(1, 64) / 4 + 3;
                    break;
            }

            for (var j = 0; j < numUp; j++)
                newtxt += RandZalgo(ZalgoUp);
            for (var j = 0; j < numMid; j++)
                newtxt += RandZalgo(ZalgoMid);
            for (var j = 0; j < numDown; j++)
                newtxt += RandZalgo(ZalgoDown);


            return newtxt;
        }


        static char RandZalgo(IList<char> set)
        {
            var r = Rnd.Next(1, set.Count);
            return set[r];
        }
    }
}