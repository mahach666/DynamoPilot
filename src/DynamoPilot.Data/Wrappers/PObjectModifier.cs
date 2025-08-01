using Ascon.Pilot.SDK;
using DynamoPilot.Data.Contracts;
using System;

namespace DynamoPilot.Data.Wrappers
{
    public class PObjectModifier : IWrapper
    {
        private readonly IObjectModifier _objectModifier;

        public PObjectModifier(IObjectModifier objectModifier)
        {
            _objectModifier = objectModifier;
        }

        public void Apply()
        {
            _objectModifier.Apply();
        }

        public void ChangeState(IDataObject @object, ObjectState state)
        {
            _objectModifier.ChangeState(@object, state);
        }

        public void Clear()
        {
            _objectModifier.Clear();
        }

        public IObjectBuilder Create(IDataObject parent, IType type)
        {
            return _objectModifier.Create(parent, type);
        }

        public IObjectBuilder Create(Guid id, IDataObject parent, IType type)
        {
            return _objectModifier.Create(id, parent, type);
        }

        public IObjectBuilder Create(Guid parent, IType type)
        {
            return _objectModifier.Create(parent, type);
        }

        public IObjectBuilder CreateById(Guid id, Guid parentId, IType type)
        {
            return _objectModifier.CreateById(id, parentId, type);
        }

        public void CreateLink(IRelation relation1, IRelation relation2)
        {
            _objectModifier.CreateLink(relation1, relation2);
        }

        public void Delete(IDataObject @object)
        {
            _objectModifier.Delete(@object);
        }

        public void DeleteById(Guid objectId)
        {
            _objectModifier.DeleteById(objectId);
        }

        public void DeletePermanently(Guid objectId)
        {
            _objectModifier.DeletePermanently(objectId);
        }

        //public void Dispose()
        //{
        //     _objectModifier.;
        //}

        public IObjectBuilder Edit(IDataObject @object)
        {
            return _objectModifier.Edit(@object);
        }

        public IObjectBuilder EditById(Guid objectId)
        {
            return _objectModifier.EditById(objectId);
        }

        public void Move(IDataObject @object, IDataObject newParent)
        {
            _objectModifier.Move(@object, newParent);
        }

        public void MoveById(Guid objectId, Guid newParentId)
        {
            _objectModifier.MoveById(objectId, newParentId);
        }

        public void RemoveLink(IDataObject obj, IRelation relation)
        {
            _objectModifier.RemoveLink(obj, relation);
        }

        public IObjectBuilder Restore(Guid objectId, Guid parentId)
        {
            return _objectModifier.Restore(objectId, parentId);
        }

        public IObjectBuilder RestorePermanentlyDeletedObject(Guid id, Guid parentId, IType type)
        {
            return _objectModifier.RestorePermanentlyDeletedObject(id, parentId, type);
        }

        public object Unwrap()
        {
            return _objectModifier;
        }
    }
}
