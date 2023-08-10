﻿using BaseProject.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace BaseProject.Models
{
    public class Material_Edit_Log_Model : IEntityBase
    {
        //자재명, 가격, 수량, 사진
        [Key]
        public int Id { get; set; }

        public int MaterialId { get; set; }
        public Material_Model Material { get; set; }

        public DateTime EditTime { get; set; }
    }
}
