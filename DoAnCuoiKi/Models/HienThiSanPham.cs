using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DoAnCuoiKi.Models
{
    public class HienThiSanPham
    {
        public int ID { get; set; }
        public string TenSP { get; set; }
        public string MoTaSP { get; set; }
        public string ThongTinSP { get; set; }
        public Nullable<bool> HienGiaCu { get; set; }
        public Nullable<bool> HienThi { get; set; }
        public string TinhTrang { get; set; }
        public string ChinhSachBH { get; set; }
        public string KhuyenMai { get; set; }
        public Nullable<double> GiaMoi { get; set; }
        public Nullable<double> GiaCu { get; set; }
        public string TenDM { get; set; }
        public string TenNCC { get; set; }
        public string AnhHienThi { get; set; }
        public string TenTheLoai { get; set; }
        public List<string> Anhs { get; set; }
        public int? SLTon { get; set; }

    }
}