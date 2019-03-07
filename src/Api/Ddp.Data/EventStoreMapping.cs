using System;
using System.Collections.Generic;
using Ddp.Domain;
using Ddp.Domain.EntityRelationshipModel.EntityTypes;
using Ddp.Domain.EntityRelationshipModel.Events;

namespace Ddp.Data
{
    public static class EventStoreMapping
    {
        private static readonly Dictionary<Type, string> EntityTypeMappings;
        private static readonly Dictionary<string, Type> EntityNameMappings;

        private static readonly Dictionary<Type, string> EventTypeMappings;
        private static readonly Dictionary<string, Type> EventNameMappings;

        static EventStoreMapping()
        {
            EntityTypeMappings = new Dictionary<Type, string>();
            EntityNameMappings = new Dictionary<string, Type>();

            EventTypeMappings = new Dictionary<Type, string>();
            EventNameMappings = new Dictionary<string, Type>();

            AddEntity<EntityType>("EntityType");
            AddEvent<EntityTypeRenamedEvent>("EntityTypeRenamedEvent");
        }

        private static void AddEntity<T>(string name) where T: EventSourcedEntity
        {
            EntityTypeMappings.Add(typeof(T), name);
            EntityNameMappings.Add(name, typeof(T));
        }

        private static void AddEvent<T>(string name) where T:IDomainEvent
        {
            EventTypeMappings.Add(typeof(T), name);
            EventNameMappings.Add(name, typeof(T));
        }

        public static string GetEntityName<T>()
        {
            EntityTypeMappings.TryGetValue(typeof(T), out var name);

            return name;
        }

        public static string GetEntityName(Type type)
        {
            EntityTypeMappings.TryGetValue(type, out var name);

            return name;
        }

        public static Type GetEntityType(string name)
        {
            EventNameMappings.TryGetValue(name, out var type);
            return type;
        }

        public static string GetEventName<T>()
        {
            EventTypeMappings.TryGetValue(typeof(T), out var name);

            return name;
        }

        public static string GetEventName(Type type)
        {
            EventTypeMappings.TryGetValue(type, out var name);

            return name;
        }

        public static Type GetEventType(string name)
        {
            EventNameMappings.TryGetValue(name, out var type);
            return type;
        }
    }
}