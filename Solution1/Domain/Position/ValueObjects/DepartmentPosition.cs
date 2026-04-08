using DirectoryService.Domain.PositionsContext.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryService.Domain.Position.ValueObjects
{
    public class DepartmentPosition
    {
        public Guid DepartmentId { get; }
        public PositionId PositionId { get; private set; }
        public PositionRank Rank { get; private set; }

        public DepartmentPosition(Guid deptId, PositionId posId, PositionRank rank)
        {
            DepartmentId = deptId;
            PositionId = posId;
            Rank = rank;
        }

        public void ChangeRank(PositionRank newRank)
        {
            // Здесь будет логика передвижения рангов
            Rank = newRank;
        }
    }
}
