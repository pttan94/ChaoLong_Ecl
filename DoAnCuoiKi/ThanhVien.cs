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
    
    public partial class ThanhVien
    {
        public ThanhVien()
        {
            this.DonHangs = new HashSet<DonHang>();
        }
    
        public string Email { get; set; }
        public string TenTV { get; set; }
        public string MatKhau { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public Nullable<System.DateTime> NgayTao { get; set; }
    
        public virtual ICollection<DonHang> DonHangs { get; set; }
        public virtual QuyenAdmin QuyenAdmin { get; set; }
    }
}
