﻿using OnlineStore_Exam.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore_Exam.Domain.Common
{
    public class Auditable
    {
        public ItemState ItemState { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public void Create()
        {
            CreatedAt = DateTime.UtcNow;
            ItemState = ItemState.Active;
        }

        public void Update()
        {
            UpdatedAt = DateTime.UtcNow;
            ItemState = ItemState.Updated;
        }

        public void Delete()
        {
            UpdatedAt = DateTime.UtcNow;
            ItemState = ItemState.Deleted;
        }
    }
}
