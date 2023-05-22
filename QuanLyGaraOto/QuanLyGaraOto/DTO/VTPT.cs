using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGaraOto.DTO
{
    public class VTPT
    {public VTPT (int mavtpt, string tenvtpt, int dongianhap, int dongiaban, int soluongton)
        {
            this.MAVTPT = mavtpt;
            this.TENVTPT = tenvtpt;
            this.DONGIANHAP = dongianhap;
            this.DONGIABAN = dongiaban;
            this.SOLUONGTON = soluongton;
        }
        public VTPT(DataRow row)
        {
            this.MAVTPT = (int)row["mavtpt"];
            this.TENVTPT = row["tenvtpt"].ToString();
            this.DONGIANHAP = (int)Convert.ToDouble(row["dongianhap"].ToString());
            this.DONGIABAN = (int)Convert.ToDouble(row["dongiaban"].ToString());
            this.SOLUONGTON = (int)Convert.ToDouble(row["soluongton"].ToString());
        }

        private int mAVTPT;
        public int MAVTPT
        {
            get { return mAVTPT; }
            set { mAVTPT = value; }
        }

        private string tENVTPT;
        public string TENVTPT
        {
            get { return tENVTPT; }
            set { tENVTPT = value; }
        }

        private int dONGIANHAP;
        public int DONGIANHAP
        {
            get { return dONGIANHAP; }
            set { dONGIANHAP = value; }
        }

        private int dONGIABAN;
        public int DONGIABAN
        {
            get { return dONGIABAN; }
            set { dONGIABAN = value; }
        }

        private int sOLUONGTON;
        public int SOLUONGTON
        {
            get { return sOLUONGTON; }
            set { sOLUONGTON = value; }
        }

    }
}
