﻿using System;

namespace WebGallery.BL.DTO
{
    public class Photo : Item
    {
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Url { get; set; }
        public string Metadata { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
