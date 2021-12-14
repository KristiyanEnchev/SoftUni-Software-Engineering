using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace MiniORM
{
    internal class ChangeTracker<T>
        where T : class, new()
    {
        private readonly List<T> allEntities;

        private readonly List<T> added;

        private readonly List<T> removed;

        public ChangeTracker(IEnumerable<T> entities)
        {
            this.added = new List<T>();
            this.removed = new List<T>();
            this.allEntities = CloneEntities(entities);
        }

        public IReadOnlyCollection<T> AllEntities => this.allEntities.AsReadOnly();
        public IReadOnlyCollection<T> Added => this.added.AsReadOnly();
        public IReadOnlyCollection<T> Removed => this.removed.AsReadOnly();


        private static List<T> CloneEntities(IEnumerable<T> entities)
        {
            List<T> clonedentities = new List<T>();

            PropertyInfo[] propertiesToClone = typeof(T)
                .GetProperties()
                .Where(pi => DbContext.AllowedSqlTypes.Contains
                (pi.PropertyType))
                .ToArray();

            foreach (T entity in entities)
            {
                T clonedentity = Activator.CreateInstance<T>();

                foreach (PropertyInfo property in propertiesToClone)
                {
                    object value = property.GetValue(entity);
                    property.SetValue(clonedentity, value);
                }

                clonedentities.Add(clonedentity);
            }

            return clonedentities;
        }

        public void Add(T item) => this.added.Add(item);
        public void Remove(T item) => this.removed.Add(item);

        public IEnumerable<T> GetModifiedEntities(DbSet<T> set)
        {
            List<T> modifiedEntitie = new List<T>();

            PropertyInfo[] primaryKeys = typeof(T)
                .GetProperties()
                .Where(pi => pi.HasAttribute<KeyAttribute>())
                .ToArray();

            foreach (T proxyentity in this.allEntities)
            {
                object[] primaryKeyValues = GetPrimerykeyValues(primaryKeys, proxyentity).ToArray();

                T entity = set.Entities
                    .Single(e => GetPrimerykeyValues(primaryKeys, e)
                    .SequenceEqual(primaryKeyValues));

                bool isModified = IsModified(proxyentity, entity);
                if (isModified)
                {
                    modifiedEntitie.Add(entity);
                }
            }

            return modifiedEntitie;
        }


        private static IEnumerable<object> GetPrimerykeyValues(IEnumerable<PropertyInfo> primaryKeys, T entity)
        {
            //return primaryKeys.Select(pk => pk.GetValue(entity));

            List<object> values = new List<object>();

            foreach (PropertyInfo primarykey in primaryKeys)
            {
                object pkvalue = primarykey.GetValue(entity);
                values.Add(pkvalue);
            }

            return values;
        }

        private static bool IsModified(T proxyEntity, T dbEntity)
        {
            PropertyInfo[] monitoredProperties = typeof(T)
                .GetProperties()
                .Where(pi => DbContext.AllowedSqlTypes
                .Contains(pi.PropertyType))
                .ToArray();

            PropertyInfo[] modifiedProperties = monitoredProperties
                .Where(pi => Equals(pi.GetValue(proxyEntity), pi.GetValue(dbEntity)))
                .ToArray();

            return modifiedProperties.Any();
        }

    }
}