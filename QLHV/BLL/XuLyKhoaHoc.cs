using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHV
{
     class XuLyKhoaHoc
    {
        CKhoaHoc khdal;
        public XuLyKhoaHoc()
        {
            khdal = new CKhoaHoc();
        }
        public DataTable getALLKH()
        {
            return khdal.getALLKH();
        }
        public bool themKH(KHOAHOC kh)
        {
            return khdal.themKH(kh);
        }
        public bool suaKH(KHOAHOC kh)
        {
            return khdal.suaKH(kh);
        }
        public bool xoaKH(KHOAHOC kh)
        {
            return khdal.xoaKH(kh);
        }
        public DataTable findKH(string s)
        {
            return khdal.findKH(s);
        }
    }
}
