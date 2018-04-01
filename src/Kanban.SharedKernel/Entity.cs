using System;

namespace Kanban.SharedKernel
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        public override bool Equals(object obj)
        {
            var entity = obj as Entity;
            return entity != null && entity.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
