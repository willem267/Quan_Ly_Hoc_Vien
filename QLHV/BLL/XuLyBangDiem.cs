using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHV
{
    class XuLyBangDiem
    {
        CBangDiem bddal;
        public XuLyBangDiem()
        {
            bddal = new CBangDiem();
        }
        public DataTable getAllBD()
        {
            return bddal.getALLBD();
        }
        public bool themBD(BANGDIEM bd)
        {
            return bddal.themBD(bd);
        }
        public bool suaBD(BANGDIEM bd)
        {
            return bddal.suaBD(bd);

        }
        public bool xoaBD(BANGDIEM bd)
        {
            return bddal.xoaBD(bd);
        }
        public DataTable findBD(string s)
        {
            return bddal.findBD(s);
        }
    }
}
