namespace Lab3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SACH")]
    public partial class SACH
    {
        [Key]
        public int MaSach { get; set; }

        [Required(ErrorMessage ="Vui lòng điền đầy đủ không để trống")]
        [StringLength(100, ErrorMessage ="Tên sách không vượt quá 100 kí tự!")]
        public string TenSach { get; set; }
        [Required(ErrorMessage = "Vui lòng điền đầy đủ không để trống")]
        [Range(1000, 1000000, ErrorMessage ="Vui lòng nhập trong khoảng 1000 đến 10000000")]
        public decimal? GiaBan { get; set; }
        [Required(ErrorMessage = "Vui lòng điền đầy đủ không để trống")]
        public int? GiaBia { get; set; }
        //[Required(ErrorMessage = "Vui lòng điền đầy đủ không để trống")]
        public string MoTa { get; set; }
        [Required(ErrorMessage = "Vui lòng điền đầy đủ không để trống")]
        [StringLength(250)]
        public string AnhBia { get; set; }
        //[Required(ErrorMessage = "Vui lòng điền đầy đủ không đ uể trống")]
        public DateTime? NgayCapNhat { get; set; }

        public int? SoLuongTon { get; set; }
        
        public int? MaCD { get; set; }

        public int? MaNXB { get; set; }

        public int? Status { get; set; }

        [StringLength(150)]
        public string Size { get; set; }

        [StringLength(50)]
        public string Weight { get; set; }
    }
}
