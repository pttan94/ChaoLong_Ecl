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
    
    public partial class SanPhamDuocChon
    {
        public string ID { get; set; }
        public string IDGioHang { get; set; }
        public int IDSanPham { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<System.DateTime> NgayTao { get; set; }
    
        public virtual SanPham SanPham { get; set; }
    }
}
