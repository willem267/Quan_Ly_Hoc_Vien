using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHV
{
    class XuLyHOCVIEN
    {
        CHocVien hvdal;
        public XuLyHOCVIEN()
        {
            hvdal = new CHocVien();
        }

        public DataTable getALLHV()
        {
            return hvdal.getALLHV();
        }
        public bool ThemHV(HOCVIEN hv)
        {
            return hvdal.ThemHV(hv);

        }
        public bool SuaHV(HOCVIEN hv)
        {
            return hvdal.SuaHV(hv);
        }
        public bool XoaHV(HOCVIEN hv)
        {
            return hvdal.XoaHV(hv);
        }
        public DataTable findHV(string hv)
        {
            return hvdal.findHV(hv);
        }
    }
}
