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
    
    public partial class DanhMucSanPham
    {
        public DanhMucSanPham()
        {
            this.SanPhams = new HashSet<SanPham>();
        }
    
        public int ID { get; set; }
        public string TenDM { get; set; }
    
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
