﻿using System;

namespace MyWeb.DAL.Models
{
    public class Published
    {
        public string PK_PublishedId { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; } = string.Empty;
    }
}