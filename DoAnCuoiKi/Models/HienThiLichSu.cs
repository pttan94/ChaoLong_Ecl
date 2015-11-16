using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoAnCuoiKi.Models
{
    class HienThiLichSu
    {
        public int ID { get; set; }

        public string anhHienThi { get; set; }

        public string tenSP { get; set; }

        public string tenTheLoai { get; set; }

        public string emailNguoiMua { get; set; }

        public Nullable<double> donGia { get; set; }
        public Nullable<double> thanhTien { get; set; }
    }
}
