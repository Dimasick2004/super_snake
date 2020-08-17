using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    struct coordinat
    {
        public int x;
        public int y;
    }
    class snake
    {
        static int width = 20;
        static int height = 20;
        public char Navigation = 'L';
        public char WantNavigation = 'N';

        public List<coordinat> coordinats = new List<coordinat>();
        public snake()
        {
            coordinats.Add(new coordinat() { x = width / 2, y = height / 2 });
            coordinats.Add(new coordinat() { x = width / 2 + 1, y = height / 2 });
        }
        public void Move()
        {
            if (WantNavigation != 'N')
            {
                if (WantNavigation == 'L' && Navigation == 'R') Navigation = WantNavigation;
                if (WantNavigation == 'R' && Navigation == 'L') Navigation = WantNavigation;
                if (WantNavigation == 'T' && Navigation == 'D') Navigation = WantNavigation;
                if (WantNavigation == 'D' && Navigation == 'T') Navigation = WantNavigation;
            }
            switch (Navigation)
            {
                case 'L':
                    {
                        var temp = coordinats[0];
                        temp.x--;
                        coordinats[0] = temp;
                        break;
                    }
                case 'R':
                    {
                        var temp = coordinats[0];
                        temp.x++;
                        coordinats[0] = temp;
                        break;
                    }
                case 'T':
                    {
                        var temp = coordinats[0];
                        temp.y--;
                        coordinats[0] = temp;
                        break;
                    }
                case 'D':
                    {
                        var temp = coordinats[0];
                        temp.y++;
                        coordinats[0] = temp;
                        break;
                    }
            }
        }
    }
}
