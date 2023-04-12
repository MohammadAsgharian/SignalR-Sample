namespace SignalR_Sample.WebApi.Domain
{
    public abstract class Entity<TKey>
    {
        public TKey Id { get; protected set; }

        /// <summary>
        /// Check Equality of Two Entities
        /// </summary>
        /// <param name="obj">Entity</param>
        /// <returns>boolean</returns>
        public override bool Equals(object obj)
        {
            var entity = obj as Entity<TKey>;
            return entity != null &&
                GetType() == entity.GetType() &&
                EqualityComparer<TKey>.Default.Equals(Id, entity.Id);
        }

        public static bool operator ==(Entity<TKey> a, Entity<TKey> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity<TKey> a, Entity<TKey> b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Combines GetType() value and Id into a hash code.
        /// </summary>
        /// <returns>HashCode</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(GetType(), Id);
        }
    }
}
