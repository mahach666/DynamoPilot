using Ascon.Pilot.SDK;
using DynamoPilot.Data.Contracts;
using System;

namespace DynamoPilot.Data.Wrappers
{
    public class PSignatureBuilder : IWrapper
    {
        private readonly ISignatureBuilder _signatureBuilder;
        public PSignatureBuilder(ISignatureBuilder signatureBuilder)
        {
            _signatureBuilder = signatureBuilder;
        }

        public object Unwrap()
        {
            return _signatureBuilder;
        }

        public PSignatureBuilder WithDatabaseId(Guid databaseId)
        {
            _signatureBuilder.WithDatabaseId(databaseId);
            return this;
        }

        public PSignatureBuilder WithIsAdditional(bool value)
        {
            _signatureBuilder.WithIsAdditional(value);
            return this;
        }

        public PSignatureBuilder WithObjectId(Guid objectId)
        {
            _signatureBuilder.WithObjectId(objectId);
            return this;
        }

        public PSignatureBuilder WithPositionId(int positionId)
        {
            _signatureBuilder.WithPositionId(positionId);
            return this;
        }

        public PSignatureBuilder WithRequestSigner(string requestSigner)
        {
            _signatureBuilder.WithRequestSigner(requestSigner);
            return this;
        }

        public PSignatureBuilder WithRole(string role)
        {
            _signatureBuilder.WithRole(role);
            return this;
        }

        public PSignatureBuilder WithSign(string sign)
        {
            _signatureBuilder.WithSign(sign);
            return this;
        }
    }
}
