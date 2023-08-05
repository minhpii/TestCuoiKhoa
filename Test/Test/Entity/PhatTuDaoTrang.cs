using System.ComponentModel.DataAnnotations;

namespace Test.Entity
{
    public class PhatTuDaoTrang
    {
        [Key]
        public int PhanTuDaoTrangId { get; set; }
        public bool? DaThamGia { get; set; }
        public string? LyDoKhongThamGia { get; set; }
        public int DaoTrangId { get; set; }
        public DaoTrang? DaoTrang { get; set; }
        public int PhanTuId { get; set; }
        public PhatTu? PhatTu { get; set; }
    }
}
