using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHV
{
    class XuLyGiaoVien
    {
        CGiaoVien gvdal;
        public XuLyGiaoVien()
        {
            gvdal = new CGiaoVien();
        }

        public DataTable getALLGV()
        {
            return gvdal.getALLGV();
        }
        public bool themGV(GIAOVIEN gv)
        {
            return gvdal.themGV(gv);
        }
        public bool suaGV(GIAOVIEN gv)
        {
            return gvdal.suaGV(gv);
        }
        public bool xoaGV(GIAOVIEN gv)
        {
            return gvdal.xoaGV(gv);
        }
        public DataTable findGV(string s)
        {
            return gvdal.findGV(s);
        }
    }


}
