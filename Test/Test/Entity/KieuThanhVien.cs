﻿namespace Test.Entity
{
    public class KieuThanhVien
    {
        public int KieuThanhVienId { get; set; }
        public string? Code { get; set; }
        public string? TenKieu { get; set; }
        public IEnumerable<PhatTu>? PhatTu { get; set; }
    }
}
