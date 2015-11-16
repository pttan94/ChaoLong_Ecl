﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class WebEntities : DbContext
    {
        public WebEntities()
            : base("name=WebEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual DbSet<DanhMucSanPham> DanhMucSanPhams { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<HinhAnhSanPham> HinhAnhSanPhams { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<QuyenAdmin> QuyenAdmins { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<ThanhVien> ThanhViens { get; set; }
        public virtual DbSet<TheLoaiSP> TheLoaiSPs { get; set; }
        public virtual DbSet<SanPhamDuocChon> SanPhamDuocChons { get; set; }
        public virtual DbSet<LienHe> LienHes { get; set; }
    
        public virtual ObjectResult<hienthisp_Result> hienthisp()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<hienthisp_Result>("hienthisp");
        }
    
        public virtual ObjectResult<string> danhsachnhacungcap(string tendanhmuc)
        {
            var tendanhmucParameter = tendanhmuc != null ?
                new ObjectParameter("tendanhmuc", tendanhmuc) :
                new ObjectParameter("tendanhmuc", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("danhsachnhacungcap", tendanhmucParameter);
        }
    
        public virtual ObjectResult<hienthisp_Result> sanphamtheo_danhmuc_nhacc(string danhmuc, string nhacc)
        {
            var danhmucParameter = danhmuc != null ?
                new ObjectParameter("danhmuc", danhmuc) :
                new ObjectParameter("danhmuc", typeof(string));
    
            var nhaccParameter = nhacc != null ?
                new ObjectParameter("nhacc", nhacc) :
                new ObjectParameter("nhacc", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<hienthisp_Result>("sanphamtheo_danhmuc_nhacc", danhmucParameter, nhaccParameter);
        }
    
        public virtual ObjectResult<hienthisp_Result> sanphamtheo_danhmuc(string danhmuc)
        {
            var danhmucParameter = danhmuc != null ?
                new ObjectParameter("danhmuc", danhmuc) :
                new ObjectParameter("danhmuc", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<hienthisp_Result>("sanphamtheo_danhmuc", danhmucParameter);
        }
    
        public virtual ObjectResult<hienthisp_Result> sanphamtheo_danhmuc_nhacc_mucgia(string danhmuc, string nhacc, Nullable<double> giamin, Nullable<double> giamax)
        {
            var danhmucParameter = danhmuc != null ?
                new ObjectParameter("danhmuc", danhmuc) :
                new ObjectParameter("danhmuc", typeof(string));
    
            var nhaccParameter = nhacc != null ?
                new ObjectParameter("nhacc", nhacc) :
                new ObjectParameter("nhacc", typeof(string));
    
            var giaminParameter = giamin.HasValue ?
                new ObjectParameter("giamin", giamin) :
                new ObjectParameter("giamin", typeof(double));
    
            var giamaxParameter = giamax.HasValue ?
                new ObjectParameter("giamax", giamax) :
                new ObjectParameter("giamax", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<hienthisp_Result>("sanphamtheo_danhmuc_nhacc_mucgia", danhmucParameter, nhaccParameter, giaminParameter, giamaxParameter);
        }
    
        public virtual ObjectResult<TimKiemSanPham_Result2> TimKiemSanPham(Nullable<bool> allWords, string word1, string word2, string word3, string word4, string word5)
        {
            var allWordsParameter = allWords.HasValue ?
                new ObjectParameter("AllWords", allWords) :
                new ObjectParameter("AllWords", typeof(bool));
    
            var word1Parameter = word1 != null ?
                new ObjectParameter("Word1", word1) :
                new ObjectParameter("Word1", typeof(string));
    
            var word2Parameter = word2 != null ?
                new ObjectParameter("Word2", word2) :
                new ObjectParameter("Word2", typeof(string));
    
            var word3Parameter = word3 != null ?
                new ObjectParameter("Word3", word3) :
                new ObjectParameter("Word3", typeof(string));
    
            var word4Parameter = word4 != null ?
                new ObjectParameter("Word4", word4) :
                new ObjectParameter("Word4", typeof(string));
    
            var word5Parameter = word5 != null ?
                new ObjectParameter("Word5", word5) :
                new ObjectParameter("Word5", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TimKiemSanPham_Result2>("TimKiemSanPham", allWordsParameter, word1Parameter, word2Parameter, word3Parameter, word4Parameter, word5Parameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    }
}