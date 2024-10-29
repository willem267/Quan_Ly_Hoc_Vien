using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHV
{
    internal class XuLyLOP
    {
        CLop lopdal;
        public XuLyLOP()
        {
            lopdal = new CLop();
        }
        public DataTable getALLLOP()
        {
            return lopdal.getALLLOP();

        }
        public bool themLop(LOPHOC lp)
        {
            return lopdal.themLop(lp);
        }
        public bool suaLop(LOPHOC lp)
        {
            return lopdal.suaLop(lp);
        }
        public bool xoaLop(LOPHOC lp)
        {
            return lopdal.xoaLop(lp);
        }
        public DataTable findLop(string s)
        {
            return lopdal.findLop(s);
        }
    }
}
