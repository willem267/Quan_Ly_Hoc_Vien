using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHV
{
    class XuLyBienLai
    {
        CBienLai bldal;
        public XuLyBienLai()
        {
            bldal = new CBienLai();
        }
        public DataTable getALLBL()
        {
            return bldal.getALLBL();
        }
        public bool themBL(BIENLAI bl)
        {
            return bldal.themBL(bl);
        }
        public bool suaBL(BIENLAI bl)
        {
            return bldal.suaBL(bl);
        }
        public bool xoaBL(BIENLAI bl)
        {
            return bldal.xoaBL(bl);
        }
        public DataTable findBL(string s)
        {
            return bldal.findBL(s);
        }


    }
}