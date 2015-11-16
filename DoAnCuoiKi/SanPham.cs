//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoAnCuoiKi
{
    using System;
    using System.Collections.Generic;
    
    public partial class SanPham
    {
        public SanPham()
        {
            this.ChiTietDonHangs = new HashSet<ChiTietDonHang>();
            this.HinhAnhSanPhams = new HashSet<HinhAnhSanPham>();
            this.TheLoaiSPs = new HashSet<TheLoaiSP>();
            this.SanPhamDuocChons = new HashSet<SanPhamDuocChon>();
        }
    
        public int ID { get; set; }
        public string TenSP { get; set; }
        public string MotaSP { get; set; }
        public Nullable<double> GiaCu { get; set; }
        public Nullable<double> GiaMoi { get; set; }
        public Nullable<bool> HienThiGiaCu { get; set; }
        public string ThongTinSP { get; set; }
        public string TinhTrangSP { get; set; }
        public string ChinhSachBH { get; set; }
        public string KhuyenMai { get; set; }
        public Nullable<int> SLton { get; set; }
        public Nullable<int> ID_DanhMuc { get; set; }
        public Nullable<int> ID_NhaCC { get; set; }
        public Nullable<bool> HienThi { get; set; }
    
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual DanhMucSanPham DanhMucSanPham { get; set; }
        public virtual ICollection<HinhAnhSanPham> HinhAnhSanPhams { get; set; }
        public virtual NhaCungCap NhaCungCap { get; set; }
        public virtual ICollection<TheLoaiSP> TheLoaiSPs { get; set; }
        public virtual ICollection<SanPhamDuocChon> SanPhamDuocChons { get; set; }
    }
}
