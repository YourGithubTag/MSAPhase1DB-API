using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomTracker.Model
{
    public partial class Wardrobe
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("category")]
        [StringLength(50)]
        public string Category { get; set; }
        [Column("description")]
        [StringLength(1000)]
        public string Description { get; set; }
        [Column("colour")]
        [StringLength(50)]
        public string Colour { get; set; }
        [Column("condition")]
        [StringLength(25)]
        public string Condition { get; set; }
        [Column("situation")]
        [StringLength(50)]
        public string Situation { get; set; }
        [Column("value")]
        [StringLength(50)]
        public string Value { get; set; }
        [Column("importance")]
        public short? Importance { get; set; }
        [Column("purchase_date", TypeName = "date")]
        public DateTime? PurchaseDate { get; set; }
    }
}
