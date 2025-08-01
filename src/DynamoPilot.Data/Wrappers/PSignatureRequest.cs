using Ascon.Pilot.SDK;
using DynamoPilot.Data.Contracts;
using System;
using System.Collections.Generic;

namespace DynamoPilot.Data.Wrappers
{
    public class PSignatureRequest : IWrapper
    {
        private readonly ISignatureRequest _signatureRequest;
        public PSignatureRequest(ISignatureRequest signatureRequest)
        {
            _signatureRequest = signatureRequest;
        }

        public override string ToString()
        {
            return $"{_signatureRequest.RequestedSigner} ({_signatureRequest.Id})";
        }

        public IReadOnlyList<string> Signs => _signatureRequest.Signs;

        public string PublicKeyOid 
        { get => _signatureRequest.PublicKeyOid; set => _signatureRequest.PublicKeyOid = value; }

        public CadesType LastSignCadesType 
        { get => _signatureRequest.LastSignCadesType; set => _signatureRequest.LastSignCadesType = value; }

        public bool IsAdvancementRequired 
        { get => _signatureRequest.IsAdvancementRequired; set => _signatureRequest.IsAdvancementRequired = value; }

        public Guid Id => _signatureRequest.Id;

        public Guid DatabaseId => _signatureRequest.DatabaseId;

        public int PositionId => _signatureRequest.PositionId;

        public string Role => _signatureRequest.Role;

        public string Sign => _signatureRequest.Sign;

        public string RequestedSigner => _signatureRequest.RequestedSigner;

        public Guid ObjectId => _signatureRequest.ObjectId;

        public object Unwrap()
        {
            return _signatureRequest;
        }
    }
}
